using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendSMS.Models
{
    public class MobizonResponseDTO<T> where T : class
    {
        public int Code { get; set; }
        public T Data { get; set; } = null!;
        public string Message { get; set; } = string.Empty;
    }
}
