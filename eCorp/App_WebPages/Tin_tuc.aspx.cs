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
    public partial class Tin_tuc : System.Web.UI.Page
    {
        #region Region: Các hàm tự định nghĩa
        /// <summary>
        /// Gán dữ liệu cho FormView Tin Hot
        /// </summary>
        /// <param name="NewsID"></param>
        private void FormView_DataBind()
        {
            fvHotNews.DataSource = News.GetTop1();
            fvHotNews.DataBind();
        }
        /// <summary>
        /// Gán dữ liệu cho ListView danh sách tin đã đăng
        /// </summary>
        /// <param name="NewsID"></param>
        private void ListView_DataBind()
        {
            lvPostedNews.DataSource = News.GetAllOrderByPostDateNotTop1();
            lvPostedNews.DataBind();

        }

        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            // Chỉ thực hiện một lần
            if (!IsPostBack)
            {
                FormView_DataBind();
                ListView_DataBind();
            }
        }
    }
}