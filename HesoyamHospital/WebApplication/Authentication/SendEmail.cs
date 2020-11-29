using System;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace WebApplication.Authentication
{
    public class SendEmail : ISendEmail
    {
        private readonly Random _random = new Random();
        private readonly string strBody = "<html><body style=\"font-family:verdana;\"><div style=\"text-align: center; margin: 0 auto; padding: 30px; backgorund: white;\"><h2>Activate your Account</h2>\n\n Thank you for registering. In order to activate your account please click on button bellow.\n\n<br><br><form id=\"form1\" action=\"http://localhost:52166/api/registration/activate/token\" method=\"post\"><a href = \"javascript:;\" onclick=\"document.getElementById('form1').submit();\"></a><input type = \"submit\" name=\"mess\" value=\"ACTIVATE ACCOUNT\" style=\"color: white; background-color: #3399ff; padding: 20px 32px; margin: 4px 2px; border: none; border-radius: 12px; font-size: 20px; font-family:verdana; \"></form></div><body></html>";
        public SendEmail() {}

        public void SendActivationEmail(long id, string patientEmailAddress)
        {
            MailAddress senderEmail = new MailAddress("hesoyamhospital@gmail.com");
            MailAddress patientEmail = new MailAddress(patientEmailAddress);
            SmtpClient client = CreateNewClient(senderEmail, "perapera");
            MailMessage email = CreateEmail(senderEmail, patientEmail, id); 
            client.Send(email);
        }

        private SmtpClient CreateNewClient(MailAddress senderEmail, string senderPassword)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.UseDefaultCredentials = false;
            smtpClient.Credentials = new NetworkCredential(senderEmail.Address, senderPassword);
            smtpClient.EnableSsl = true;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port = 587;
            return smtpClient;
        }

        private MailMessage CreateEmail(MailAddress senderEmail, MailAddress patientEmail, long id)
        {
            MailMessage mailMessage = new MailMessage(senderEmail, patientEmail);
            mailMessage.Subject = "Activate account";
            mailMessage.IsBodyHtml = true;

            string html = strBody.Replace("token", CreateToken(id));
            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(html, new ContentType("text/html"));
            mailMessage.AlternateViews.Add(htmlView);

            return mailMessage;
        }

        public string CreateToken(long id)
        {
            return RandomString(20, false) + id.ToString();
        }

        public string RandomString(int size, bool lowerCase = false)
        {
            var builder = new StringBuilder(size);
            char offset = lowerCase ? 'a' : 'A';
            const int lettersOffset = 26;
            for (var i = 0; i < size; i++)
            {
                var @char = (char)_random.Next(offset, offset + lettersOffset);
                builder.Append(@char);
            }
            return lowerCase ? builder.ToString().ToLower() : builder.ToString();
        }

        public long TokenToId(string token)
        {
            if(token.Length > 20)
            {
                string idText = token.Substring(20);
                try
                {
                    long id = (long)Convert.ToDouble(idText);
                    return id;

                } catch
                {
                    return 0;
                }
            }
            return 0;
        }
    }
}
