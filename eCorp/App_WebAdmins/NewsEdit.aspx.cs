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
    public partial class NewsEdit : System.Web.UI.Page
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
                this.txtNewsID.Enabled = false;

                if (M_Mode.Mode == Modes.EDIT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "Cập nhập danh mục tin tức";
                    this.lbModeMessage.Text = "Cập nhập danh mục tin tức";

                    // Gán ID
                    this.txtNewsID.Text = ID;

                    // Gán giá trị lên các control nhập liệu
                    News _obj = new News();
                    _obj.NewsID = Convert.ToInt32(ID);
                    _obj = News.GetByID(_obj);

                    this.txtNewsID.Text = _obj.NewsID.ToString();
                    this.txtTitle.Text = _obj.Title;
                    this.txtImageURL.Text = _obj.ImageURL;
                    this.imgImageURL.ImageUrl = _obj.ImageURL;
                    this.txtCopyright.Text = _obj.Copyright;
                    this.ckEditor.Text = _obj.Description;
                    this.txtShortDescript.Text = _obj.ShortDescript;
                    this.chkIsHotNews.Checked = _obj.IsHotNews;
                }
                else if (M_Mode.Mode == Modes.INSERT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "Thêm mới danh mục tin tức";
                    this.lbModeMessage.Text = "Thêm mới danh mục tin tức";
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
                    string strImagePath = Server.MapPath("~/Images/News/" + fulImageURL.FileName);
                    fulImageURL.SaveAs(strImagePath);
                    txtImageURL.Text = "~/Images/News/" + fulImageURL.FileName.ToString();
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
            News _obj = new News();
            _obj.NewsID = this.txtNewsID.Text == "" ? 0 : Convert.ToInt32(this.txtNewsID.Text);
            _obj.Title = this.txtTitle.Text;
            _obj.ImageURL = this.txtImageURL.Text;
            _obj.ShortDescript = this.txtShortDescript.Text;
            _obj.Description = this.ckEditor.Text;
            _obj.Copyright = this.txtCopyright.Text;
            _obj.IsHotNews = chkIsHotNews.Checked;
            _obj.CreateDate = DateTime.Now;
            _obj.CreateUser = "Admin";
            _obj.EditDate = DateTime.Now;
            _obj.EditUser = "Admin";

            // Lưu xuống dữ liệu
            if (M_Mode.Mode == Modes.EDIT)
            {
                News.Update(_obj);
            }
            else if (M_Mode.Mode == Modes.INSERT)
            {
                News.Insert(_obj);
            }

            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\NewsManage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\NewsManage.aspx");
        }
    }
}