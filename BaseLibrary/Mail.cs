using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace BaseLibrary
{
    /// <summary>
    /// Class with mail functions
    /// </summary>
    public class Mail
    {
        static string yourDomain = System.Configuration.ConfigurationManager.AppSettings["YourDomain"].ToString(),
                      smptHost = System.Configuration.ConfigurationManager.AppSettings["SmptHost"].ToString();
            

        /// <summary>
        /// Send the error to System admins
        /// <para>
        /// It needs an appSetting with the key "SystemAdminsMail" to get the systems mails, it must not contains the yourDomain part
        /// </para>
        /// </summary>
        /// <param name="body">The body of the mail, it can be HTML sytax</param>
        /// <returns>True if was correctly sent, false if not</returns>
        public static bool sendError(string body)
        {
            return send(System.Configuration.ConfigurationManager.AppSettings["SystemAdminsMail"].ToString(),
                    "Error en sistema",
                    body);
        }

        /// <summary>
        /// Send a mail to N users
        /// <para>The "From" field is going to be fill with the AppSetting value of "SystemName" + @yourDomain.com</para>
        /// </summary>
        /// <param name="to">Users to receive the mail, it must not contains the yourDomain string</param>
        /// <param name="subject">Text to display in the "subject" field</param>
        /// <param name="body">The body of the message, it can contains HTML syntax</param>
        /// <returns>True if the mail was sent correctly, false other way</returns>
        public static bool send(List<string> to, string subject, string body)
        {
            return send(string.Join(",", to.Select(x => x + yourDomain).ToArray()), subject, body);
        }
        /// <summary>
        /// Send a mail to N users
        /// </summary>
        /// <param name="to">Users to receive the mail, it must not contains the yourDomain string</param>
        /// <param name="subject">Text to display in the "subject" field</param>
        /// <param name="body">The body of the message, it can contains HTML syntax</param>
        /// <param name="from">Mail address to display in the "form" field, it must be correctly spelled</param>
        /// <returns>True if the mail was sent correctly, false other way</returns>
        public static bool send(List<string> to, string subject, string body, string from)
        {
            return send(string.Join(",", to.Select(x => x + yourDomain).ToArray()), subject, body, from);
        }
        /// <summary>
        /// Send a mail to N users
        /// <para>The "From" field is going to be fill with the AppSetting value of "SystemName" + @yourDomain.com</para>
        /// </summary>
        /// <param name="to">Users to receive the mail, it must not contains the yourDomain string</param>
        /// <param name="subject">Text to display in the "subject" field</param>
        /// <param name="body">The body of the message, it can contains HTML syntax</param>
        /// <returns>True if the mail was sent correctly, false other way</returns>
        public static bool send(string[] to, string subject, string body)
        {
            return send(string.Join(",", to.Select(x => x + yourDomain).ToArray()), subject, body);
        }
        /// <summary>
        /// Send a mail to N users
        /// </summary>
        /// <param name="to">Users to receive the mail, it must not contains the yourDomain string</param>
        /// <param name="subject">Text to display in the "subject" field</param>
        /// <param name="body">The body of the message, it can contains HTML syntax</param>
        /// <param name="from">Mail address to display in the "form" field, it must be correctly spelled</param>
        /// <returns>True if the mail was sent correctly, false other way</returns>
        public static bool send(string[] to, string subject, string body, string from)
        {
            return send(string.Join(",", to.Select(x => x + yourDomain).ToArray()), subject, body, from);
        }
        /// <summary>
        /// Send a mail to N users
        /// <para>The "From" field is going to be fill with the AppSetting value of "SystemName" + @yourDomain.com</para>
        /// </summary>
        /// <param name="to">Users to receive the mail, each address must contains the yourDomain string</param>
        /// <param name="subject">Text to display in the "subject" field</param>
        /// <param name="body">The body of the message, it can contains HTML syntax</param>
        /// <returns>True if the mail was sent correctly, false other way</returns>
        public static bool send(string to, string subject, string body)
        {
            return send(to, subject, body, System.Configuration.ConfigurationManager.AppSettings["SystemName"].ToString() + yourDomain);
        }
        /// <summary>
        /// Send a mail to N users
        /// </summary>
        /// <param name="to">Users to receive the mail, each address must contains the yourDomain string</param>
        /// <param name="subject">Text to display in the "subject" field</param>
        /// <param name="body">The body of the message, it can contains HTML syntax</param>
        /// <param name="from">Mail address to display in the "form" field, it must be correctly spelled</param>
        /// <returns>True if the mail was sent correctly, false other way</returns>
        public static bool send(string to, string subject, string body, string from)
        {
            try
            {
                MailMessage eMail = new MailMessage();
                eMail.From = new MailAddress(from);
                eMail.To.Add(to);
                eMail.Subject = subject;
                eMail.Body = body;
                eMail.IsBodyHtml = true;
                eMail.Priority = MailPriority.High;
                new SmtpClient { Host = smptHost }.Send(eMail);
            }
            catch { return false; }
            return true;
        }
        
    }

    /// <summary>
    /// Extension methods to show JS alerts, format strings, log errors, etc.
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Send a mail to system admins with the error body and the trace
        /// </summary>
        public static void logThisException(this Exception ex)
        {
            string body = DateTime.Now.ToShortDateString().ToString() + " " + DateTime.Now.ToLongTimeString().ToString() + " ==> \n";
            body += "Error: " + ex.ToString() + "\n";
            body += "Message: " + ex.Message + "\n";
            body += "InnerException: " + ex.InnerException + "\n";
            body += "Source: " + ex.Source + "\n";
            body += "TargetSite: " + ex.TargetSite + "\n";
            body += "StackTrace: " + ex.StackTrace + "\n\n\n\n";
            Mail.sendError(body);
        }
    }
}
