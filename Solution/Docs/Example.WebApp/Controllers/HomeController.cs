using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TbcBank.EcommerceClient;

namespace Example.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly TbcBankEcommerceClient _tbcBankEcommerceClient;

        public HomeController(
            TbcBankEcommerceClient tbcBankEcommerceClient
            )
        {
            _tbcBankEcommerceClient = tbcBankEcommerceClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Pay()
        {
            var currency = CurrencyCode.GEL;

            // If using multiple merchants, select the appropriate one
            _tbcBankEcommerceClient
                .SelectMerchant(currency);

            // Create Transaction
            var registerResult = await _tbcBankEcommerceClient
                .RegisterTransactionAsync(
                    100,
                    currency,
                    HttpContext.Connection.RemoteIpAddress?.ToString(),
                    "Transaction example",
                    PaymentUiLanguage.Georgian,
                    "MerchantTransaction-00001"
                );

            // Check if error occured
            if (registerResult.IsError)
                return RedirectToAction("index");

            // When succeeded redirect to bank page
            var redirectUrl = _tbcBankEcommerceClient
                .GetClientRedirectUrl(registerResult.TransactionId);

            return Redirect(redirectUrl);
        }
    }
}
