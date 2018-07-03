using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.eCorp;
using Core.GlobalObjects;

namespace eCorp.App_WebAdmins
{
    public partial class ProductEdit : System.Web.UI.Page
    {
        Modes M_Mode = new Modes();

        protected void Page_Load(object sender, EventArgs e)
        {
            string ID = Request.QueryString["ID"].ToString();

            // Gán Mode: mã để trống-thêm mới, có mã-Chỉnh sửa
            if (string.IsNullOrEmpty(ID))
                M_Mode.Mode = Modes.INSERT;
            else
                M_Mode.Mode = Modes.EDIT;

            if (!IsPostBack)
            {
                // Dùng cách gọi page Edit và truyền tham số trong nút Edit
                this.txtProductID.Text = ID;

                // Khởi tạo các controls
                this.txtProductID.Enabled = false;

                this.ddlCategories.DataSource = Categories.GetAll();
                this.ddlCategories.DataMember = "CateID";
                this.ddlCategories.DataValueField = "CateID";
                this.ddlCategories.DataTextField = "CateName";
                this.DataBind();
                if (this.ddlCategories.Items.Count > 0)
                    this.ddlCategories.SelectedIndex = 0;

                // Gán dữ liệu cho mode Edit
                if (M_Mode.Mode == Modes.EDIT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "Cập nhập sản phẩm";
                    this.lbModeMessage.Text = "Cập nhập sản phẩm";

                    //
                    Products obj = new Products();
                    obj.ProductID = Convert.ToInt32(this.txtProductID.Text);
                    obj = Products.GetByID(obj);
                    this.txtProductID.Text = obj.ProductID.ToString();
                    this.txtProductTitle.Text = obj.ProductTitle;
                    this.ddlCategories.SelectedValue = obj.CateID;
                    this.txtImageURL.Text = obj.ImageUrl;
                    this.imgImageURL.ImageUrl = obj.ImageUrl;
                    this.ckeDescription.Text = obj.Description;
                }
                else if (M_Mode.Mode == Modes.INSERT)
                {
                    this.Page.Title = "Cập nhập sản phẩm";
                    this.lbModeMessage.Text = "Thêm mới sản phẩm";
                }
            }
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            HttpPostedFile file = fulImageURL.PostedFile;
            if (fulImageURL.HasFile == false && file.ContentLength > 500000)
            {
                lbImageUrlMess.Text = "Please try again.";
            }
            else
            {
                try
                {
                    string strImagePath = Server.MapPath("~/Images/Products/" + fulImageURL.FileName);
                    fulImageURL.SaveAs(strImagePath);
                    txtImageURL.Text = "~/Images/Products/" + fulImageURL.FileName.ToString();
                }
                catch (Exception ex) 
                {
                    throw ex;
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Khởi tạo giá trị
            Products _object = new Products();
            
            // Lấy giá trị
            if (M_Mode.Mode == Modes.EDIT)
                _object.ProductID = Convert.ToInt32(this.txtProductID.Text);
            _object.ProductTitle = txtProductTitle.Text;
            _object.CateID = ddlCategories.SelectedValue;
            if (txtImageURL.Text == "") _object.ImageUrl = "No Logo";
            else _object.ImageUrl = txtImageURL.Text;
            _object.Description = this.ckeDescription.Text;

            if (M_Mode.Mode == Modes.INSERT)
            {
                Products.Insert(_object);
            }
            else if (M_Mode.Mode == Modes.EDIT)
            {
                Products.Update(_object);
            }
            // Khởi tạo
            //this.txtProductID.Text = "";
            txtProductTitle.Text = "";
            //ddlCategories
            txtImageURL.Text = "";
            ckeDescription.Text = "";
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            // Khởi tạo
            this.txtProductID.Text = "";
            txtProductTitle.Text = "";
            if (ddlCategories.Items.Count > 0)
                ddlCategories.SelectedIndex = 0;
            txtImageURL.Text = "";
            ckeDescription.Text = "";
        }
    }
}