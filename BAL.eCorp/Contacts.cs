using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Core.DAL;

namespace BAL.eCorp
{
    public class Contacts
    {
        #region Region: Khai báo hằng
        const string CONST_TABLE_NAME = "Contact";
        #endregion

        #region Region: Khai báo biến
        protected int _contactId;
        protected string _fullName = string.Empty;
        protected string _email = string.Empty;
        protected string _subject = string.Empty;
        protected string _contents = string.Empty;
        protected string _phone = string.Empty;
        protected string _address = string.Empty;
        protected string _iPClient = string.Empty;
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
        public int ContactID
        {
            get { return _contactId; }
            set { _contactId = value; }
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
        /// Địa chỉ emial liên hệ
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
        }
        /// <summary>
        /// Chủ đề cần liên hệ
        /// </summary>
        public string Subject
        {
            get { return _subject; }
            set { _subject = value; }
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
        /// Số điện thoại liên hệ
        /// </summary>
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// Địa chỉ liên hệ
        /// </summary>
        public string Address
        {
            get { return _phone; }
            set { _phone = value; }
        }
        /// <summary>
        /// Địa chỉ máy Client
        /// </summary>
        public string IPClient
        {
            get { return _iPClient; }
            set { _iPClient = value; }
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
        public Contacts()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public Contacts(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _contactId = reader.GetInt32(reader.GetOrdinal("ContactID"));
                _fullName = reader.GetString(reader.GetOrdinal("FullName"));
                _email = reader.GetString(reader.GetOrdinal("Email"));
                _subject = reader.GetString(reader.GetOrdinal("Subject"));
                _contents = reader.GetString(reader.GetOrdinal("Contents"));
                _phone = reader.GetString(reader.GetOrdinal("Phone"));
                _address = reader.GetString(reader.GetOrdinal("Address"));
                _iPClient = reader.GetString(reader.GetOrdinal("IPClient"));
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
        /// Truy xuất thông tin liên hệ theo ContactID
        /// </summary>
        /// <returns></returns>
        public static Contacts GetByID(Contacts o)
        {
            Contacts obj = new Contacts();
            DBHelp db = new DBHelp();
            db.AddParameter("@ContactID", o.ContactID);
            SqlDataReader reader = db.ExecuteReader("sp_Contact_Select", CommandType.StoredProcedure);
            if (reader.Read())
            {
                obj = new Contacts(reader);
            }
            reader.Close();
            return obj;
        }
        /// <summary>
        /// Truy xuất tất cả mẫu thông tin liên hệ
        /// </summary>
        /// <returns></returns>
        public static IList<Contacts> GetAll()
        {
            DBHelp db = new DBHelp();
            IList<Contacts> list = new List<Contacts>();
            SqlDataReader reader = db.ExecuteReader("sp_Contact_SelectAll", CommandType.StoredProcedure);
            while (reader.Read())
            {
                list.Add(new Contacts(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Cập nhập mẫu thông tin liên hệ
        /// </summary>
        /// <param name="o"></param>
        public static void Update(Contacts o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@ContactID", o.ContactID);
            db.AddParameter("@FullName", o.FullName);
            db.AddParameter("@Email",o.Email);
            db.AddParameter("@Subject", o.Subject);
            db.AddParameter("@Contents", o.Contents);
            db.AddParameter("@Phone", o.Phone);
            db.AddParameter("@Address", o.Address);
            db.AddParameter("@IPClient", o.IPClient);
            db.AddParameter("@EditeDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@EditeUser", o.CreateUser);
            db.ExecuteNonQuery("sp_Contact_Update", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Thêm mới mẫu thông tin liên hệ
        /// </summary>
        /// <param name="o"></param>
        public static void Insert(Contacts o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@FullName", o.FullName);
            db.AddParameter("@Email", o.Email);
            db.AddParameter("@Subject", o.Subject);
            db.AddParameter("@Contents", o.Contents);
            db.AddParameter("@Phone", o.Phone);
            db.AddParameter("@Address", o.Address);
            db.AddParameter("@IPClient", o.IPClient);
            db.AddParameter("@CreateDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@CreateUser", o.CreateUser);
            db.ExecuteNonQuery("sp_Contact_Insert", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Xóa mẫu thông tin liên hệ
        /// </summary>
        /// <param name="o"></param>
        public static void Delete(Contacts o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@ContactID", o.ContactID);
            db.ExecuteNonQuery("sp_Contact_Delete", CommandType.StoredProcedure);
        }
        #endregion
    }
}