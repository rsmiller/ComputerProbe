using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerProbe.BusinessLayer.Models
{
    public class RAMData
    {
        public int Id { get; set; }
        public int ProbeDataId { get; set; }
        public long Size { get; set; }
        public string Part { get; set; }
        public string MemoryType { get; set; }
        public string SerialNumber { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
