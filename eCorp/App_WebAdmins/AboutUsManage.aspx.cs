using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.GlobalObjects;
using BAL.eCorp;

namespace eCorp.App_WebAdmins
{
    public partial class AboutUsManage : System.Web.UI.Page
    {
        #region Region: Các hàm tự định nghĩa
        /// <summary>
        /// Lấy dữ liệu lên GridView gvDescription
        /// </summary>
        private void gView_Binding()
        {
            gView.DataSource = AboutUs.GetAll();
            gView.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                gView_Binding();
            }
        }

        protected void btnInsert1_Click(object sender, EventArgs e)
        {
            string idValue = "";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow",
                "window.open('AboutUsEdit.aspx?ID=" + idValue + "');", true);
        }

        protected void btnInsert2_Click(object sender, EventArgs e)
        {
            string idValue = "";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow",
                "window.open('AboutUsEdit.aspx?ID=" + idValue + "');", true);
        }

        protected void gView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string idValue = e.CommandArgument.ToString();

            if (e.CommandName == "btnInsert")
            {
                // Hiện tại không dùng cái này
                // Thêm
                idValue = "";
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow",
                    "window.open('AboutUsEdit.aspx?ID=" + idValue + "');", true);
            }
            else if (e.CommandName == "btnEdit")
            {
                // Sửa
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow",
                    "window.open('AboutUsEdit.aspx?ID=" + idValue + "');", true);
            }
            else if (e.CommandName == "btnDelete")
            {
                // Xóa
                AboutUs obj = new AboutUs();
                obj.IntroID = Convert.ToInt32(idValue);

                AboutUs.Delete(obj);

                // Load lại dữ liệu
                gView_Binding();
            }
        }

        protected void gView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Phải để sự kiện này không bị lỗi
            // không biết tại sao luôn
        }
    }
}