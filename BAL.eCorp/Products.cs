using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Core.DAL;

namespace BAL.eCorp
{
    public class Products
    {
        #region region: Khai báo hằng
        const string CONST_TABLE_NAME = "Product";
        #endregion

        #region region: Khai báo biến
        protected string _cateId;
        protected string _cateName;
        protected int _productId;
        protected string _productTitle = string.Empty;
        protected string _imageUrl = string.Empty;
        protected string _description = string.Empty;
        
        // Hệ thống
        protected DateTime _createDate ;
        protected string _createUser = string.Empty;
        protected DateTime _editDate ;
        protected string _editUser = string.Empty;
        #endregion

        #region region: Định nghĩa thuộc tính
        /// <summary>
        /// Mả loại sản phẩm
        /// </summary>
        public string CateID
        {
            get { return _cateId; }
            set { _cateId = value; }
        }
        /// <summary>
        /// Mả loại sản phẩm
        /// </summary>
        public string CateName
        {
            get { return _cateName; }
            set { _cateName = value; }
        }
        /// <summary>
        /// Mã sản phẩm
        /// </summary>
        public int ProductID
        {
            get { return _productId; }
            set { _productId = value; }
        }
        
        /// <summary>
        /// Tiêu đề sản phẩm
        /// </summary>
        public string ProductTitle
        {
            get { return _productTitle; }
            set { _productTitle = value; }
        }
        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }
        /// <summary>
        /// Mô tả sản phẩm
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime CreateDate
        {
            get { return _createDate; }
            set { _createDate = value; }
        }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string CreateUser
        {
            get { return _createUser; }
            set { _createUser = value; }
        }
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime EditDate
        {
            get { return _editDate; }
            set { _editDate = value; }
        }
        /// <summary>
        /// Người tạo
        /// </summary>
        public string EditUser
        {
            get { return _editUser; }
            set { _editUser = value; }
        }
        #endregion

        #region region: Định nghĩa phương thức
        /// <summary>
        /// 
        /// </summary>
        public Products()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public Products(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _cateId = reader.GetString(reader.GetOrdinal("CateID"));
                _cateName = reader.GetString(reader.GetOrdinal("CateName"));
                _productId = reader.GetInt32(reader.GetOrdinal("ProductID"));
                _productTitle = reader.GetString(reader.GetOrdinal("ProductTitle"));
                _imageUrl = reader.GetString(reader.GetOrdinal("ImageURL"));
                _description = reader.GetString(reader.GetOrdinal("Description"));
                // Hệ thống
                if (!reader.IsDBNull(reader.GetOrdinal("CreateDate")))
                    _createDate = reader.GetDateTime(reader.GetOrdinal("CreateDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("CreateUser")))
                    _createUser = reader.GetString(reader.GetOrdinal("CreateUser"));
                if (!reader.IsDBNull(reader.GetOrdinal("EditDate")))
                    _editDate = reader.GetDateTime(reader.GetOrdinal("EditDate"));
                if (!reader.IsDBNull(reader.GetOrdinal("EditUser")))
                    _editUser = reader.GetString(reader.GetOrdinal("EditUser"));
            }
        }
        /// <summary>
        /// Phương thức truy xuất sản phẩm theo ProductID
        /// </summary>
        /// <returns></returns>
        public static Products GetByID(Products o)
        {
            DBHelp db = new DBHelp();
            Products obj = new Products();

            db.AddParameter("@ProductID", o.ProductID);
            SqlDataReader reader = db.ExecuteReader("sp_Product_SelectByProductID", CommandType.StoredProcedure);
            if (reader.Read())
            {
                obj = new Products(reader);
            }

            reader.Close();
            return obj;
        }
        /// <summary>
        /// Phương thức truy xuất toàn bộ dữ liệu bảng sản phẩm
        /// </summary>
        /// <returns></returns>
        public static IList<Products> GetAll()
        {
            DBHelp db = new DBHelp();
            IList<Products> list = new List<Products>();
            SqlDataReader reader = db.ExecuteReader("sp_Product_SelectAll", CommandType.StoredProcedure);
            while (reader.Read())
            {
                list.Add(new Products(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất sản phẩm theo mã thể loại
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static IList<Products> GetByCateID(Products o)
        {
            DBHelp db = new DBHelp();
            IList<Products> list = new List<Products>();
            db.AddParameter("@CateID", o.CateID);
            SqlDataReader reader = db.ExecuteReader("sp_Product_SelectByCateID", CommandType.StoredProcedure);
            while (reader.Read())
            {
                list.Add(new Products(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất sản phẩm theo mã thể loại
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static IList<Products> GetByCateIDTop3(Products o)
        {
            DBHelp db = new DBHelp();
            IList<Products> list = new List<Products>();
            db.AddParameter("@CateID", o.CateID);
            SqlDataReader reader = db.ExecuteReader("sp_Product_SelectByCateIDTop3", CommandType.StoredProcedure);
            while (reader.Read())
            {
                list.Add(new Products(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất có giới hạn một số sản phẩm
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public static IList<Products> GetTop()
        {
            DBHelp db = new DBHelp();
            string strSelect = @"SELECT TOP 10" +
                                    @"
                                      p.[CateID],
                                      c.[CateName],    
                                      p.[ProductID],
                                      p.[ProductTitle],
                                      p.[ImageURL],
                                      p.[Description],
		                              p.[CreateDate],
                                      p.[CreateUser],
		                              p.[EditDate],
		                              p.[EditUser]
	                            FROM [dbo].[Product]
                                    Left join [dbo].[CateGories] c on c.CateID = p.CateID
                                ORDER BY p.CateID,p.ProductID";

            SqlDataReader reader = db.ExecuteReader(strSelect, CommandType.Text);
            IList<Products> list = new List<Products>();
            while (reader.Read())
            {
                list.Add(new Products(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Chèn mới một sản phẩm
        /// </summary>
        /// <param name="o"></param>
        public static void Insert(Products o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@CateID", o.CateID);
            db.AddParameter("@ProductTitle", o.ProductTitle);
            db.AddParameter("@ImageURL", o.ImageUrl);
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@CreateDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@CreateUser", o.CreateUser);
            db.ExecuteNonQuery("sp_Product_Insert", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Cập nhật sản phẩm
        /// </summary>
        /// <param name="o"></param>
        public static void Update(Products o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@ProductID", o.ProductID);
            db.AddParameter("@CateID", o.CateID);
            db.AddParameter("@ProductTitle", o.ProductTitle);
            db.AddParameter("@ImageURL", o.ImageUrl);
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@EditDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@EditUser", o.EditUser);
            db.ExecuteNonQuery("sp_Product_Update", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Xóa sản phẩm theo thể loại
        /// </summary>
        /// <param name="o"></param>
        public static void Delete(Products o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@ProductID", o.ProductID);
            db.ExecuteNonQuery("sp_Product_Delete", CommandType.StoredProcedure);
        }
        #endregion
    }
}