using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Core.DAL;

namespace BAL.eCorp
{
    /// <summary>
    /// Summary description for FAQ
    /// </summary>
    public class FAQs
    {
        #region Region: Khai báo hằng
        const string CONST_TABLE_NAME = "FAQ";
        #endregion

        #region Region: Khai báo biến
        protected int _faqId;
        protected string _title = String.Empty;
        protected string _description = String.Empty;
        // Hệ thống
        protected DateTime? _createDate = null;
        protected string _createUser = string.Empty;
        protected DateTime? _editDate = null;
        protected string _editUser = string.Empty;
        #endregion

        #region Region: Định nghĩa thuộc tính
        /// <summary>
        /// Mã hỏi/đáp
        /// </summary>
        public int FAQID
        {
            get { return _faqId; }
            set { _faqId = value; }
        }
        /// <summary>
        /// Tiêu đề
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// Mô tả thông tin hỏi đáp
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

        #region Region: Định nghĩa các phương thức

        /// <summary>
        /// 
        /// </summary>
        public FAQs()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public FAQs(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _faqId = reader.GetInt32(reader.GetOrdinal("FAQID"));
                _title = reader.GetString(reader.GetOrdinal("Title"));
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
        /// Truy xuất toàn bộ bảng hỏi đáp
        /// </summary>
        /// <returns></returns>
        public static IList<FAQs> GetAll()
        {
            DBHelp db = new DBHelp();
            IList<FAQs> list = new List<FAQs>();
            SqlDataReader reader = db.ExecuteReader("sp_FAQ_SelectAll", CommandType.StoredProcedure);
            while (reader.Read())
            {
                list.Add(new FAQs(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất toàn bộ bảng hỏi đáp
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static FAQs GetByID(FAQs o)
        {
            FAQs obj = new FAQs();
            DBHelp db = new DBHelp();
            db.AddParameter("@FAQID", o.FAQID);
            SqlDataReader reader = db.ExecuteReader("sp_FAQ_Select", CommandType.StoredProcedure);
            if (reader.Read())
            {
                obj = new FAQs(reader);
            }
            reader.Close();
            return obj;
        }
        /// <summary>
        /// Thêm mới mẫu tin hỏi đáp
        /// </summary>
        /// <param name="o"></param>
        public static void Insert(FAQs o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@Title", o.Title);
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@CreateDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@CreateUser", o.CreateUser);
            db.ExecuteNonQuery("sp_FAQ_Insert", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Cập nhật mẫu tin hỏi đáp
        /// </summary>
        /// <param name="o"></param>
        public static void Update(FAQs o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@FAQID", o.FAQID);
            db.AddParameter("@Title", o.Title);
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@EditDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@EditUser", o.EditUser);
            db.ExecuteNonQuery("sp_FAQ_Update", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Xóa mẫu tin hỏi đáp
        /// </summary>
        /// <param name="o"></param>
        public static void Delete(FAQs o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@FAQID", o.FAQID);
            db.ExecuteNonQuery("sp_FAQ_Delete", CommandType.StoredProcedure);
        }
        
        #endregion
    }
}
