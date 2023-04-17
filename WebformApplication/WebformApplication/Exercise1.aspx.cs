using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebformApplication
{
    public partial class Exercise1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // Get the file name, type, and size
            string fileName = Path.GetFileName(fileUploadControl.FileName);
            string fileExtension = Path.GetExtension(fileName).ToLower();
            int fileSize = fileUploadControl.PostedFile.ContentLength;

            // Check if the file type is allowed
            var isValidPdf = IsValidPdf (fileUploadControl.FileBytes);
            if (fileExtension != ".pdf" && !isValidPdf)
            {
                lblMessage.Text = "Only PDF files are allowed.";
                return;
            }

            // Check if the file size is within limit
            if (fileSize > 1048576)
            {
                lblMessage.Text = "File size exceed the limit of 1 MB.";
                return;
            }

            // Rename the file
            string newFileName = "Test_" + DateTime.Now.ToString("dd_MM_yyyy") + fileExtension;

            // Check if the file already exists and delete it if it does
            if (File.Exists(Server.MapPath("~/Uploads/" + newFileName)))
            {
                File.Delete(Server.MapPath("~/Uploads/" + newFileName));
            }

            // Save the file to the server
            fileUploadControl.SaveAs(Server.MapPath("~/Uploads/" + newFileName));

            lblMessage.Text = "File uploaded successfully.";
            lblMessage.ForeColor =  Color.Green;
        }
        bool IsValidPdf(byte[] bytes)
        {
            var header = new[] { bytes[0], bytes[1], bytes[2], bytes[3] };
            var isHeaderValid = header[0] == 0x25 && header[1] == 0x50 && header[2] == 0x44 && header[3] == 0x46; //%PDF
            var trailer = new[] { bytes[bytes.Length - 5], bytes[bytes.Length - 4], bytes[bytes.Length - 3], bytes[bytes.Length - 2], bytes[bytes.Length - 1] };
            var isTrailerValid = trailer[0] == 0x25 && trailer[1] == 0x25 && trailer[2] == 0x45 && trailer[3] == 0x4f && trailer[4] == 0x46; //%%EOF
            return isHeaderValid && isTrailerValid;
        }
    }
}