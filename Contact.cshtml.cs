using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AboutMe.Models;
using System.Net.Mail;
using System.Net;
using System;

namespace AboutMe.Pages
{
    public class ContactModel : PageModel
    {
        [BindProperty]
        public Message mail { get; set; }

        public async Task OnPost()
        {
            if (ModelState.IsValid)
            {
            var body = ("Name: " + mail.Name + Environment.NewLine + "Email: " + mail.Email + Environment.NewLine + Environment.NewLine + "Message: " + Environment.NewLine + mail.Body);
            MailMessage message = new MailMessage();
            message.To.Add("103narwhal@gmail.com");
            message.Subject = mail.Subject;
            message.Body = body;
            message.IsBodyHtml = false;
            message.From = new MailAddress(mail.Email);
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.UseDefaultCredentials = true;
            smtp.EnableSsl = true;
            smtp.Credentials = new System.Net.NetworkCredential("103narwhal@gmail.com", "Lmkn092!");
            await smtp.SendMailAsync(message);
            ViewData["Message"] = "Thank you! Your message has been sent.";
            }

            
        }

    }
}