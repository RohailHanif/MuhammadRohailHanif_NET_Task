using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebformApplication.Common;
using WebformApplication.Common.Helper;

namespace WebformApplication
{
    public partial class Exercise2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                 LoadUserData();
            }
        }
        private void LoadUserData()
        {
            List<User> userData = Session["UserData"] as List<User> ?? new List<User>();
            gvUserData.DataSource = userData;
            gvUserData.DataBind();
        }
        private void formReset() { txtName.Text = ""; txtEmail.Text = ""; txtPhone.Text = ""; txtTravelLocationDetails.Text = "";  ddlTravelMethod.SelectedIndex = 0; }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                List<User> userData = Session["UserData"] as List<User> ?? new List<User>();
                userData.Add(new User { Name = txtName.Text, Email = txtEmail.Text, Phone = txtPhone.Text, TravelMethod = ddlTravelMethod.SelectedItem.Text, TravelLocationDetails = txtTravelLocationDetails.Text });
                Session["UserData"] = userData;
                LoadUserData();
                try
                {
                    lblMessage.Text= EmailHelper.sendHtmlFormattedEmail(txtName.Text, txtEmail.Text, ApplicationConstant.EmailSubject);
                    lblMessage.ForeColor = Color.Green;

                }
                catch (Exception ex)
                {

                    lblMessage.Text = ex.Message;
                    lblMessage.ForeColor = Color.Red;
                }
                formReset();
            }

        }

        
    }
}