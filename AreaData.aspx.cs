using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin : System.Web.UI.Page
{
    private const int PageCount = 50;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.DataBind(1);
             BindPage();
        }
        ((MasterPage)this.Page.Master).IsAdminPage = true;

        if (!IsPostBack)
        {
            this.ddlArea.DataSource = WebApp.GetDatas("SELECT 行政區名,ID FROM 行政區");
            this.ddlArea.DataBind();
        }
    }


    private void DataBind(int PageNum)
    {
        string sql = @"
                SELECT ID AS 行政區,行政區名,地號,地段號,地段名稱,所有者,異動時間
                FROM (
                  SELECT t.* , rownum row_num FROM (
                       SELECT AREADATA.* ,行政區.行政區名 FROM AREADATA,行政區
                    WHERE  AREADATA.ID = 行政區.ID
                    ORDER BY 異動時間) t
                  WHERE rownum <= {1} )
                WHERE row_num >= {0}";
        this.gvData.DataSource = WebApp.GetDatas(string.Format(sql, (PageNum - 1) * PageCount + 1, PageNum * PageCount + 1));
        this.gvData.DataBind();
    }

    private void BindPage()
    {
        long DataCount = Convert.ToInt64(WebApp.GetValue("SELECT COUNT(*) FROM AREADATA"));
        int Page = Convert.ToInt32(Math.Ceiling((double)(DataCount / PageCount)));

        for (int i = 1; i <= Page; i++)
            this.ddlPageNum.Items.Add(new ListItem { Text = "第" + i + "頁", Value = i.ToString() });
    }

    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        this.ddlLot.DataSource = WebApp.GetDatas("SELECT distinct 地段名稱, 地段號 FROM AREADATA WHERE ID= " + this.ddlArea.SelectedValue);
        this.ddlLot.DataBind();
    }

    protected void btnQuery_Click(object sender, EventArgs e)
    {
        string Area = this.ddlArea.SelectedValue; //行政區ID
        string Lot = this.ddlLot.SelectedValue; //地段號

        string SQL = "INSERT INTO AREADATA VALUES('{0}','{1}','{2}',{3},'{4}','{5}') ";
        SQL = string.Format(SQL, this.ddlLot.SelectedValue, this.ddlLot.SelectedItem.Text, TextBox3.Text, "sysdate", txtArea.Text, this.ddlArea.SelectedValue);
        this.lblResult.Text = WebApp.ExceCmd(SQL).ToString();
        this.DetailsView1.DefaultMode = DetailsViewMode.ReadOnly;
        DataBind(1);
    }

    protected void ddlPageNum_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataBind(Convert.ToInt32(string.IsNullOrEmpty(this.ddlPageNum.SelectedValue) ? "0" : this.ddlPageNum.SelectedValue));
    }

    /// <summary> 【新增】
    /// </summary>
    /// <param name="sender">The source of the event.</param>
    /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
    /// <Author>Wei-Ru.Hong</Author>
    protected void btnAddData_Click(object sender, EventArgs e)
    {
        this.DetailsView1.DefaultMode = DetailsViewMode.Insert;
    }
    protected void DetailsView1_ItemInserting(object sender, DetailsViewInsertEventArgs e)
    {
        // 0地號,1地段名稱,2所有者,3異動時間,4地段號,5ID
        string SQL = "INSERT INTO AREADATA VALUES('{0}','{1}','{2}',{3},'{4}',{5}) ";
        SQL = string.Format(SQL, e.Values["地號"], e.Values["地段名稱"], e.Values["所有者"], "sysdate", e.Values["地段號"], e.Values["行政區"]);
        this.lblResult.Text = WebApp.ExceCmd(SQL).ToString();
        this.DetailsView1.DefaultMode = DetailsViewMode.ReadOnly;
        //17	仁武區	5480012	2140	仁龍段
    }
    protected void gvData_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string SQL = "DELETE AREADATA  WHERE  地號 ='{0}' AND 地段號='{1}' ";
        SQL = string.Format(SQL, e.Values["地號"],  e.Values["地段號"]);
        this.lblResult.Text = WebApp.ExceCmd(SQL).ToString();
        DataBind(1);

    }
    protected void gvData_RowEditing(object sender, GridViewEditEventArgs e)
    {


    }
    protected void gvData_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        string SQL = "SELECT AREADATA.ID 行政區, AREADATA.*,行政區.行政區名 FROM AREADATA,行政區 WHERE  AREADATA.ID = 行政區.ID AND 地號 ='{0}' AND 地段號='{1}' ";
        string AreaNum = this.gvData.Rows[e.NewSelectedIndex].Cells[3].Text; //地號
        string Area = this.gvData.Rows[e.NewSelectedIndex].Cells[4].Text; //地段號


        this.DetailsView1.DefaultMode = DetailsViewMode.Edit;
        SQL = string.Format(SQL, AreaNum, Area);
        this.DetailsView1.DataSource = WebApp.GetDatas(SQL);
        this.DetailsView1.DataBind();

        this.DetailsView1.Visible = true;
        this.ddlLot.Visible = false;
        this.TextBox3.Visible = false;
        this.txtArea.Visible = false;
        this.ddlArea.Visible = false;
        this.DetailsView1.Visible = true;
        this.test.Visible = false;

    }
    protected void DetailsView1_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        this.DetailsView1.DefaultMode = DetailsViewMode.ReadOnly;
    }
    protected void DetailsView1_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
            string SQL = "UPDATE AREADATA SET 地號='{0}',地段名稱='{1}',所有者='{2}',異動時間={3},地段號='{4}' WHERE 地號='{0}' AND 地段號='{4}'  ";
        try
        {
            SQL = string.Format(SQL, e.NewValues["地號"], e.NewValues["地段名稱"], e.NewValues["所有者"], "sysdate", e.NewValues["地段號"]
                , e.NewValues["行政區"]);
            this.lblResult.Text = WebApp.ExceCmd(SQL).ToString();
            this.DetailsView1.Visible = false;
            this.DetailsView1.DefaultMode = DetailsViewMode.ReadOnly;
            DataBind(1);
        }
        catch (Exception ex)
        {
            lblResult.Text = SQL;

        }
    }
}