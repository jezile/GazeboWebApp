using GazebosWebApp.Models;
using GazebosWebApp.Repository;
using System.Net;
using System.Web.Mvc;

namespace GazebosWebApp.Controllers
{
    public class CurrencyController : Controller
    {

        private IGenericRepository<CurrencyModel> repository = null;

        public CurrencyController()
        {
            this.repository = new CurrencyRepository();
        }

        public CurrencyController(IGenericRepository<CurrencyModel> repository)
        {
            this.repository = repository;
        }

        // GET: Currency
        public ActionResult Index()
        {
            //ViewBag.Message = "Currency converter (GBP > PLN).";
            return View();
        }

        // GET: Currency/Index/5
        [HttpPost]
        public ActionResult Index(string amount,
                                  string currencyFrom,
                                  string currencyTo)
        {
            //if (amount.Trim().Length == 0)
            //    ModelState.AddModelError("amount", "Value is required.");

            // var YourRadioButton1 = Request.Form["currencyRadio"];
            CurrencyModel cm = new CurrencyModel();
            cm.RunProcess(amount, currencyFrom, currencyTo);


            //if (!Request.IsAjaxRequest())
                return View(cm);
                          
            //var HttpStatus = ModelState.IsValid ? HttpStatusCode.OK : HttpStatusCode.BadRequest;
            //return new HttpStatusCodeResult(HttpStatus);
        }






    }
}
