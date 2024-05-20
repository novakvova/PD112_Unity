using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SendSMS.Models
{
    public class SendSMSRequestDTO
    {
        public string Recipient { get; set; } = String.Empty;
        //public string? From { get; set; } = null;
        public string Text { get; set; } = string.Empty;
        public string ApiKey { get; set; } = String.Empty;
    }
}
