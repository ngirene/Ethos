using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ethos.Controllers
{
    public class AmortizationController : Controller
    {
        public ActionResult Index()
        {
			var model = new AmortizationModel();
            return View (model);
        }

		[HttpPost]
		public ActionResult HandleForm(AmortizationModel model)
		{
			if (ModelState.IsValid)
			{
				var results = new List<AmortizationResultModel>();
				var instance = new AmortizationModel
				{
					Principal = model.Principal,
					Terms = model.Terms,
					InterestRate = model.InterestRate,
				};

				do
				{
					var m = instance.Calculate(instance.Principal, instance.Terms, instance.InterestRate, model.Principal);
					results.Add(m);
				}
				while (
					results.Last().Balance > 0);
				return View("Result", results);
			}
			else
			{
				return View("Error");
			}

		}
    }
}
