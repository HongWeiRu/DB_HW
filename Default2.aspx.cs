using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Sql = @"SELECT 行政區.縣市名||行政區.行政區名 行政區,COUNT(AREADATA.ID ) 土地筆數
FROM 行政區,AREADATA 
WHERE AREADATA.ID = 行政區.ID
GROUP BY 行政區.ID ,行政區.行政區名,行政區.縣市名
ORDER BY 行政區.ID";
        this.gvData.DataSource = WebApp.GetDatas(Sql);
        this.gvData.DataBind();
        ((MasterPage)this.Page.Master).IsAdminPage = true;
    }
}