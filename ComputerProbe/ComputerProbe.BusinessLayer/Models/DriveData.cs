using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Models
{
    public class DriveData
    {
        public int Id { get; set; }
        public int ProbeDataId { get; set; }
        public string Name { get; set; }
        public string DriveType { get; set; }
        public string VolumeLabel { get; set; }
        public string DriveFormat { get; set; }
        public string UserAvailableSpace { get; set; }
        public long AvailableSpace { get; set; }
        public long TotalSpace { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
