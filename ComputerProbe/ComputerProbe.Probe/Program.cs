using Microsoft.Extensions.Configuration;
using System;
using ComputerProbe.BusinessLayer;
using ComputerProbe.BusinessLayer.Models;
using System.IO;
using ComputerProbe.BusinessLayer.Services;
using System.Management;
using System.Net.NetworkInformation;
using System.Net;
using System.Linq;
using System.Net.Sockets;

namespace ComputerProbe.Probe
{
    class Program
    {
        private static DatabaseConnectionSettings _DBSettings = new DatabaseConnectionSettings();
        private static string _DatabaseUserPassword = "AtiG30wOkkTlJuXsFUM";
        // Idealy you want to obtain this from another source.... Not have it in an config nor in code. Small business, small budgets

        private static AssetServiceDataService _AssetDataService;

        private static ProbeContext _Context;
        private static ProbeData _MachineData;

        static void Main(string[] args)
        {
            Console.WriteLine("Starting up....");
            var config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false).Build();

            config.GetSection("DBConnection").Bind(_DBSettings);

            _DBSettings.ConnectionString += ";password=" + _DatabaseUserPassword;

            _Context = new ProbeContext(_DBSettings.ConnectionString);
            _AssetDataService = new AssetServiceDataService(_Context);

            _MachineData = _AssetDataService.GetOrCreateMachine(Environment.MachineName, Environment.UserDomainName);

            GetOS();
            GetProcessors();
            GetIPs();
            GetHardDriveData();
            GetGPUs();
            GetNICs();
            GetPrinters();
        }

        private static void GetOS()
        {
            try
            {

                ManagementObjectSearcher myOperativeSystemObject = new ManagementObjectSearcher("select * from Win32_OperatingSystem");

                foreach (ManagementObject obj in myOperativeSystemObject.Get())
                {
                    Console.WriteLine("Caption  -  " + obj["Caption"]);
                    Console.WriteLine("CountryCode  -  " + obj["CountryCode"]);
                    Console.WriteLine("EncryptionLevel  -  " + obj["EncryptionLevel"]);
                    Console.WriteLine("Version  -  " + obj["Version"]);

                    var data = new OSData()
                    {
                        Name = obj["Caption"].ToString(),
                        CountryCode = obj["CountryCode"].ToString(),
                        EncryptionLevel = obj["EncryptionLevel"].ToString(),
                        Version = obj["Version"].ToString()
                    };

                    _AssetDataService.CreateOSData(_MachineData.Id, data);
                }
            }
            catch (Exception e)
            {
                _AssetDataService.CreateError(_MachineData.Id, "GetOS", e);
            }
        }

        private static void GetProcessors()
        {
            try
            {
                ManagementObjectSearcher myProcessorObject = new ManagementObjectSearcher("select * from Win32_Processor");

                foreach (ManagementObject obj in myProcessorObject.Get())
                {
                    Console.WriteLine("Name  -  " + obj["Name"]);
                    Console.WriteLine("DeviceID  -  " + obj["DeviceID"]);
                    Console.WriteLine("CurrentClockSpeed  -  " + obj["CurrentClockSpeed"]);
                    Console.WriteLine("NumberOfCores  -  " + obj["NumberOfCores"]);
                    Console.WriteLine("NumberOfEnabledCore  -  " + obj["NumberOfEnabledCore"]);
                    Console.WriteLine("NumberOfLogicalProcessors  -  " + obj["NumberOfLogicalProcessors"]);
                    Console.WriteLine("AddressWidth  -  " + obj["AddressWidth"]);

                    var data = new ProcessorData()
                    {
                        Name = obj["Name"].ToString(),
                        DeviceId = obj["DeviceID"].ToString(),
                        CurrentClockSpeed = obj["CurrentClockSpeed"].ToString(),
                        NumberOfCores = obj["NumberOfCores"].ToString(),
                        NumberOfEnabledCore = obj["NumberOfEnabledCore"].ToString(),
                        NumberOfLogicalProcessors = obj["NumberOfLogicalProcessors"].ToString(),
                        AddressWidth = obj["AddressWidth"].ToString()
                    };

                    _AssetDataService.CreateProcessorData(_MachineData.Id, data);
                }
            }
            catch (Exception e)
            {
                _AssetDataService.CreateError(_MachineData.Id, "GetProcessors", e);
            }
        }

        private static void GetHardDriveData()
        {
            try
            {
                DriveInfo[] allDrives = DriveInfo.GetDrives();

                foreach (DriveInfo d in allDrives)
                {
                    Console.WriteLine("Drive {0}", d.Name);
                    Console.WriteLine("  Drive type: {0}", d.DriveType);
                    if (d.IsReady == true)
                    {
                        Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                        Console.WriteLine("  File system: {0}", d.DriveFormat);
                        Console.WriteLine("  Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);

                        Console.WriteLine("  Total available space:          {0, 15} bytes", d.TotalFreeSpace);

                        Console.WriteLine("  Total size of drive:            {0, 15} bytes ", d.TotalSize);


                        var data = new DriveData()
                        {
                            Name = d.Name,
                            DriveType = d.DriveType.ToString(),
                            VolumeLabel = d.VolumeLabel,
                            DriveFormat = d.DriveFormat,
                            AvailableSpace = d.AvailableFreeSpace,
                            TotalSpace = d.TotalFreeSpace,

                        };

                        _AssetDataService.CreateDriveData(_MachineData.Id, data);
                    }
                }
            }
            catch (Exception e)
            {
                _AssetDataService.CreateError(_MachineData.Id, "GetHardDriveData", e);
            }
        }

        private static void GetGPUs()
        {
            try
            {
                ManagementObjectSearcher myVideoObject = new ManagementObjectSearcher("select * from Win32_VideoController");

                foreach (ManagementObject obj in myVideoObject.Get())
                {
                    Console.WriteLine("Name  -  " + obj["Name"]);
                    Console.WriteLine("AdapterRAM  -  " + obj["AdapterRAM"]);
                    Console.WriteLine("InstalledDisplayDrivers  -  " + obj["InstalledDisplayDrivers"]);
                    Console.WriteLine("DriverVersion  -  " + obj["DriverVersion"]);

                    var data = new GPUData()
                    {
                        Name = obj["Name"].ToString(),
                        AdapterRAM = obj["AdapterRAM"].ToString(),
                        DriverVersion = obj["DriverVersion"].ToString()
                    };

                    _AssetDataService.CreateGPUData(_MachineData.Id, data);
                }

            }
            catch (Exception e)
            {
                _AssetDataService.CreateError(_MachineData.Id, "GetGPUs", e);
            }
        }

        private static void GetNICs()
        {
            try
            {
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (NetworkInterface adapter in nics)
                    {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    Console.WriteLine();
                    Console.WriteLine(adapter.Description);
                    Console.WriteLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                    Console.WriteLine("  Interface type .......................... : {0}", adapter.NetworkInterfaceType);
                    Console.WriteLine("  Physical Address ........................ : {0}", adapter.GetPhysicalAddress());
                    Console.WriteLine("  Operational status ...................... : {0}", adapter.OperationalStatus);

                    var data = new NetworkData()
                    {
                        Name = adapter.Description,
                        Type = adapter.NetworkInterfaceType.ToString(),
                        Address = adapter.GetPhysicalAddress().ToString(),
                        Status = adapter.OperationalStatus.ToString()
                    };

                    _AssetDataService.CreateNetworkData(_MachineData.Id, data);
                }
            }
            catch (Exception e)
            {
                _AssetDataService.CreateError(_MachineData.Id, "GetNICs", e);
            }
        }

        private static void GetIPs()
        {
            try
            {
                // My address
                var host = Dns.GetHostEntry(Dns.GetHostName());

                // Get Local IP4 address
                var ip = new WebClient().DownloadString("https://ipv4.icanhazip.com/").Replace("\n", "");
                var externalServerIPAddress = System.Net.IPAddress.Parse(ip);

                Console.WriteLine("External IP: " + externalServerIPAddress.ToString());

                var thisIPAddress = host.AddressList.Where(m => m.AddressFamily == AddressFamily.InterNetwork).LastOrDefault();

                // Linux
                if (thisIPAddress == null)
                {
                    thisIPAddress = NetworkInterface.GetAllNetworkInterfaces().SelectMany(i => i.GetIPProperties().UnicastAddresses).Select(a => a.Address).Where(a => a.AddressFamily == AddressFamily.InterNetwork).LastOrDefault();
                    Console.WriteLine("Internal IP: " + thisIPAddress.ToString());
                }
                else
                {
                    var ipAddresses = host.AddressList.Where(m => m.AddressFamily == AddressFamily.InterNetwork).ToList();
                    foreach (var theIP in ipAddresses)
                        Console.WriteLine("Internal IP: " + theIP.ToString());

                }

                var data = new IPData()
                {
                    ExternalAddress = externalServerIPAddress.ToString(),
                    InternalAddress = thisIPAddress.ToString(),
                    Host = host.HostName
                };

                _AssetDataService.CreateIPData(_MachineData.Id, data);
            }
            catch (Exception e)
            {
                _AssetDataService.CreateError(_MachineData.Id, "GetIPs", e);
            }
        }

        private static void GetPrinters()
        {
            try
            {
                ManagementObjectSearcher myPrinterObject = new ManagementObjectSearcher("select * from Win32_Printer");

                foreach (ManagementObject obj in myPrinterObject.Get())
                {
                    Console.WriteLine("Name  -  " + obj["Name"]);
                    Console.WriteLine("Network  -  " + obj["Network"]);
                    Console.WriteLine("Availability  -  " + obj["Availability"]);
                    Console.WriteLine("Is default printer  -  " + obj["Default"]);
                    Console.WriteLine("DeviceID  -  " + obj["DeviceID"]);
                    Console.WriteLine("Status  -  " + obj["Status"]);

                    var data = new PrinterData()
                    {
                        Name = obj["Name"].ToString(),
                        Network = obj["Network"].ToString(),
                        Availability = obj["Availability"].ToString(),
                        IsDefault = obj["Default"].ToString(),
                        DeviceID = obj["DeviceID"].ToString(),
                        Status = obj["Status"].ToString(),
                    };

                    _AssetDataService.CreatePrinterData(_MachineData.Id, data);
                }
            }
            catch (Exception e)
            {
                _AssetDataService.CreateError(_MachineData.Id, "GetPrinters", e);
            }
        }
    }
}
