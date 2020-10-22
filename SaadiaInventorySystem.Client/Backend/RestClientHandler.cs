using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace SaadiaInventorySystem.Client.Backend
{
   public class RestClientHandler :DelegatingHandler
    {
        public RestClientHandler()
        {
            InnerHandler = new HttpClientHandler();
        }
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Console.WriteLine($"Request: {request}");
            if (request.Content != null)
            {
                Console.WriteLine(await request.Content.ReadAsStringAsync());
            }

            var response = await base.SendAsync(request, cancellationToken);
            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {

                Application.Current.Shutdown();
            }

            if (!response.IsSuccessStatusCode)
            {

                string message = String.Format($"Http Exception, Url:{request.RequestUri}, Http Status Code:{(int)response.StatusCode}, Reason:{response.ReasonPhrase}, Http Header:{ response.Headers.ToString()}");
                //throw new Exception(message);
            }

            return response;
        }
    }
}
