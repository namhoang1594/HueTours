using Huetours.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core;
using Umbraco.Core.Services;
using Umbraco.Web.Mvc;

namespace Huetours.Controller
{
    public class ContactSurfaceController : SurfaceController
    {
        // GET: Contact
        public const string Partial_View_Folder = "~/Views/Partials/";
        public ActionResult RenderContact()
        {
            return PartialView(string.Format("{0}ContactForm.cshtml", Partial_View_Folder));
        }
        public ActionResult HandleSubmitForm(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                var id = Guid.Parse("28fa0f46-17f2-415a-b7bc-edce780e64a8");
                GuidUdi currentPageUdi = new GuidUdi(CurrentPage.ContentType.ItemType.ToString(), id);

                var send = Services.ContentService
                    .CreateContent(String.Format("{0} {1}", model.FullName, DateTime.Now.ToString()),
                    currentPageUdi, "receiverContact");
                send.SetValue("fullName", model.FullName);
                send.SetValue("email", model.Email);
                send.SetValue("phone", model.Phone);
                send.SetValue("message", model.Message);
                TempData["ContactUsSuccess"] = true;
                Services.ContentService.SaveAndPublish(send);
                return RedirectToCurrentUmbracoPage();
            }
            return CurrentUmbracoPage();

        }
    }
}