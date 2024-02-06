using System;
using System.IO;
using RestSharp;
using RestSharp.Authenticators;

public class SendSimpleMessageChunk
{

    public static void Main(string[] args)
    {
        Console.WriteLine(SendSimpleMessage().Content.ToString());
    }

    public static IRestResponse SendSimpleMessage()
    {
        RestClient client = new RestClient();
        client.BaseUrl = new Uri("https://api.mailgun.net/v3");
        client.Authenticator =
            new HttpBasicAuthenticator("api",
                                        "API-Key");
        RestRequest request = new RestRequest();
        request.AddParameter("domain", "mail.domain.com", ParameterType.UrlSegment);
        request.Resource = "{domain}/messages";
        request.AddParameter("from", "from@domain.com");
        request.AddParameter("to", "to@gmail.com");
        request.AddParameter("to", "to@domain.com");
        request.AddParameter("subject", "Hello Last");
        request.AddParameter("text", "Testing some Mailgun awesomness!");
        request.Method = Method.POST;
        return client.Execute(request);
    }

}



