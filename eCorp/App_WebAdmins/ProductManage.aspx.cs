using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.eCorp;
using Core.DAL;
using System.Data;
using System.Data.SqlClient;

namespace eCorp.App_WebAdmins
{
    public partial class ProductManage : System.Web.UI.Page
    {
        #region Region: Các hàm tự định nghĩa
        /// <summary>
        /// Gán dữ liệu cho GridView
        /// </summary>
        /// <param name="cateid"></param>
        private void GridView_DataBind(string cateid = "")
        {
            if (cateid == "")
            {
                gvProducts.DataSource = Products.GetAll();
                gvProducts.DataBind();
            }
            else
            {
                Products obj = new Products();
                obj.CateID = cateid;
                gvProducts.DataSource = Products.GetByCateID(obj);
                gvProducts.DataBind();
            }
            
        }
        #endregion


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                ddlCategories.DataSource = Categories.GetAll();
                ddlCategories.DataMember = "CateID";
                ddlCategories.DataValueField = "CateID";
                ddlCategories.DataTextField = "CateName";
                ddlCategories.DataBind();

                string cateid = ddlCategories.SelectedValue;
                GridView_DataBind(cateid);
            }
        }

        protected void ddlCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cateid = ddlCategories.SelectedValue;
            GridView_DataBind(cateid);
        }

        protected void gvProducts_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string ID = e.CommandArgument.ToString();

            if (e.CommandName == "Edit")
            {
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('ProductEdit.aspx?ID=" + ID + "');", true);
            }
            else if (e.CommandName == "Delete")
            {
                // Xóa
                Products obj = new Products();
                obj.ProductID = Convert.ToInt32(ID);

                Products.Delete(obj);

                // Load lại GridView
                string cateid = ddlCategories.SelectedValue;
                GridView_DataBind(cateid);
            }
        }

        protected void btnInsert1_Click(object sender, EventArgs e)
        {
            string ID = "";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", 
                "window.open('ProductEdit.aspx?ID=" + ID + "');", true);
        }

        protected void btnInsert2_Click(object sender, EventArgs e)
        {
            string ID = "";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow",
                "window.open('ProductEdit.aspx?ID=" + ID + "');", true);
        }

        protected void gvProducts_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvProducts.PageIndex = e.NewPageIndex;
            // Load lại GridView
            string cateid = ddlCategories.SelectedValue;
            GridView_DataBind(cateid);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void gvProducts_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Phải để sự kiện này không bị lỗi
            // không biết tại sao luôn
        }

        protected void gvProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}