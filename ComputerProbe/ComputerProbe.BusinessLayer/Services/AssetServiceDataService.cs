﻿using ComputerProbe.Business.DataAccess;
using ComputerProbe.BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ComputerProbe.BusinessLayer.Services
{
    public enum ContentCreatorContentResultCode
    {
        None = 0,
        Okay = 1,
        InvalidContent = -1,
        NotFound = -2,
        NullItemInput = -3,
        Error = -5,
        DataValidationError = -6,
        AlreadyExists = -7
    }

    public interface IAssetServiceDataService
    {
        ProbeData GetOrCreateMachine(string computerName, string domainName);
        void CreateDriveData(int probeDataId, DriveData data);
        void CreateGPUData(int probeDataId, GPUData data);
        void CreateOSData(int probeDataId, OSData data);
        void CreateNetworkData(int probeDataId, NetworkData data);
        void CreatePrinterData(int probeDataId, PrinterData data);
        void CreateSoftwareData(int probeDataId, SoftwareData data);
        void CreateError(int probeDataId, string step, Exception exception);
    }

    public class AssetServiceDataService : IAssetServiceDataService
    {
        private ProbeContext _Context;

        public AssetServiceDataService(ProbeContext context)
        {
            _Context = context;
        }

        public ProbeData GetOrCreateMachine(string computerName, string domainName)
        {
            var result = _Context.ProbeData.SingleOrDefault(m => m.MachineName.ToLower() == computerName.ToLower() && m.DomainName.ToLower() == domainName.ToLower());

            if (result != null)
                return result;

            var now = DateTime.UtcNow;
            var data = new ProbeData()
            {
                MachineName = computerName,
                DomainName = domainName,
                CreatedOn = now,
                UpdatedOn = now
            };

            _Context.ProbeData.Add(data);

            _Context.SaveChanges();

            return data;
        }

        public void CreateDriveData(int probeDataId, DriveData data)
        {
            data.ProbeDataId = probeDataId;
            data.CreatedOn = DateTime.UtcNow;

            _Context.DriveData.Add(data);
            _Context.SaveChanges();
        }

        public void CreateGPUData(int probeDataId, GPUData data)
        {
            data.ProbeDataId = probeDataId;
            data.CreatedOn = DateTime.UtcNow;

            _Context.GPUData.Add(data);
            _Context.SaveChanges();
        }

        public void CreateOSData(int probeDataId, OSData data)
        {
            data.ProbeDataId = probeDataId;
            data.CreatedOn = DateTime.UtcNow;

            _Context.OSData.Add(data);
            _Context.SaveChanges();
        }

        public void CreateIPData(int probeDataId, IPData data)
        {
            data.ProbeDataId = probeDataId;
            data.CreatedOn = DateTime.UtcNow;

            _Context.IPData.Add(data);
            _Context.SaveChanges();
        }

        public void CreatePrinterData(int probeDataId, PrinterData data)
        {
            data.ProbeDataId = probeDataId;
            data.CreatedOn = DateTime.UtcNow;

            _Context.PrinterData.Add(data);
            _Context.SaveChanges();
        }

        public void CreateNetworkData(int probeDataId, NetworkData data)
        {
            data.ProbeDataId = probeDataId;
            data.CreatedOn = DateTime.UtcNow;

            _Context.NetworkData.Add(data);
            _Context.SaveChanges();
        }

        public void CreateProcessorData(int probeDataId, ProcessorData data)
        {
            data.ProbeDataId = probeDataId;
            data.CreatedOn = DateTime.UtcNow;

            _Context.ProcessorData.Add(data);
            _Context.SaveChanges();
        }

        public void CreateSoftwareData(int probeDataId, SoftwareData data)
        {
            data.ProbeDataId = probeDataId;
            data.CreatedOn = DateTime.UtcNow;

            _Context.SoftwareData.Add(data);
            _Context.SaveChanges();
        }

        public void CreateError(int probeDataId, string step, Exception exception)
        {
            var data = new ErrorData()
            {
                ProbeDataId = probeDataId,
                Step = step,
                CreatedOn = DateTime.UtcNow,
                Exception = exception.Message,
                InnerException = exception.InnerException.Message
            };

            _Context.ErrorData.Add(data);
            _Context.SaveChanges();
        }
    }
}
