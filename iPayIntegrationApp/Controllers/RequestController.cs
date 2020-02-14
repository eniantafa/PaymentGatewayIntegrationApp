using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentGatewayIntegrationApp.Controllers
{
    public class RequestController : Controller
    {

        //url of web service to service to call
        private string url = "https://yourwebservice.com/registerorderMethod?";

        //request parameters of rest service. 
        //To call web service please change the orderNumber in order to make a successful request   
        //When you change the orderNumber the Service will generate a new request
        private string requestParameters = "amount=3000&currency=978&language=en&orderNumber=2933749797374173977422&userName=UserName&password=Password&returnUrl=https://google.com";






        /*

        public string Order(string _url, string _requestParameters, Order order)
        {

            _url = url;
            _requestParameters = requestParameters;

            return requestParameters;
        }
        */



        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }




        public ActionResult HttpPost()
        {


            //
            System.Net.ServicePointManager.Expect100Continue = false;

            //add security protocol
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


            CookieContainer cookies = new CookieContainer();


            //Create a web request
            HttpWebRequest webrequest = WebRequest.Create(this.url) as HttpWebRequest;
            webrequest.KeepAlive = false;
            webrequest.ProtocolVersion = HttpVersion.Version10;
            webrequest.ServicePoint.ConnectionLimit = 1;


            //add default credentials
            webrequest.Credentials = CredentialCache.DefaultNetworkCredentials;

            //method type
            webrequest.Method = "POST";

            //content type
            webrequest.ContentType = "application/x-www-form-urlencoded";
            webrequest.CookieContainer = cookies;
            webrequest.ContentLength = this.requestParameters.Length;

            //add user agent
            webrequest.UserAgent = "Mozilla/5.0(Windows; U;Windows NT 5.1; en-US;RV1.9.0.1) Gecko/2008070208 Firefox/3.0.1";


            //  webrequest.Accept = "application/json;q=0.9,*/*;q=0.8";

            webrequest.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8";

            //add request writer with Stream Writer Package
            StreamWriter requestWriter = new StreamWriter(webrequest.GetRequestStream());



            //write and close request parameters
            requestWriter.Write(this.requestParameters);
            requestWriter.Close();


            //add a response reader with Stream Reeader Package
            StreamReader responseReader = new StreamReader(webrequest.GetResponse().GetResponseStream());
            var responseData = responseReader.ReadToEnd();
            System.Console.WriteLine(responseData);


            //   responseData = new Request { orderId } ;
            responseReader.Close();
            // webrequest.GetResponse().Close();

            //responseData=request.formUrl;




            //Deserialize Json object responded from rest service
            dynamic req = Newtonsoft.Json.JsonConvert.DeserializeObject(responseData);

            //catch just the form Url responded from rest service
            string Text = req["formUrl"];
            //var resultObject = JsonConvert.DeserializeObject(responseData);


            //redirect to payment form
            return Redirect(Text);
        }






    }
}

/*
public string DoOrder()
{
    /*ClientRest restClient = new RestClient(true);
    restClient.Call("POST"
        , this.url
        , this.requestParameters, (responseString) =>
        {
            System.Console.WriteLine("OK");
        }
        , (ex) =>
        {
            System.Console.WriteLine((ex.InnerException).Message);

        }
        );





    var request = (HttpWebRequest)WebRequest.Create(this.url);

    var postData = this.url;
    postData += this.requestParameters;
    var data = Encoding.ASCII.GetBytes(postData);

    request.Method = "POST";
    request.ContentType = "application/x-www-form-urlencoded";
    request.ContentLength = data.Length;

    using (var stream = request.GetRequestStream())
    {
        stream.Write(data, 0, data.Length);
    }

    var response = (HttpWebResponse)request.GetResponse();

    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();


    System.CO
    return responseString;
}
}
}
*/