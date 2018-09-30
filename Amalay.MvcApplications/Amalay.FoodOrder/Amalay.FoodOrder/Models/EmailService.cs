using Amalay.FoodOrder.Configurations;
using Microsoft.AspNet.Identity;
using RestSharp;
using RestSharp.Authenticators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Amalay.FoodOrder.Models
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {


            EmailService.SendRegistrationMessage(message);
            // Plug in your email service here to send an email.
            return Task.FromResult(0);
        }

        public static RestResponse SendRegistrationMessage(IdentityMessage message)
        {
            RestClient client = new RestClient();
            AppConfiguration appConfig = new AppConfiguration();
            client.BaseUrl = new Uri("https://api.mailgun.net/v2");
            client.Authenticator = new HttpBasicAuthenticator("api", appConfig.EmailApiKey);
            RestRequest request = new RestRequest();
            request.AddParameter("domain", appConfig.DomainForApiKey, ParameterType.UrlSegment);
            request.Resource = "{domain}/messages";
            request.AddParameter("from", appConfig.FromName + " <" + appConfig.FromEmail + ">");
            request.AddParameter("to", "User <" + message.Destination + ">");
            request.AddParameter("subject", message.Subject);
            request.AddParameter("html", message.Body);
            request.Method = Method.POST;
            IRestResponse executor = client.Execute(request);
            return executor as RestResponse;
        }
    }
}