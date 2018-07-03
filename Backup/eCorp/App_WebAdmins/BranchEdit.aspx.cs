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
    public partial class BranchEdit : System.Web.UI.Page
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
                this.txtBranchID.Enabled = false;

                if (M_Mode.Mode == Modes.EDIT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "";
                    this.lbModeMessage.Text = "";

                    // Gán ID
                    this.txtBranchID.Text = ID;

                    // Gán giá trị lên các control nhập liệu
                    Branchs _obj = new Branchs();
                    _obj.BranchID = Convert.ToInt32(ID);
                    _obj = Branchs.GetByID(_obj);

                    this.txtBranchID.Text = _obj.BranchID.ToString();
                    this.txtFullName.Text = _obj.FullName;
                    this.imgImageURL.ImageUrl = _obj.ImageUrl;
                    this.txtImageURL.Text = _obj.ImageUrl;
                    this.txtAddress.Text = _obj.Address;
                    this.txtPhone.Text = _obj.Phone;
                    this.txtMobile.Text = _obj.Mobile;
                    this.txtFax.Text = _obj.Fax;
                    this.txtEmail.Text = _obj.Email;
                    this.txtWebSite.Text = _obj.WebSite;
                    this.ckEditor.Text = _obj.Contents;

                }
                else if (M_Mode.Mode == Modes.INSERT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "Thêm mới thông tin liên hệ";
                    this.lbModeMessage.Text = "Thêm mới thông tin liên hệ";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy giá trị
            Branchs _obj = new Branchs();
            _obj.BranchID = this.txtBranchID.Text == "" ? 0 : Convert.ToInt32(this.txtBranchID.Text);
            _obj.FullName = this.txtFullName.Text;
            _obj.ImageUrl = this.txtImageURL.Text;
            _obj.Address = this.txtAddress.Text;
            _obj.Phone = this.txtPhone.Text;
            _obj.Fax = this.txtFax.Text;
            _obj.Email = this.txtEmail.Text;
            _obj.WebSite = this.txtWebSite.Text;
            _obj.Contents = this.ckEditor.Text;

            _obj.CreateDate = DateTime.Now;
            _obj.CreateUser = "Admin";
            _obj.EditDate = DateTime.Now;
            _obj.EditUser = "Admin";

            // Lưu xuống dữ liệu
            if (M_Mode.Mode == Modes.EDIT)
            {
                Branchs.Update(_obj);
            }
            else if (M_Mode.Mode == Modes.INSERT)
            {
                Branchs.Insert(_obj);
            }

            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\BranchManage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\BranchManage.aspx");
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = fulImageURL.PostedFile;
            if (fulImageURL.HasFile == false && file.ContentLength > 500000)
            {
                this.lbImageUrlMessage.Text = "Please try again.";
            }
            else
            {
                try
                {
                    string strImagePath = Server.MapPath("~/Images/Branchs/" + fulImageURL.FileName);
                    fulImageURL.SaveAs(strImagePath);
                    txtImageURL.Text = "~/Images/Branchs/" + fulImageURL.FileName.ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}