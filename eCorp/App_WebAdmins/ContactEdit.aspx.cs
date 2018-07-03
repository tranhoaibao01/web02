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
    public partial class ContactEdit : System.Web.UI.Page
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
                this.txtContactID.Enabled = false;

                if (M_Mode.Mode == Modes.EDIT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "";
                    this.lbModeMessage.Text = "";

                    // Gán ID
                    this.txtContactID.Text = ID;

                    // Gán giá trị lên các control nhập liệu
                    Contacts _obj = new Contacts();
                    _obj.ContactID = Convert.ToInt32(ID);
                    _obj = Contacts.GetByID(_obj);

                    this.txtContactID.Text = _obj.ContactID.ToString();
                    this.txtFullName.Text = _obj.FullName;
                    this.txtAddress.Text = _obj.Address;
                    this.txtPhone.Text = _obj.Phone;
                    this.txtEmail.Text = _obj.Email;
                    this.txtSubject.Text = _obj.Subject;
                    this.txtIpClient.Text = _obj.IPClient;
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
            Contacts _obj = new Contacts();
            _obj.ContactID = this.txtContactID.Text == "" ? 0 : Convert.ToInt32(this.txtContactID.Text);
            _obj.FullName = this.txtFullName.Text;
            _obj.Address = this.txtAddress.Text;
            _obj.Phone = this.txtPhone.Text;
            _obj.Email = this.txtEmail.Text;
            _obj.Subject = this.txtSubject.Text;
            _obj.IPClient = this.txtIpClient.Text;
            _obj.Contents = this.ckEditor.Text;

            _obj.CreateDate = DateTime.Now;
            _obj.CreateUser = "Admin";
            _obj.EditDate = DateTime.Now;
            _obj.EditUser = "Admin";

            // Lưu xuống dữ liệu
            if (M_Mode.Mode == Modes.EDIT)
            {
                Contacts.Update(_obj);
            }
            else if (M_Mode.Mode == Modes.INSERT)
            {
                Contacts.Insert(_obj);
            }

            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\ContactManage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\ContactManage.aspx");
        }
    }
}