using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ConAppFWMailgun
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (var httpClient = new HttpClient())
            {
                var authToken = Encoding.ASCII.GetBytes($"api:privatekey");

                //var authToken = Encoding.ASCII.GetBytes($"api:49a3f5df019c65abd5ac23482bff84e0 - 4de08e90 - d211f48d");

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

                var formContent = new FormUrlEncodedContent(new Dictionary<string, string> {
        { "from", $"norep1y@mail.fathopesenergy.com" },
        { "h:Reply-To", $"norep1y@mail.fathopesenergy.com" },
        { "to", "azeem@fathopesenergy.com, internettoo@fathopesenergy.com" },
        { "subject", "Test Mailgun with two recipients" },
        { "text", "Test Sent by Mailgun" },
        { "html", "Test Sent by Mailgun" }
    });

                var result = await httpClient.PostAsync($"https://api.mailgun.net/v3/mail.fathopesenergy.com/messages", formContent);
                result.EnsureSuccessStatusCode();
            }
        }
    }
}
