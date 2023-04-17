using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebformApplication.Common
{
   public class ApplicationConstant
    {
        #region Email Server Credentials
        public static string EmailFrom = ConfigurationManager.AppSettings["EmailFrom"].ToString();
        public static string EmailUserName = ConfigurationManager.AppSettings["EmailUserName"].ToString();
        public static string EmailPassword = ConfigurationManager.AppSettings["EmailPassword"].ToString();
        public static int EmailPort = Convert.ToInt32(ConfigurationManager.AppSettings["EmailPort"].ToString());
        public static string SMPTServerAddress = ConfigurationManager.AppSettings["SMPTServerAddress"].ToString(); 
        #endregion
        public const string EmailSubject = "Information recieved ackowledgment";

    }
}
