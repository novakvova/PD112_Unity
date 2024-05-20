using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SendSMS.Models
{
    public class BalanceResponseDTO
    {
        public string Balance { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
    }
}
