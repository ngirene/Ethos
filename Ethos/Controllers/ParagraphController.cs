using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ethos.Controllers
{
    public class ParagraphController : Controller
    {
		[HttpGet]
        public ActionResult Index()
        {
			var model = new ParagraphModel();
            return View (model);
        }

		[HttpPost]
        public ActionResult HandleForm(ParagraphModel model)
        {
			if (ModelState.IsValid)
			{
				try
				{
					var result = new ParagraphResultModel
					{
						Paragraph = model.Paragraph,
						ReverseWords = model.ReverseWordOrder(model.Paragraph),
						ReverseChars = model.ReverseCharacters(model.Paragraph),
						SortedParagraph = model.SortWords(model.Paragraph),
						EncryptedHash = model.Encrypt(model.Paragraph)
					};
					return View("Result", result);
				}
				catch (Exception)
				{
					return View("Error");
				}
			}
			else
			{
				return RedirectToAction("Index", "Paragraph");
			}

        }
    }
}