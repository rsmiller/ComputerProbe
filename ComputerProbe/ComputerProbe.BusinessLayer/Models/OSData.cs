using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Models
{
    public class OSData
    {
        public int Id { get; set; }
        public int ProbeDataId { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string EncryptionLevel { get; set; }
        public string Version { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
