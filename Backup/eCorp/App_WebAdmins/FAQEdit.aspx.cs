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
    public partial class FAQEdit : System.Web.UI.Page
    {
        Modes M_Mode = new Modes();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Lấy giá trị tham số ID
            string ID = Request.QueryString["ID"].ToString();

            // Gán giá trị cho Mode
            if (string.IsNullOrEmpty(ID)) M_Mode.Mode = Modes.INSERT;
            else M_Mode.Mode = Modes.EDIT;

            if (!IsPostBack)
            {
                // Khởi tạo control
                this.txtFaqId.Enabled = false;

                if (M_Mode.Mode == Modes.EDIT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "Cập nhập danh mục FAQ";
                    this.lbModeMessage.Text = "Cập nhập danh mục FAQ";

                    // Gán ID
                    this.txtFaqId.Text = ID;

                    // Gán giá trị lên các control nhập liệu
                    FAQs _obj = new FAQs();
                    _obj.FAQID = Convert.ToInt32(ID);
                    _obj = FAQs.GetByID(_obj);

                    this.txtFaqId.Text = _obj.FAQID.ToString();
                    this.txtTitle.Text = _obj.Title;
                    this.ckEditor.Text = _obj.Description;

                }
                else if (M_Mode.Mode == Modes.INSERT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "Thêm mới danh mục FAQ";
                    this.lbModeMessage.Text = "Thêm mới danh mục FAQ";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy giá trị
            FAQs _obj = new FAQs();
            _obj.FAQID = this.txtFaqId.Text == "" ? 0 : Convert.ToInt32(this.txtFaqId.Text);
            _obj.Title = this.txtTitle.Text;
            _obj.Description = this.ckEditor.Text;
            _obj.CreateDate = DateTime.Now;
            _obj.CreateUser = "Admin";
            _obj.EditDate = DateTime.Now;
            _obj.EditUser = "Admin";

            // Lưu xuống dữ liệu
            if (M_Mode.Mode == Modes.EDIT)
            {
                FAQs.Update(_obj);
            }
            else if (M_Mode.Mode == Modes.INSERT)
            {
                FAQs.Insert(_obj);
            }

            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\FAQManage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\FAQManage.aspx");
        }
    }
}