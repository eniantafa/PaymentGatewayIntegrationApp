using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayIntegrationApp.Models
{
    public class Order
    {


        public int OrderId { get; set; }


        public string Amount { get; set; }

        public string Currency { get; set; }

        public string Language { get; set; }

        public string OrderNumber { get; set; }

        public string UserName { get; set; }


        public string Password { get; set; }


        public string ReturnUrl { get; set; }


        public string Parameter { get; set; }
    }
}
