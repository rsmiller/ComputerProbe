using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Models
{
    public class GPUData
    {
        public int Id { get; set; }
        public int ProbeDataId { get; set; }
        public string Name { get; set; }
        public string AdapterRAM { get; set; }
        public string DriverVersion { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
