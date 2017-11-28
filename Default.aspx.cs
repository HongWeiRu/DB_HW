using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ddlArea.DataSource = WebApp.GetDatas("SELECT 行政區名,ID FROM 行政區");
            this.ddlArea.DataBind();
        }
    }


    /// <summary>【查詢】
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <Author>Wei-Ru.Hong</Author>
    protected void btnQuery_Click(object sender, EventArgs e)
    {
        string Area = this.ddlArea.SelectedValue; //行政區ID
        string Lot = this.ddlLot.SelectedValue; //地段號
        string AreaNumb = this.ddlAreaNumb.SelectedValue; //地號
        string SqlCmd = "";

        SqlCmd = string.Format("SELECT 年度,價值 FROM 公告現值 WHERE 地段號={0} AND 地號={1}", Lot, AreaNumb);
        this.gvValues.DataSource = WebApp.GetDatas(SqlCmd);
        this.gvValues.DataBind();

        SqlCmd = string.Format("SELECT D.類別 AS 機關,D.名稱,D.地址,D.聯絡資訊 FROM R_機關資料_行政區 R,機關資料 D WHERE R.機關ID=D.機關ID AND R.ID={0}", Area);
        this.gvOrgan.DataSource = WebApp.GetDatas(SqlCmd);
        this.gvOrgan.DataBind();

        SqlCmd = "SELECT  ROUND( AVG (價值),2) 價值 FROM 公告現值 V,AREADATA A WHERE V.地號 =A.地號 AND  V.地段號 =A.地段號 AND A.ID = " + Area;
        lblResult.Text = string.Format("該行政區平均公告現值：{0}", WebApp.GetValue(SqlCmd));
    }

    /// <summary> [區]
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <Author>Wei-Ru.Hong</Author>
    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlLot.DataSource = WebApp.GetDatas("SELECT distinct 地段名稱, 地段號 FROM AREADATA WHERE ID= " + this.ddlArea.SelectedValue);
        this.ddlLot.DataBind();
    }

    /// <summary> [段]
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <Author>Wei-Ru.Hong</Author>
    protected void ddlLot_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlAreaNumb.DataSource = WebApp.GetDatas("SELECT 地號 FROM AREADATA WHERE 地段號= " + this.ddlLot.SelectedValue);
        this.ddlAreaNumb.DataBind();
    }
}