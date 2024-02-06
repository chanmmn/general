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

                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

                var formContent = new FormUrlEncodedContent(new Dictionary<string, string> {
        { "from", $"norep1y@mail.domain.com" },
        { "h:Reply-To", $"norep1y@mail.domain.com" },
        { "to", "user@domain.com" },
        { "subject", "Test Mailgun with two recipients" },
        { "text", "Test Sent by Mailgun" },
        { "html", "Test Sent by Mailgun" }
    });

                var result = await httpClient.PostAsync($"https://api.mailgun.net/v3/mail.domain.com/messages", formContent);
                result.EnsureSuccessStatusCode();
            }
        }
    }
}
