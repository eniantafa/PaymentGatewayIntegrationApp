using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using PaymentGatewayIntegrationApp.Interfaces;
using PaymentGatewayIntegrationApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace PaymentGatewayIntegrationApp.Controllers
{
    public class OrderController : Controller
    {
        private string url = "https://ipaytest.paylink.al/rest/register.do?";



        private readonly IOrderRepository _orderRepository;



        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }






        public IActionResult Checkout()
        {
            return View();
        }




        [HttpPost]

        public IActionResult Checkout(Order order)
        {



            _orderRepository.CreateOrder(order);

            string param = order.Parameter;
            //  _orderRepository.SetRequestParameter(order);


            //return RedirectToAction("HttpPost","Request",pppp);
            System.Net.ServicePointManager.Expect100Continue = false;
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            CookieContainer cookies = new CookieContainer();

            HttpWebRequest webrequest = WebRequest.Create(this.url) as HttpWebRequest;
            webrequest.KeepAlive = false;
            webrequest.ProtocolVersion = HttpVersion.Version10;
            webrequest.ServicePoint.ConnectionLimit = 1;

            webrequest.Credentials = CredentialCache.DefaultNetworkCredentials;
            webrequest.Method = "POST";
            webrequest.ContentType = "application/x-www-form-urlencoded";
            webrequest.CookieContainer = cookies;


            // _orderRepository.GetParameter(string parameter)



            webrequest.ContentLength = param.Length;
            webrequest.UserAgent = "Mozilla/5.0(Windows; U;Windows NT 5.1; en-US;RV1.9.0.1) Gecko/2008070208 Firefox/3.0.1";


            //  webrequest.Accept = "application/json;q=0.9,*/*;q=0.8";

            webrequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";


            StreamWriter requestWriter = new StreamWriter(webrequest.GetRequestStream());

            requestWriter.Write(param);
            requestWriter.Close();

            StreamReader responseReader = new StreamReader(webrequest.GetResponse().GetResponseStream());
            var responseData = responseReader.ReadToEnd();
            System.Console.WriteLine(responseData);


            //   responseData = new Request { orderId } ;
            responseReader.Close();
            // webrequest.GetResponse().Close();

            //responseData=request.formUrl;
            dynamic req = Newtonsoft.Json.JsonConvert.DeserializeObject(responseData);
            string Text = req["formUrl"];
            //var resultObject = JsonConvert.DeserializeObject(responseData);



            return Redirect(Text);
        }
    }
}