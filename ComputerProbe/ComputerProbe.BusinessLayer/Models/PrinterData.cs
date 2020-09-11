using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Models
{
    public class PrinterData
    {
        public int Id { get; set; }
        public int ProbeDataId { get; set; }
        public string Name { get; set; }
        public string Network { get; set; }
        public string Availability { get; set; }
        public string IsDefault { get; set; }
        public string DeviceID { get; set; }
        public string Status { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
