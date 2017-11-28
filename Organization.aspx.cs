using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Organization : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ((MasterPage)this.Page.Master).IsAdminPage = true;


    }
    
    protected void gvData_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string AreaNum = this.gvData.Rows[e.NewSelectedIndex].Cells[1].Text; //id
        string SQL = "SELECT A.* FROM 行政區 A,R_機關資料_行政區 R WHERE A.ID = R.ID AND R.機關ID=" + AreaNum;
        this.GridView1.DataSource = WebApp.GetDatas(SQL);
        this.GridView1.DataBind();

        this.DetailsView1.DefaultMode = DetailsViewMode.Insert;
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        this.DetailsView1.DataSource = null;
        this.DetailsView1.DefaultMode = DetailsViewMode.Insert;
    }
    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        this.DetailsView1.DefaultMode = DetailsViewMode.ReadOnly;
    }
    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {

        string ID = WebApp.GetValue("SELECT MAX(機關ID)+1 FROM 機關資料 ").ToString();
        string SQL = " INSERT INTO 機關資料 ( 機關ID, 名稱, 類別, 地址, 聯絡資訊 ) VALUES ( {0}, '{1}', '{2}', '{3}', '{4}' );  ";
        try { 
        SQL = string.Format(SQL, ID, e.Values["名稱"], e.Values["類別"], e.Values["地址"], e.Values["聯絡資訊"]);
        WebApp.ExceCmd(SQL);
        this.DetailsView1.DefaultMode = DetailsViewMode.ReadOnly;
            }
        catch (Exception ex)
        {
            lblResult.Text = SQL+ ex.Message;
        }
       
    }
}