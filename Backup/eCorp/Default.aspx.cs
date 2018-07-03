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
    public partial class Default : System.Web.UI.Page
    {
        #region Region: Các hàm tự định nghĩa
        /// <summary>
        /// Gán dữ liệu cho DataList Gach
        /// </summary>
        /// <param name="cateid"></param>
        private void ddl_Product_Gach_DataBind(string cateid)
        {
            Products obj = new Products();
            obj.CateID = cateid;
            ddl_Product_Gach.DataSource = Products.GetByCateIDTop3(obj);
            ddl_Product_Gach.DataBind();
        }
        /// <summary>
        /// Gán dữ liệu cho DataList WC
        /// </summary>
        /// <param name="cateid"></param>
        private void ddl_Product_Wc_DataBind(string cateid)
        {
            Products obj = new Products();
            obj.CateID = cateid;
            ddl_Product_Wc.DataSource = Products.GetByCateIDTop3(obj);
            ddl_Product_Wc.DataBind();
        }
        /// <summary>
        /// Gán dữ liệu cho DataList bếp
        /// </summary>
        /// <param name="cateid"></param>
        private void ddl_Product_Bep_DataBind(string cateid)
        {
            Products obj = new Products();
            obj.CateID = cateid;
            ddl_Product_Bep.DataSource = Products.GetByCateIDTop3(obj);
            ddl_Product_Bep.DataBind();
        }
        #endregion
        protected void Page_Load(object sender, EventArgs e)
        {
            ddl_Product_Gach_DataBind("GACH");
            ddl_Product_Wc_DataBind("WC");
            ddl_Product_Bep_DataBind("BEP");
        }
    }
}