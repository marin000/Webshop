using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Pages_Success : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Cart> carts = (List<Cart>)Session[User.Identity.GetUserId()];

        CartModel model = new CartModel();
        model.MarkOrderAsPaid(carts);
        Session[User.Identity.GetUserId()] = null;

        string userId = User.Identity.GetUserId();
        UserInfoModel info = new UserInfoModel();

        string email = info.GetUserInformatio(userId).Email.ToString();
        string fname = info.GetUserInformatio(userId).FirstName.ToString();
        string lname = info.GetUserInformatio(userId).LastName.ToString();

        try
        {
            var fromAddress = new MailAddress("marinb997@gmail.com", "TechShop");
            var toAddress = new MailAddress(email, fname+lname);
            const string fromPassword = "brazuka2014";
            const string subject = "TechShop";
            const string body = "Thank you for shopping. Your order is charged.";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 25,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
            litName.Text = "Mail sent successfully. Check your mail box. ";
        }
        catch (Exception ex)
        {
            litName.Text = (ex.ToString());

        }

}
}