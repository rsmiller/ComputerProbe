using System;
using System.Collections.Generic;
using System.Text;

namespace ComputerProbe.BusinessLayer.Models
{
    public class ErrorData
    {
        public int Id { get; set; }
        public int ProbeDataId { get; set; }
        public string Step { get; set; }
        public string Exception { get; set; }
        public string InnerException { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
