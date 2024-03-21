using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace Hamburger_MVC.Models
{
	public class EmailSender : IEmailSender
	{
		private readonly IConfiguration _config;
		public EmailSender(IConfiguration config)
		{
			_config = config;
		}

		public async Task SendEmailAsync(string email, string subject, string htmlMessage)
		{
            string smtpServer = _config["EmailSettings:SmtpServer"];
            int smtpPort = Convert.ToInt32(_config["EmailSettings:SmtpPort"]);
            string username = _config["EmailSettings:Username"];
            string password = _config["EmailSettings:Password"];

            using (SmtpClient smtpClient = new SmtpClient(smtpServer, smtpPort))
			{
				smtpClient.UseDefaultCredentials = false;
				smtpClient.Credentials = new NetworkCredential(username, password);
				smtpClient.EnableSsl = true;

				MailMessage mail = new MailMessage();
				mail.From = new MailAddress("diyetTakip@gmail.com");
				mail.To.Add(new MailAddress(email));
				mail.Subject = subject;
				mail.IsBodyHtml = true;

				mail.Body = htmlMessage;

				await smtpClient.SendMailAsync(mail);
			}
		}
	}

}
