using Hotel.Services.Abstract;
using System;
using System.Text.RegularExpressions;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Hotel.Services
{
    public class Users : ISendSms
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Sms { get; set; }

        public void SendSmsTwilio(string numberUsers)
        {
            Random rand = new Random();
            string random = rand.Next(1001, 9999).ToString();

            const string accountSid = "AC773cca6940429e6402d846c1d1a09393";
            const string authToken = "df57b227dccdd47077570a1a7b436e22";

            TwilioClient.Init(accountSid, authToken);

            var message = MessageResource.Create
                (
               body: random,
                from: new Twilio.Types.PhoneNumber("+16194923738"),
                to: new Twilio.Types.PhoneNumber(numberUsers)
                );
            Sms = random;
        }

        
    }
}
