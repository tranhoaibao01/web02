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
    public partial class LinkEdit : System.Web.UI.Page
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
                this.txtLinkID.Enabled = false;

                if (M_Mode.Mode == Modes.EDIT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "Cập nhập danh mục thể loại";
                    this.lbModeMessage.Text = "Cập nhập danh mục thể loại";

                    // Gán ID
                    this.txtLinkID.Text = ID;

                    // Gán giá trị lên các control nhập liệu
                    Links _obj = new Links();
                    _obj.LinkID = Convert.ToInt32(ID);
                    _obj = Links.GetByID(_obj);

                    this.txtLinkID.Text = _obj.LinkID.ToString();
                    this.txtLinkName.Text = _obj.LinkName;
                    this.txtURL.Text = _obj.URL;
                    this.txtPos.Text = _obj.Pos.ToString();
                    this.imgLogo.ImageUrl = _obj.Logo;
                    this.txtLogo.Text = _obj.Logo;
                }
                else if (M_Mode.Mode == Modes.INSERT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "Thêm mới danh mục thể loại";
                    this.lbModeMessage.Text = "Thêm mới danh mục thể loại";
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = this.fulLogo.PostedFile;
            if (fulLogo.HasFile == false && file.ContentLength > 500000)
            {
                this.lbLogoMessage.Text = "Please try again.";
            }
            else
            {
                try
                {
                    string strImagePath = Server.MapPath("~/Images/Links/" + fulLogo.FileName);
                    fulLogo.SaveAs(strImagePath);
                    this.txtLogo.Text = "~/Images/Links/" + fulLogo.FileName.ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy giá trị
            Links _obj = new Links();
            _obj.LinkID = this.txtLinkID.Text == "" ? 0 : Convert.ToInt32(this.txtLinkID.Text);
            _obj.LinkName = this.txtLinkName.Text;
            _obj.URL = this.txtURL.Text;
            _obj.Pos = Convert.ToInt32(this.txtPos.Text);
            _obj.Logo = this.txtLogo.Text;
            _obj.CreateDate = DateTime.Now;
            _obj.CreateUser = "Admin";
            _obj.EditDate = DateTime.Now;
            _obj.EditUser = "Admin";

            // Lưu xuống dữ liệu
            if (M_Mode.Mode == Modes.EDIT)
            {
                Links.Update(_obj);
            }
            else if (M_Mode.Mode == Modes.INSERT)
            {
                Links.Insert(_obj);
            }

            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\LinkManage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\LinkManage.aspx");
        }
    }
}