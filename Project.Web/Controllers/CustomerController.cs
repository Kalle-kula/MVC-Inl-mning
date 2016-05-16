using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Project.Domain.Models;
using Project.Domain.Repository;
using Project.Domain.Service;
using Project.Web.Models;

namespace Project.Web.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        private readonly IProductService _productService;
        private readonly IUserRepository _userRepository;

        public CustomerController(IProductService productService, IUserRepository userRepository)
        {
            _productService = productService;
            _userRepository = userRepository;
        }

        public ActionResult Index()
        {
            var model = new ProductListViewModel();

            model.Products = _productService.GetAll().Select(p => new ProductViewModel(p)).ToList();

            model.Components = _productService.GetProductComponents().Select(c => new ComponentViewModel(c)).ToList();

            model.ComponentParts = _productService.GetComponentParts().Select(cp => new ComponentPartViewModel(cp)).ToList();

            return View(model);
        }

        
        public void PlaceOrder(string productName, string totalPrice, List<OrderDetails> details, string userName)
        {
            totalPrice = totalPrice.Substring(0, totalPrice.IndexOf(" "));

            var order = new Order
            {
                ProductName = productName,
                TotalPrice = Convert.ToDecimal(totalPrice)         
            };

            _productService.SaveOrder(order);

            var orderId = _productService.GetOrders().Last().Id;

            foreach (var od in details)
            {
                od.OrderId = orderId;
                _productService.SaveOrderDetails(od);
            }

            string body = string.Format("You have made an order: \n Product: {0} \n "+
                                            "Parts: {1} {2}, {3} {4} and {5} {6} \n "+
                                            "Thank you for your order, please pay this order within 12 days. \n"+
                                            "Your order date: {7} \n"+
                                            "It will expire: {8} \n"+
                                            "Best regards /Islam, Kalle, Lina. \n",
                                            productName,
                                            details[0].Name, details[0].Type,
                                            details[1].Name, details[1].Type,
                                            details[2].Name, details[2].Type,
                                            DateTime.Now, DateTime.Now.AddDays(12));

            var to = _userRepository.GetByUsername(userName);

            var email = new Email()
            {
                Body = body,
                From = "linakalleislammvc@gmail.com",
                To = to.Email,
                Subject = "Order"
            };

            SendEmail(email);
        }

        public void SendEmail(Email email)
        {
            var mailMessage = new MailMessage
            {
                From = new MailAddress(email.From),
                To = { email.To },
                Subject = email.Subject,
                Body = email.Body
            };

            var client = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential
                {
                    //Ta den inloggade
                    UserName = "linakalleislammvc@gmail.com",
                    Password = "linakalleislam123"
                }
            };

            client.Send(mailMessage);
            client.Timeout = 3000;
            client.Dispose();
        }
    }
}