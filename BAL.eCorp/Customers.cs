using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Core.DAL;

namespace BAL.eCorp
{
    /// <summary>
    /// Summary description for Customers
    /// </summary>
    public class Customers
    {
        #region Region: Khai báo hằng
        const string CONST_TABLE_NAME = "Customer";
        #endregion

        #region Region: Khai báo biến
        protected int _customerId;
        protected string _customerName = String.Empty;
        protected string _imageUrl = String.Empty;
        protected string _description = String.Empty;
        protected string _website = String.Empty;
        protected string _email = String.Empty;
        // Hệ thống
        protected DateTime? _createDate = null;
        protected string _createUser = string.Empty;
        protected DateTime? _editDate = null;
        protected string _editUser = string.Empty;
        #endregion                                                                                                                            #region properties

        #region Region: Định nghĩa thuộc tính
        /// <summary>
        /// Mã khách hàng
        /// </summary>
        public int CustomerID
		{
            get { return _customerId; }
            set { _customerId = value; }
		}
		/// <summary>
		/// Tên khách hàng
		/// </summary>
        public string CustomerName
		{
            get { return _customerName; }
            set { _customerName = value; }
		}
        /// <summary>
        /// Hình ảnh
        /// </summary>
		public string ImageURL
		{
			get {return _imageUrl;}
			set {_imageUrl = value;}
		}
        /// <summary>
        /// Mô tả thông tin khách hàng
        /// </summary>
		public string Description
		{
			get {return _description;}
			set {_description = value;}
		}
        /// <summary>
        /// Địa chỉ website
        /// </summary>
		public string Website
		{
			get {return _website;}
			set {_website = value;}
		}
        /// <summary>
        /// Địa chỉ Email
        /// </summary>
		public string Email
		{
			get {return _email;}
			set {_email = value;}
		}
        /// <summary>
        /// Ngày tạo
        /// </summary>
        public DateTime? CreateDate
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
        public DateTime? EditDate
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

        #region Region: Định nghĩa phương thức
        /// <summary>
        /// 
        /// </summary>
        public Customers()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public Customers(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _customerId = reader.GetInt32(reader.GetOrdinal("CustomerId"));
                _customerName = reader.GetString(reader.GetOrdinal("CustomerName"));
                _imageUrl = reader.GetString(reader.GetOrdinal("ImageURL"));
                _description = reader.GetString(reader.GetOrdinal("Description"));
                _website = reader.GetString(reader.GetOrdinal("Website"));
                _email = reader.GetString(reader.GetOrdinal("Email"));
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
        /// Truy xuất toàn bộ danh mục khách hàng
        /// </summary>
        /// <returns></returns>
        public static IList<Customers> GetAll()
        {
            DBHelp db = new DBHelp();
            SqlDataReader reader = db.ExecuteReader("sp_Customer_SelectAll", CommandType.StoredProcedure);
            IList<Customers> list = new List<Customers>();
            while (reader.Read())
            {
                list.Add(new Customers(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất theo mã khách hàng
        /// </summary>
        /// <param name="cusid"></param>
        /// <returns></returns>
        public static Customers GetByID(Customers o)
        {
            Customers obj = new Customers();
            DBHelp db = new DBHelp();
            db.AddParameter("@CustomerID", o.CustomerID);
            SqlDataReader reader = db.ExecuteReader("sp_Customer_Select", CommandType.StoredProcedure);
            while (reader.Read())
            {
                obj = new Customers(reader);
            }
            reader.Close();
            return obj;
        }
        /// <summary>
        /// Thêm mới khách hàng
        /// </summary>
        /// <param name="c"></param>
        public static void Insert(Customers o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@Name", o.CustomerName);
            db.AddParameter("@ImageURL", o.ImageURL);
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@Website", o.Website);
            db.AddParameter("@Email", o.Email);
            db.AddParameter("@CreateDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@CreateUser", o.CreateUser);
            db.ExecuteNonQuery("sp_Customer_Insert", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Cập nhập thông tin khách hàng
        /// </summary>
        /// <param name="c"></param>
        public static void Update(Customers o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@CustomerID", o.CustomerID);
            db.AddParameter("@Name", o.CustomerName);
            db.AddParameter("@ImageURL", o.ImageURL);
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@Website", o.Website);
            db.AddParameter("@Email", o.Email);
            db.AddParameter("@EditDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@EditUser", o.EditUser);
            db.ExecuteNonQuery("sp_Customer_Update", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Xóa khách hàng
        /// </summary>
        /// <param name="c"></param>
        public static void Delete(Customers o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@CustomerID", o.CustomerID);
            db.ExecuteNonQuery("sp_Customer_Delete", CommandType.StoredProcedure);
        }
        #endregion
    }
}
