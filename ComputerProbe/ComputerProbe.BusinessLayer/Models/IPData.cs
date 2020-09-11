using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Models
{
    public class IPData
    {
        public int Id { get; set; }
        public int ProbeDataId { get; set; }
        public string InternalAddress { get; set; }
        public string ExternalAddress { get; set; }
        public string Host { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
