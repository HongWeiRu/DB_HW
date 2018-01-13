using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Orgn_Area : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ddlArea.DataSource = WebApp.GetDatas("SELECT 行政區名,ID FROM 行政區 ORDER by ID");
            this.ddlArea.DataBind();
            this.ddlOrgn.DataSource = WebApp.GetDatas("SELECT * FROM 機關資料 Order By ID");
            this.ddlOrgn.DataBind();
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        string Area = this.ddlArea.SelectedValue; //管轄行政區
        string Orgn = this.ddlOrgn.SelectedValue; //機關
        try
        {
            WebApp.ExceCmd("INSERT INTO R_機關資料_行政區 VALUES(" + Orgn + ", " + Area + ")");
            lblResult.Text = Orgn + ", " + Area; 
        }
        catch (Exception ex)
        {
            lblResult.Text = "sql:" + "INSERT INTO R_機關資料_行政區 VALUES(" + Orgn + ", " + Area + ")" + ex.Message;
        }
    }
}