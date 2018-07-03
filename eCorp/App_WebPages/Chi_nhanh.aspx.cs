using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Core.DAL;
using BAL.eCorp;

namespace eCorp.App_WebPages
{
    public partial class Chi_nhanh : System.Web.UI.Page
    {
        #region Region: Các hàm tự định nghĩa
        /// <summary>
        /// Gán dữ liệu cho ListView danh sách tin đã đăng
        /// </summary>
        /// <param name="NewsID"></param>
        private void ListView_DataBind()
        {
            ListView1.DataSource = Branchs.GetAll();
            ListView1.DataBind();

        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            //string ID = Request.QueryString["ID"].ToString();
            // Chỉ thực hiện một lần
            if (!IsPostBack)
            {
                ListView_DataBind();
            }
        }
    }
}