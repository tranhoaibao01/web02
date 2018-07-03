using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Core.DAL;

namespace BAL.eCorp
{
    /// <summary>
    /// Summary description for Partner
    /// </summary>
    public class Partners
    {
        #region Region: Khai báo hằng
        const string CONST_TABLE_NAME = "Partner";
        #endregion

        #region Region: Khai báo biến
        protected int _partnerId;
        protected string _partnerName = String.Empty;
        protected string _imageUrl = String.Empty;
        protected string _description = String.Empty;
        protected string _website = String.Empty;
        protected string _email = String.Empty;
        // Hệ thống
        protected DateTime? _createDate = null;
        protected string _createUser = string.Empty;
        protected DateTime? _editDate = null;
        protected string _editUser = string.Empty;
        #endregion

        #region Region: Khai báo thuộc tính
        /// <summary>
        /// Mã đối tác
        /// </summary>
        public int PartnerID
        {
            get { return _partnerId; }
            set { _partnerId = value; }
        }
        /// <summary>
        /// Tên đối tác
        /// </summary>
        public string PartnerName
        {
            get { return _partnerName; }
            set { _partnerName = value; }
        }
        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string ImageURL
        {
            get { return _imageUrl; }
            set { _imageUrl = value; }
        }
        /// <summary>
        /// Mô tả thông tin đối tác
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// Địa chỉ trang web
        /// </summary>
        public string Website
        {
            get { return _website; }
            set { _website = value; }
        }
        /// <summary>
        /// Địa chỉ Email
        /// </summary>
        public string Email
        {
            get { return _email; }
            set { _email = value; }
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

        #region Region:Định nghĩa phương thức
        /// <summary>
        /// 
        /// </summary>
        public Partners()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public Partners(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _partnerId = reader.GetInt32(reader.GetOrdinal("PartnerID"));
                _partnerName = reader.GetString(reader.GetOrdinal("PartnerName"));
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
        /// Truy xuất toàn bộ bảng đối tác
        /// </summary>
        /// <returns></returns>
        public static IList<Partners> GetAll()
        {
            DBHelp db = new DBHelp();
            IList<Partners> list = new List<Partners>();
            SqlDataReader reader = db.ExecuteReader("sp_Partner_SelectAll", CommandType.StoredProcedure);
            while (reader.Read())
            {
                list.Add(new Partners(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất toàn bộ bảng đối tác
        /// </summary>
        /// <returns></returns>
        public static Partners GetByID(Partners o)
        {
            Partners obj = new Partners();
            DBHelp db = new DBHelp();
            db.AddParameter("@PartnerID", o.PartnerID);

            SqlDataReader reader = db.ExecuteReader("sp_Partner_Select", CommandType.StoredProcedure);
            if (reader.Read())
            {
                obj = new Partners(reader);
            }
            reader.Close();
            return obj;
        }
        /// <summary>
        /// Thêm mới đối tác
        /// </summary>
        /// <param name="o"></param>
        public static void Insert(Partners o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@Name", o.PartnerName);
            db.AddParameter("@ImageURL", o.ImageURL);
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@Website", o.Website);
            db.AddParameter("@Email", o.Email);
            db.AddParameter("@CreateDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@CreateUser", o.CreateUser);
            db.ExecuteNonQuery("sp_Partner_Insert", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Cập nhập thông tin đối tác
        /// </summary>
        /// <param name="o"></param>
        public static void Update(Partners o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@PartnerID", o.PartnerID);
            db.AddParameter("@Name", o.PartnerName);
            db.AddParameter("@ImageURL", o.ImageURL);
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@Website", o.Website);
            db.AddParameter("@Email", o.Email);
            db.AddParameter("@EditDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@EditUser", o.EditUser);
            db.ExecuteNonQuery("sp_Partner_Update", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Xóa đối tác
        /// </summary>
        /// <param name="o"></param>
        public static void Delete(Partners o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@PartnerID", o.PartnerID);
            db.ExecuteNonQuery("sp_Partner_Delete", CommandType.StoredProcedure);
        }
        #endregion
    }
}
