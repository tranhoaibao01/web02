using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL.eCorp;
using Core.DAL;
using System.Data;
using System.Data.SqlClient;

namespace eCorp.App_WebPages
{
    public partial class San_pham : System.Web.UI.Page
    {
        #region Region: Các hàm tự định nghĩa
        /// <summary>
        /// Gán dữ liệu cho GridView
        /// </summary>
        /// <param name="cateid"></param>
        private void DataList_DataBind(string cateid)
        {
            Products obj = new Products();
            obj.CateID = cateid;

            dtlProducts.DataSource = Products.GetByCateID(obj);
            dtlProducts.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            string ID = Request.QueryString["ID"].ToString();
            string Link_Name = Request.QueryString["Link_Name"].ToString();
            // Chỉ thực hiện một lần
            if (!IsPostBack)
            {
                this.lbProductLink.Text = Link_Name;
                DataList_DataBind(ID);
            }
        }
    }
}