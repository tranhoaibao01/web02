﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Core.GlobalObjects;
using BAL.eCorp;

namespace eCorp.App_WebAdmins
{
    public partial class PartnerEdit : System.Web.UI.Page
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
                this.txtPartnerID.Enabled = false;

                if (M_Mode.Mode == Modes.EDIT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "Cập nhập khách hàng";
                    this.lbModeMessage.Text = "Cập nhập khách hàng";

                    // Gán ID
                    this.txtPartnerID.Text = ID;

                    // Gán giá trị lên các control nhập liệu
                    Partners _obj = new Partners();
                    _obj.PartnerID = Convert.ToInt32(ID);
                    _obj = Partners.GetByID(_obj);

                    this.txtPartnerID.Text = _obj.PartnerID.ToString();
                    this.txtPartnerName.Text = _obj.PartnerName;
                    this.txtImageURL.Text = _obj.ImageURL;
                    this.imgImageURL.ImageUrl = _obj.ImageURL;
                    this.txtWebsite.Text = _obj.Website;
                    this.txtEmail.Text = _obj.Email;
                    this.ckEditor.Text = _obj.Description;
                }
                else if (M_Mode.Mode == Modes.INSERT)
                {
                    // Gán tiêu đề
                    this.Page.Title = "Thêm mới khách hàng";
                    this.lbModeMessage.Text = "Thêm mới khách hàng";
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            // Lấy giá trị
            Partners _obj = new Partners();
            _obj.PartnerID = this.txtPartnerID.Text == "" ? 0 : Convert.ToInt32(this.txtPartnerID.Text);
            _obj.PartnerName = this.txtPartnerName.Text;
            _obj.ImageURL = this.txtImageURL.Text;
            _obj.Website = this.txtWebsite.Text;
            _obj.Email = this.txtEmail.Text;
            _obj.Description = this.ckEditor.Text;
            _obj.CreateDate = DateTime.Now;
            _obj.CreateUser = "Admin";
            _obj.EditDate = DateTime.Now;
            _obj.EditUser = "Admin";

            // Lưu xuống dữ liệu
            if (M_Mode.Mode == Modes.EDIT)
            {
                Partners.Update(_obj);
            }
            else if (M_Mode.Mode == Modes.INSERT)
            {
                Partners.Insert(_obj);
            }

            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\PartnerManage.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            // Mở lại trang AboutUsManage
            Response.Redirect(@"~\App_WebAdmins\PartnerManage.aspx");
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
                    string strImagePath = Server.MapPath("~/Images/Partners/" + fulImageURL.FileName);
                    fulImageURL.SaveAs(strImagePath);
                    txtImageURL.Text = "~/Images/Partners/" + fulImageURL.FileName.ToString();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
    }
}