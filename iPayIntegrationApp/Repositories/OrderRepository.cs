using PaymentGatewayIntegrationApp.Interfaces;
using PaymentGatewayIntegrationApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaymentGatewayIntegrationApp.Repositories
{
    public class OrderRepository:IOrderRepository
    {

        private readonly AppDbContext _appDbContext;



        public OrderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;

        }

        public void CreateOrder(Order order)
        {
            order.Currency = "978";
            order.Language = "en";

            //Enter the username & pawword
            order.UserName = "UserName";
            order.Password = "Password";
            order.ReturnUrl = "https://google.com";
            order.Parameter = "amount=" + order.Amount + "&currency=" + order.Currency + "&orderNumber=" + order.OrderNumber + "&userName=" + order.UserName + "&password=" + order.Password + "&returnUrl=" + order.ReturnUrl;

            _appDbContext.Orders.Add(order);







            //    Parameter = "amount=" + or.Amount + "&currency=" + or.Currency + "&orderNumber=" + or.OrderNumber + "&userName=" + or.UserName + "&password=" + or.Password + "&returnUrl=" + or.ReturnUrl; 

            _appDbContext.SaveChanges();
        }

        // public Order GetStringParameter() => _appDbContext.Orders.FirstOrDefault(p => p.Parameter);


        public Order GetParameter(string parameter) => _appDbContext.Orders.FirstOrDefault(p => p.Parameter == parameter);

    }
}
