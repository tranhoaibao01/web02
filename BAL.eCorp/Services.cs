using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Core.DAL;

namespace BAL.eCorp
{
    /// <summary>
    /// Summary description for Service
    /// </summary>
    public class Services
    {
        #region Region: Khai báo hằng
        const string CONST_TABLE_NAME = "Service";
        #endregion

        #region Region: Khai báo biến
        protected int _serviceId;
        protected string _serviceName = String.Empty;
        protected string _imageUrl = String.Empty;
        protected string _description = String.Empty;
        // Hệ thống
        protected DateTime? _createDate = null;
        protected string _createUser = string.Empty;
        protected DateTime? _editDate = null;
        protected string _editUser = string.Empty;
        #endregion

        #region Region: Định nghĩa thuộc tích
        /// <summary>
        /// Mã dịch vụ
        /// </summary>
        public int ServiceID
        {
            get { return _serviceId; }
            set { _serviceId = value; }
        }
        /// <summary>
        /// Tên dịch vụ
        /// </summary>
        public string ServiceName
        {
            get { return _serviceName; }
            set { _serviceName = value; }
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
        /// Mô tả dịch vụ
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
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
        public Services()
        {}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public Services(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _serviceId = reader.GetInt32(reader.GetOrdinal("ServiceID"));
                _serviceName = reader.GetString(reader.GetOrdinal("ServiceName"));
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
        /// Truy xuất toàn bộ bảng dịch vụ
        /// </summary>
        /// <returns></returns>
        public static IList<Services> GetAll()
        {
            DBHelp db = new DBHelp();
            IList<Services> list = new List<Services>();
            SqlDataReader reader = db.ExecuteReader("sp_Service_SelectAll", CommandType.StoredProcedure);
            while (reader.Read())
            {
                list.Add(new Services(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất theo mã dịch vụ
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static Services GetByID(Services o)
        {
            Services obj = new Services();
            DBHelp db = new DBHelp();
            db.AddParameter("@ServiceID", o.ServiceID);
            SqlDataReader reader = db.ExecuteReader("sp_Service_Select", CommandType.StoredProcedure);
            if (reader.Read())
            {
                obj = new Services(reader);
            }
            reader.Close();
            return obj;
        }
        /// <summary>
        /// Thêm mới dịch vụ
        /// </summary>
        /// <param name="o"></param>
        public static void Insert(Services o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@Name", o.ServiceName);
            db.AddParameter("@ImageURL", o.ImageURL);
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@CreateDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@CreateUser", o.CreateUser);
            db.ExecuteNonQuery("sp_Service_Insert", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Cập nhập dịch vụ
        /// </summary>
        /// <param name="o"></param>
        public static void Update(Services o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@ServiceID", o.ServiceID);
            db.AddParameter("@Name", o.ServiceName);
            db.AddParameter("@ImageURL", o.ImageURL);
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@EditDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@EditUser", o.EditUser);
            db.ExecuteNonQuery("sp_Service_Update", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Xóa dịch vụ
        /// </summary>
        /// <param name="o"></param>
        public static void Delete(Services o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@ServiceID", o.ServiceID);
            db.ExecuteNonQuery("sp_Service_Delete", CommandType.StoredProcedure);
        }
        
        #endregion
    }
}
