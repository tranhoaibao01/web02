using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.eCorp;

namespace eCorp.App_WebAdmins
{
    public partial class ContactManage : System.Web.UI.Page
    {
        #region Region: Các hàm tự định nghĩa
        /// <summary>
        /// Lấy dữ liệu lên GridView gvDescription
        /// </summary>
        private void gView_Binding()
        {
            gView.DataSource = Contacts.GetAll();
            gView.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            // Tiêu đề trang
            this.Page.Title = "Quản trị danh mục thể loại";

            // Khởi tạo control
            if (!IsPostBack)
            {
                gView_Binding();
            }
        }

        protected void gView_RowEditing(object sender, GridViewEditEventArgs e)
        {
            // Cái thằng này không dùng làm gì
            // nhưng không được bỏ
        }

        protected void gView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();

            if (e.CommandName == "btnEdit")
            {
                // Sửa
                ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow",
                    "window.open('ContactEdit.aspx?ID=" + id + "');", true);
            }
            else if (e.CommandName == "btnDelete")
            {
                // Xóa
                Contacts _obj = new Contacts();
                _obj.ContactID = Convert.ToInt32(id);

                Contacts.Delete(_obj);

                // Load lại dữ liệu
                gView_Binding();
            }
        }

        protected void btnInsert1_Click(object sender, EventArgs e)
        {
            string idValue = "";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow",
                "window.open('ContactEdit.aspx?ID=" + idValue + "');", true);
        }

        protected void btnInsert2_Click(object sender, EventArgs e)
        {
            string idValue = "";
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow",
                "window.open('ContactEdit.aspx?ID=" + idValue + "');", true);
        }
    }
}