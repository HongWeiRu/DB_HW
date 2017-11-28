using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string PWD = this.txtPwd.Text;
        string ACCOUNT = this.txtAccount.Text;

        if (!string.IsNullOrWhiteSpace(PWD) && !string.IsNullOrWhiteSpace(ACCOUNT))
        {
            string SQL = string.Format("SELECT ACCOUNT FROM ADMIN WHERE ACCOUNT='{0}' AND PASSWORD='{1}'",
                ACCOUNT, PWD);
            if (WebApp.GetValue(SQL) == null)
                lblResult.Text = "帳號、密碼有誤!請重新輸入";
            else
                Response.Redirect("AreaData.aspx");
        }
        else
            lblResult.Text = "請輸入帳號、密碼!";
    }
}