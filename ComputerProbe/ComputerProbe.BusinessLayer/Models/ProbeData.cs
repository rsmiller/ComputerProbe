using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Models
{
    public class ProbeData
    {
        public int Id { get; set; }
        public string MachineName { get; set; }
        public string DomainName { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? LastUpdate { get; set; }
    }
}
