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
    public partial class San_pham_chi_tiet : System.Web.UI.Page
    {
        #region Region: Các hàm tự định nghĩa
        /// <summary>
        /// Gán dữ liệu cho GridView
        /// </summary>
        /// <param name="cateid"></param>
        private void FormView_DataBind(int productid)
        {
            Products obj = new Products();
            obj.ProductID = productid;
            IList<Products> ilProduct = new List<Products>();
            ilProduct.Add(Products.GetByID(obj));
            
            fvProductDetail.DataSource = ilProduct;
            fvProductDetail.DataBind();
        }
        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(Request.QueryString["ID"].ToString());
            
            // Chỉ thực hiện một lần
            if (!IsPostBack)
            {
                FormView_DataBind(ID);
            }
        }
    }
}