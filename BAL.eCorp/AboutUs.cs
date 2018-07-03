using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Core.DAL;

namespace BAL.eCorp
{
    /// <summary>
    /// Summary description for AboutUs
    /// </summary>
    public class AboutUs
    {
        #region Region: Khai báo hằng
        const string CONST_TABLE_NAME = "AboutUs";
        #endregion

        #region Region: Khai báo biến

        protected int _introId;
        protected string _description = String.Empty;
        protected bool _active;
        // Hệ thống
        protected DateTime? _createDate = null;
        protected string _createUser = null;
        protected DateTime? _editDate = null;
        protected string _editUser = null;

        #endregion

        #region Region: Định nghĩa thuộc tích
        /// <summary>
        /// Mã giới thiệu, tăng tự động
        /// </summary>
        public int IntroID
        {
            get { return _introId; }
            set { _introId = value; }
        }
        /// <summary>
        /// Mô tả nội dung giới thiệu
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// Kích hoạt nội dung, trong cùng thời gian, chỉ có một nội dung được kích hoạt
        /// </summary>
        public bool Active
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

        #region Region: Khai báo phương thức
        /// <summary>
        /// Khởi tạo 
        /// </summary>
        public AboutUs()
        {
        }

        /// <summary>
        /// Khởi tạo đối tượng từ một SqlDataReader
        /// </summary>
        /// <param name="reader"></param>
        public AboutUs(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _introId = reader.GetInt32(reader.GetOrdinal("IntroID"));
                _description = reader.GetString(reader.GetOrdinal("Description"));
                if (!reader.IsDBNull(reader.GetOrdinal("Active")))
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
        /// Truy xuất toàn bộ thông tin giới thiệu doanh nghiệp
        /// </summary>
        /// <returns></returns>
        public static IList<AboutUs> GetAll()
        {
            DBHelp db = new DBHelp();
            IList<AboutUs> list = new List<AboutUs>();
            SqlDataReader reader = db.ExecuteReader("sp_AboutUs_SelectAll", CommandType.StoredProcedure);
            while (reader.Read())
            {
                list.Add(new AboutUs(reader));
            }
            return list;
        }

        /// <summary>
        /// Truy xuất toàn bộ thông tin giới thiệu doanh nghiệp
        /// </summary>
        /// <returns></returns>
        public static AboutUs GetByID(AboutUs o)
        {
            AboutUs obj = new AboutUs();

            DBHelp db = new DBHelp();
            db.AddParameter("@IntroID", o.IntroID);

            SqlDataReader reader = db.ExecuteReader("sp_AboutUs_Select", CommandType.StoredProcedure);
            if (reader.Read())
            {
                obj = new AboutUs(reader);
            }
            return obj;
        }

        /// <summary>
        /// Truy xuất toàn bộ thông tin giới thiệu doanh nghiệp
        /// </summary>
        /// <returns></returns>
        public static AboutUs GetByActive()
        {
            AboutUs obj = new AboutUs();

            DBHelp db = new DBHelp();

            SqlDataReader reader = db.ExecuteReader("sp_AboutUs_SelectAllByActive", CommandType.StoredProcedure);
            if (reader.Read())
            {
                obj = new AboutUs(reader);
            }
            return obj;
        }

        /// <summary>
        /// Thêm mới thông tin giới thiệu doanh nghiệp
        /// </summary>
        /// <param name="b"></param>
        public static void Insert(AboutUs o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@Active", o.Active);
            db.AddParameter("@CreateDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@CreateUser", o.CreateUser);
            db.ExecuteNonQuery("sp_AboutUs_Insert", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Cập nhập thông tin giới thiệu doanh nghiệp
        /// </summary>
        /// <param name="b"></param>
        public static void Update(AboutUs o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@IntroID", o.IntroID);
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@Active", o.Active);
            db.AddParameter("@EditDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@EditUser", o.CreateUser);
            db.ExecuteNonQuery("sp_AboutUs_Update", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Xóa thông tin giới thiệu doanh nghiệp
        /// </summary>
        /// <param name="b"></param>
        public static void Delete(AboutUs o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@IntroID", o.IntroID);
            db.ExecuteNonQuery("sp_AboutUs_Delete", CommandType.StoredProcedure);
        }

        /// <summary>
        /// Reset thuộc tính Active về 0 trước khi set Active cho nội dung khác
        /// </summary>
        /// <returns></returns>
        public static int ResetActive()
        {
            DBHelp db = new DBHelp();
            return db.ExecuteNonQuery("sp_AboutUs_ResetActive", CommandType.StoredProcedure);
        }
        #endregion
    }
}
