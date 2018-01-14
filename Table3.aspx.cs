using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Table3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Sql = @"SELECT VEWTABLE3.* FROM VEWTABLE3";
        this.gvData.DataSource = WebApp.GetDatas(Sql);
        this.gvData.DataBind();
        ((MasterPage)this.Page.Master).IsAdminPage = true;

    }
}