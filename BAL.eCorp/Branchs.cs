using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Core.DAL;

namespace BAL.eCorp
{
    public class Branchs
    {
        #region Region: Khai báo hằng
        const string CONST_TABLE_NAME = "Branch";
        #endregion

        #region Region: Khai báo biến
        protected int _BranchId;
        protected string _fullName = string.Empty;
        protected string _imageUrl = string.Empty;
        protected string _address = string.Empty;
        protected string _phone = string.Empty;
        protected string _mobile = string.Empty;
        protected string _fax = string.Empty;
        protected string _email = string.Empty;
        protected string _webSite = string.Empty;
        protected string _contents = string.Empty;
        // Hệ thống
        protected DateTime? _createDate = null;
        protected string _createUser = string.Empty;
        protected DateTime? _editDate = null;
        protected string _editUser = string.Empty;
        #endregion

        #region Region: Định nghĩa thuộc tính
        /// <summary>
        /// Mã người liên hệ, tư tăng
        /// </summary>
        public int BranchID
        {
            get { return _BranchId; }
            set { _BranchId = value; }
        }
        /// <summary>
        /// Họ tên người liên hệ
        /// </summary>
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        /// <summary>
        /// Chủ đề cần liên hệ
        /// </summary>
        public string ImageUrl
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }
        /// <summary>
        /// Địa chỉ liên hệ
        /// </summary>
        public string Address
        {
            get { return _address; }
            set { _address = value; }
        }
        /// <summary>
        /// Số điện thoại liên hệ
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// Địa chỉ máy Client
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        /// <summary>
        /// Địa chỉ máy Client
        /// </summary>
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }
        /// <summary>
        /// Địa chỉ emial liên hệ
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// Địa chỉ emial liên hệ
        /// </summary>
        public string WebSite
        {
            get { return _webSite; }
            set { _webSite = value; }
        }
        /// <summary>
        /// Nội dung liên hệ
        /// </summary>
        public string Contents
        {
            get { return _contents; }
            set { _contents = value; }
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
        public Branchs()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public Branchs(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _BranchId = reader.GetInt32(reader.GetOrdinal("BranchID"));
                _fullName = reader.GetString(reader.GetOrdinal("FullName"));
                _imageUrl = reader.GetString(reader.GetOrdinal("ImageUrl"));
                _address = reader.GetString(reader.GetOrdinal("Address"));
                _phone = reader.GetString(reader.GetOrdinal("Phone"));
                _mobile = reader.GetString(reader.GetOrdinal("Mobile"));
                _fax = reader.GetString(reader.GetOrdinal("Fax"));
                _email = reader.GetString(reader.GetOrdinal("Email"));
                _webSite = reader.GetString(reader.GetOrdinal("WebSite"));
                _contents = reader.GetString(reader.GetOrdinal("Contents"));
                
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
        /// Truy xuất thông tin liên hệ theo BranchID
        /// </summary>
        /// <returns></returns>
        public static Branchs GetByID(Branchs o)
        {
            Branchs obj = new Branchs();
            DBHelp db = new DBHelp();
            db.AddParameter("@BranchID", o.BranchID);
            SqlDataReader reader = db.ExecuteReader("sp_Branch_Select", CommandType.StoredProcedure);
            if (reader.Read())
            {
                obj = new Branchs(reader);
            }
            reader.Close();
            return obj;
        }
        /// <summary>
        /// Truy xuất tất cả mẫu thông tin liên hệ
        /// </summary>
        /// <returns></returns>
        public static IList<Branchs> GetAll()
        {
            DBHelp db = new DBHelp();
            IList<Branchs> list = new List<Branchs>();
            SqlDataReader reader = db.ExecuteReader("sp_Branch_SelectAll", CommandType.StoredProcedure);
            while (reader.Read())
            {
                list.Add(new Branchs(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Cập nhập mẫu thông tin liên hệ
        /// </summary>
        /// <param name="o"></param>
        public static void Update(Branchs o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@BranchID", o.BranchID);
            db.AddParameter("@FullName", o.FullName);
            db.AddParameter("@ImageUrl", o._imageUrl);
            db.AddParameter("@Address", o.Address);
            db.AddParameter("@Phone", o.Phone);
            db.AddParameter("@Mobile", o.Mobile);
            db.AddParameter("@Fax", o.Fax);
            db.AddParameter("@Email", o.Email);
            db.AddParameter("@WebSite", o.WebSite);
            db.AddParameter("@Contents", o.Contents);

            db.AddParameter("@EditDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@EditUser", o.CreateUser);
            db.ExecuteNonQuery("sp_Branch_Update", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Thêm mới mẫu thông tin liên hệ
        /// </summary>
        /// <param name="o"></param>
        public static void Insert(Branchs o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@FullName", o.FullName);
            db.AddParameter("@ImageUrl", o._imageUrl);
            db.AddParameter("@Address", o.Address);
            db.AddParameter("@Phone", o.Phone);
            db.AddParameter("@Mobile", o.Mobile);
            db.AddParameter("@Fax", o.Fax);
            db.AddParameter("@Email", o.Email);
            db.AddParameter("@WebSite", o.WebSite);
            db.AddParameter("@Contents", o.Contents);

            db.AddParameter("@CreateDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@CreateUser", o.CreateUser);
            db.ExecuteNonQuery("sp_Branch_Insert", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Xóa mẫu thông tin liên hệ
        /// </summary>
        /// <param name="o"></param>
        public static void Delete(Branchs o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@BranchID", o.BranchID);
            db.ExecuteNonQuery("sp_Branch_Delete", CommandType.StoredProcedure);
        }
        #endregion
    }
}