using PaymentGatewayIntegrationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayIntegrationApp.Interfaces
{
    public interface IOrderRepository
    {

        void CreateOrder(Order order);
        Order GetParameter(string parameter);
    }
}
