using JFU.Models;
using PayPal.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace JFU.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult PaymentWithAPI()
        {

            Dictionary<string, string> sdkConfig = new Dictionary<string, string>();
            sdkConfig.Add("mode", "sandbox");
            string accessToken = new OAuthTokenCredential("AU1uqc8xi__uSX0ybz8eL1N1ohh4KpmUczobynZeayib0dBBYf2g6qdpLoKCZtI8_s4mvKqG4-Z_5YRg", "EKZhuVvT4CVLW16Rv12YBGLVcKiyMSwFCN4yC_vtvJzxv6j8TZ0p6FZHLb6HuJtGDyF551Uoy3-XH8qr", sdkConfig).GetAccessToken();
            APIContext apiContext = new APIContext(accessToken);
            apiContext.Config = sdkConfig;
            Amount amnt = new Amount();
            amnt.currency = "USD";
            amnt.total = "12";
            List<Transaction> transactionList = new List<Transaction>();
            Transaction tran = new Transaction();
            tran.description = "creating a payment";
            tran.amount = amnt;
            transactionList.Add(tran);
            Payer payr = new Payer();
            payr.payment_method = "paypal";
            RedirectUrls redirUrls = new RedirectUrls();
            redirUrls.cancel_url = "https://devtools-paypal.com/guide/pay_paypal/dotnet?cancel=true";
            redirUrls.return_url = "https://devtools-paypal.com/guide/pay_paypal/dotnet?success=true";
            Payment pymnt = new Payment();
            pymnt.intent = "sale";
            pymnt.payer = payr;
            pymnt.transactions = transactionList;
            pymnt.redirect_urls = redirUrls;
            Payment createdPayment = pymnt.Create(apiContext);
            return View();
        }

        
        public ActionResult Test()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
   public  class PaymentDetailsType
   {


   }
}