using System.Web.Mvc;
using AIS.Models;
using System.Net.Mail;
using hbehr.recaptcha;
namespace AIS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "We are about Service!";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "We can help, contact us today!";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(ContactModel contact)
        {
            string userResponse = HttpContext.Request.Params["g-recaptcha-response"];
            bool validCaptcha = ReCaptcha.ValidateCaptcha(userResponse);
            if (ModelState.IsValid && validCaptcha)
            {
                System.Text.StringBuilder sb;
                sb = new System.Text.StringBuilder();

                sb.Append("Name: " + contact.Name.ToString() + "<br>");

                if (!string.IsNullOrEmpty(contact.Company))
                    sb.Append("Company: " + contact.Company.ToString() + "<br>");
                if (!string.IsNullOrEmpty(contact.Phone))
                    sb.Append("Phone: " + contact.Phone.ToString() + "<br>");
                if (!string.IsNullOrEmpty(contact.Interest))
                    sb.Append("Interest: " + contact.Interest.ToString() + "<br>");
                if (!string.IsNullOrEmpty(contact.Comments))
                    sb.Append("Comments: " + contact.Comments.ToString() + "<br>");

                sb.Append("Email: " + contact.Email.ToString() + "<br>");

                if (this.SendEmail("AIS Web Form results", sb))
                {
                    ViewBag.Message = "Thank you, we will be in touch shortly!";
                }
                else
                {
                    ViewBag.Message = "There was a problem sending the form, please try again or use another email address.";
                }
            }
            return View();
        }

        public bool SendEmail(string esubject, object ebody)
        {
            bool mailsent;
            SmtpClient sm = new SmtpClient();

            MailMessage mail;
            mail = new MailMessage("craig8769@gmail.com", "craig8769@gmail.com");
            mail.Subject = esubject;
            mail.Body = ebody.ToString();
            mail.IsBodyHtml = true;
            try
            {
                sm.Send(mail);

                mailsent = true;
            }
            catch (SmtpException ex)
            {
                ViewBag.Message = ex.Message;
                mailsent = false;
            }
            return mailsent;
        }

        public ActionResult Support()
        {
            ViewBag.Message = "Our support is unmatched";

            return View();
        }
    }
}