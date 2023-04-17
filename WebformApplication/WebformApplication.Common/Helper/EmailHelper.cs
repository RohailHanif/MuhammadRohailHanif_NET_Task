using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace WebformApplication.Common.Helper
{
   public static class EmailHelper
    {
        public static string sendHtmlFormattedEmail(String recepientName, String recepientEmail, String subject)
        {
            try
            {
                var body = $"<h1>Hi {recepientName}</h1>,<br> your information saved in local memory system.";
                MailMessage mailMessage = new MailMessage();
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(new MailAddress(recepientEmail, recepientName));
                mailMessage.From = (new MailAddress(ApplicationConstant.EmailFrom));


                var smtpClient = new SmtpClient(ApplicationConstant.SMPTServerAddress)
                {
                    Port = ApplicationConstant.EmailPort,
                    Credentials = new NetworkCredential(ApplicationConstant.EmailUserName, ApplicationConstant.EmailPassword),
                    EnableSsl = true,
                };
                smtpClient.Send(mailMessage);

                return UserMessageConstants.SuccessfullyEmailSent;

            }
            catch (IOException)
            {
                throw new ArgumentException(UserMessageConstants.ErrorSendingEmailMsg);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static void sendEmail(ref MailMessage mailMessage)
        {
            SmtpClient smtp = new SmtpClient();
            smtp.Send(mailMessage);
        }
    }
}