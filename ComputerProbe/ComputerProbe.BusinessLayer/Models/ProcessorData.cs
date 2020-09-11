using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Models
{
    public class ProcessorData
    {
        public int Id { get; set; }
        public int ProbeDataId { get; set; }
        public string Name { get; set; }
        public string DeviceId { get; set; }
        public string CurrentClockSpeed { get; set; }
        public string NumberOfCores { get; set; }
        public string AddressWidth { get; set; }
        public string NumberOfEnabledCore { get; set; }
        public string NumberOfLogicalProcessors { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
