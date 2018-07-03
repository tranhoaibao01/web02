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
    public partial class CategoriesEdit : System.Web.UI.Page
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
                if (M_Mode.Mode == Modes.EDIT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "Cập nhập danh mục thể loại";
                    this.lbModeMessage.Text = "Cập nhập danh mục thể loại";

                    // Gán ID
                    this.txtCateID.Text = ID;

                    // Gán giá trị lên các control nhập liệu
                    Categories _obj = new Categories();
                    _obj.CateID = ID;
                    _obj = Categories.GetByID(_obj);


                    //Khởi gán giá trị cho ddlParentId
                    if (_obj.Level > 0)
                    {
                        ddlParentId.DataSource = Categories.GetAll();
                        ddlParentId.DataMember = "ID";
                        ddlParentId.DataValueField = "ID";
                        ddlParentId.DataTextField = "CateName";
                        ddlParentId.DataBind();
                    }
                    else
                    {
                        ddlParentId.DataSource = null;
                        ddlParentId.Items.Clear();
                        ddlParentId.Enabled = false;
                    }

                    this.txtID.Text = _obj.ID.ToString();
                    this.txtCateID.Text = _obj.CateID;
                    this.txtCateName.Text = _obj.CateName;
                    this.txtImageURL.Text = _obj.ImageURL;
                    this.imgImageURL.ImageUrl = _obj.ImageURL;
                    this.txtCatePos.Text = _obj.CatePos.ToString();
                    this.ddlLevel.SelectedValue = _obj.Level.ToString();
                    if (_obj.Level > 0)
                        this.ddlParentId.SelectedValue = _obj.ParentID.ToString();

                    // Khởi tạo control
                    this.txtCateID.Enabled = false;
                }
                else if (M_Mode.Mode == Modes.INSERT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "Thêm mới danh mục thể loại";
                    this.lbModeMessage.Text = "Thêm mới danh mục thể loại";

                    ddlLevel.SelectedIndex = 0;
                    ddlParentId.DataSource = null;
                    ddlParentId.Items.Clear();
                    ddlParentId.Enabled = false;
                }
            }
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
                    string strImagePath = Server.MapPath("~/Images/Categories/" + fulImageURL.FileName);
                    fulImageURL.SaveAs(strImagePath);
                    txtImageURL.Text = "~/Images/Categories/" + fulImageURL.FileName.ToString();
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
            Categories _obj = new Categories();

            if (M_Mode.Mode == Modes.EDIT)
                _obj.ID = Convert.ToInt32(this.txtID.Text);
            if (this.ddlParentId.SelectedValue != "")
                _obj.ParentID = Convert.ToInt32(this.ddlParentId.SelectedValue);
            else _obj.ParentID = 0;
            _obj.Level = Convert.ToInt32(this.ddlLevel.SelectedValue);
            _obj.CateID = this.txtCateID.Text == "" ? "0" : this.txtCateID.Text;
            _obj.CateName = this.txtCateName.Text;
            _obj.ImageURL = this.txtImageURL.Text;
            _obj.CatePos = Convert.ToInt32(this.txtCatePos.Text);
            _obj.CreateDate = DateTime.Now;
            _obj.CreateUser = "Admin";
            _obj.EditDate = DateTime.Now;
            _obj.EditUser = "Admin";

            // Lưu xuống dữ liệu
            if (M_Mode.Mode == Modes.EDIT)
            {
                Categories.Update(_obj);
            }
            else if (M_Mode.Mode == Modes.INSERT)
            {
                Categories.Insert(_obj);
            }

            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\CategoriesManage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\CategoriesManage.aspx");
        }

        protected void ddlLevel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlLevel.SelectedValue == "0")
            {
                ddlParentId.DataSource = null;
                ddlParentId.Items.Clear();
                ddlParentId.Enabled = false;
            }
            else
            {
                ddlParentId.Enabled = true;
                ddlParentId.DataSource = Categories.GetAll();
                ddlParentId.DataMember = "ID";
                ddlParentId.DataValueField = "ID";
                ddlParentId.DataTextField = "CateName";
                ddlParentId.DataBind();
                
            }
        }
    }
}