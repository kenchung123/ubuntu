using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SentPasswordController1 : Controller
    {
        [HttpPost]
        public IActionResult SentPassword(string email)
        {

            //instantiate a new MimeMessage
            var message = new MimeMessage();
            //Setting the To e-mail address
            message.To.Add(new MailboxAddress("E-mail Recipient Name", email));
            //Setting the From e-mail address
            message.From.Add(new MailboxAddress("E-mail From Name", "teamwork3s.2019@gmail.com"));
            //E-mail subject 
            message.Subject = "NewPassword";
            //E-mail message body
            message.Body = new TextPart(TextFormat.Html)
            {
                Text = "vinh bi dien"
            };

            //Configure the e-mail
            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect("smtp.gmail.com", 587, false);
                emailClient.Authenticate("quocminh123.dt@gmail.com", "6402wanbi");
                emailClient.Send(message);
                emailClient.Disconnect(true);
            }

            return null;
        }
    }
}