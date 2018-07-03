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
    public partial class AboutUsEdit : System.Web.UI.Page
    {
        Modes M_Mode = new Modes();

        protected void Page_Load(object sender, EventArgs e)
        {
            // Lấy tham số
            string ID = Request.QueryString["ID"].ToString();
            // Gán Mode: mã để trống-thêm mới, có mã-Chỉnh sửa
            if (ID == "") M_Mode.Mode = Modes.INSERT;
            else M_Mode.Mode = Modes.EDIT;

            if (!IsPostBack)
            {
                // Khởi tạo control
                this.txtIntroID.Enabled = false;

                // Lấy giá trị ban đầu
                if (M_Mode.Mode == Modes.EDIT)
                {
                    this.Page.Title = "Cập nhập nội dung giới thiệu";
                    this.lbModeMessage.Text = "Cập nhập nội dung giới thiệu";

                    // Gán ID
                    this.txtIntroID.Text = ID;

                    // Lấy giá trị cho các control
                    AboutUs _obj = new AboutUs();
                    _obj.IntroID = Convert.ToInt32(this.txtIntroID.Text);

                    _obj = AboutUs.GetByID(_obj);

                    this.ckeDescription.Text = _obj.Description;
                    this.chkActive.Checked = _obj.Active;
                }
                else if (M_Mode.Mode == Modes.INSERT)
                {
                    this.Page.Title = "Thêm mới nội dung giới thiệu";
                    this.lbModeMessage.Text = "Thêm mới nội dung giới thiệu";
                    this.ckeDescription.Text = "";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy giá trị
            AboutUs _obj = new AboutUs();
            _obj.IntroID = this.txtIntroID.Text == "" ? 0 : Convert.ToInt32(this.txtIntroID.Text);
            _obj.Description = this.ckeDescription.Text;
            _obj.Active = this.chkActive.Checked;
            _obj.CreateDate = DateTime.Now;
            _obj.CreateUser = "Admin";
            _obj.EditDate = DateTime.Now;
            _obj.EditUser = "Admin";

            // Xóa Active đang tồn tại nếu Active Edit = True
            // đảm bảo chỉ cho một nội dụng được Active
            if (_obj.Active == true)
                AboutUs.ResetActive();

            // Lưu xuống dữ liệu
            if (M_Mode.Mode == Modes.EDIT)
            {
                AboutUs.Update(_obj);
            }
            else if (M_Mode.Mode == Modes.INSERT)
            {
                AboutUs.Insert(_obj);
            }

            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\AboutUsManage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\AboutUsManage.aspx");
        }
    }
}