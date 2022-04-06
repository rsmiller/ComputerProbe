# C# .NET Core Computer Probe
This is a very simple computer probe written in C# .NET Core 5 for companies to gain information about employee's machines or servers. This current rendition requires SQL Sever, however you can swap for MySQL by downloading the appropraite NuGet package, and modifying the ProbeContext to use it. The SQL for all the table structure is included.

Essentially you would add a username and password to appsettings and build the project. If you wanted to use an installer you could, if you want to manually install this somewhere on the user's computer you can. Ideally you want this on a task that will run mid-day when the computer is most likely on on a 24 hour cycle depending on your needs. This application will gather the following machine information:

* Computer name and user name
* Internal and external IPs
* All installed software
* NICs
* Printers
* GPU's
* Hard drives
* Processors
* OS information
* RAM information

This implementation works only with WINDOWS because it utilizes ManagementObjectSearcher. Maybe in the future there can be an implementation for Linux..
