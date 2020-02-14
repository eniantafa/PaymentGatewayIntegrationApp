using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayIntegrationApp.Models
{
    public class Request
    {

        public string orderId { get; set; }
        public string formUrl { get; set; }
    }
}
