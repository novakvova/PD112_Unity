
using SendSMS.Models;
using System.Text;

namespace SendSMS
{
    public class Program
    {
        public static void Main(string[] args)
        {
            SMSService sMSService = new SMSService();
            //var balance = sMSService.GetBalance();
            //Console.WriteLine("Balance "+ balance.Balance);
            //string result = sMSService.SendSMS("", "380990497000");
            //var result = sMSService.SendSMS("Доброго вечора. Перевірка звязку!", "380638442589");
            //Console.WriteLine("Send sms {0}", result);
            var balance = sMSService.GetBalance();
            Console.WriteLine("Balance " + balance.Balance);

        }

        
    }
}



