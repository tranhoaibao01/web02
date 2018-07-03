using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Core.DAL;

namespace BAL.eCorp
{
    public class Accounts
    {
        #region Region: Khai báo hằng
        const string CONST_TABLE_NAME = "Account";
        #endregion

        #region Region: Khai báo biến
        protected string _userId = string.Empty;
        protected string _password = string.Empty;
        protected string _email = string.Empty;
        protected string _mobile = string.Empty;
        protected string _fullName = string.Empty;
        protected bool? _active = null;
        // Hệ thống
        protected DateTime? _createDate = null;
        protected string _createUser = null;
        protected DateTime? _editDate = null;
        protected string _editUser = null;
        #endregion

        #region Region: Định nghĩa thuộc tính
        /// <summary>
        /// Tài khoản đăng nhập
        /// </summary>
        public string UserID
        {
            get { return _userId; }
            set { _userId = value; }
        }
        /// <summary>
        /// Mật mã đăng nhập
        /// </summary>
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        /// <summary>
        /// Email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// Điện thoại
        /// </summary>
        public string Mobile
        {
            get { return _mobile; }
            set { _mobile = value; }
        }
        /// <summary>
        /// Họ tên người dùng
        /// </summary>
        public string FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }
        /// <summary>
        /// Kích hoạt tài khoản
        /// </summary>
        public bool? Active
        {
            get { return _active; }
            set { _active = value; }
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
        public Accounts()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public Accounts(SqlDataReader reader)
        {
            if (reader != null && reader.IsClosed)
            {
                _userId = reader.GetString(reader.GetOrdinal("UserID"));
                _password = reader.GetString(reader.GetOrdinal("Password"));
                _email = reader.GetString(reader.GetOrdinal("Email"));
                _mobile = reader.GetString(reader.GetOrdinal("Mobile"));
                _fullName = reader.GetString(reader.GetOrdinal("FullName"));
                _active = reader.GetBoolean(reader.GetOrdinal("Active"));
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
        /// Truy xuất UserID theo mã UserID và Password
        /// </summary>
        /// <param name="userid"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public string GetByUserIDPass(string userid, string password)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@UserID", userid);
            db.AddParameter("@Password", password);
            SqlDataReader reader = db.ExecuteReader("sp_Account_SelectByUserIDPass", CommandType.StoredProcedure);
            return reader.GetString(0);
        }
        /// <summary>
        /// Thêm mới một tài khoản
        /// </summary>
        /// <param name="o"></param>
        public static void Insert(Accounts o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@UserID", o.UserID);
            db.AddParameter("@Password", o.Password);
            db.AddParameter("@Email", o.Email);
            db.AddParameter("@Mobile", o.Mobile);
            db.AddParameter("@FullName", o.FullName);
            db.AddParameter("@Active", o.Active);
            db.AddParameter("@CreateDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@CreateUser", o.CreateUser);
            db.ExecuteNonQuery("sp_Account_Insert", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Cập nhập tài khoản
        /// </summary>
        /// <param name="o"></param>
        public static void Update(Accounts o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@UserID", o.UserID);
            db.AddParameter("@Password", o.Password);
            db.AddParameter("@Email", o.Email);
            db.AddParameter("@Mobile", o.Mobile);
            db.AddParameter("@FullName", o.FullName);
            db.AddParameter("@Active", o.Active);
            db.AddParameter("@EditDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@EditUser", o.EditUser);
            db.ExecuteNonQuery("sp_Account_Update", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Xóa tài khoản người dùng
        /// </summary>
        /// <param name="o"></param>
        public static void Delete(Accounts o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@UserID", o.UserID);
            db.ExecuteNonQuery("sp_Account_Delete", CommandType.StoredProcedure);
        }
        #endregion
    }
}