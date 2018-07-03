using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Core.DAL;

namespace BAL.eCorp
{
    /// <summary>
    /// Summary description for Link
    /// </summary>
    public class Links
    {
        #region Region: Khai báo hằng
        const string CONST_TABLE_NAME = "Link";
        #endregion

        #region Region: Khai báo biến
        protected int _linkId;
        protected string _linkName = String.Empty;
        protected string _url = String.Empty;
        protected int _pos;
        protected string _logo = String.Empty;
        // Hệ thống
        protected DateTime? _createDate = null;
        protected string _createUser = string.Empty;
        protected DateTime? _editDate = null;
        protected string _editUser = string.Empty;
        #endregion

        #region Region: Định nghĩa thuộc tính
        /// <summary>
        /// Mã liên kết
        /// </summary>
        public int LinkID
        {
            get { return _linkId; }
            set { _linkId = value; }
        }
        /// <summary>
        /// Tên liên kết
        /// </summary>
        public string LinkName
        {
            get { return _linkName; }
            set { _linkName = value; }
        }
        /// <summary>
        /// Địa chỉ liên kết
        /// </summary>
        public string URL
        {
            get { return _url; }
            set { _url = value; }
        }
        /// <summary>
        /// Vị trí pos
        /// </summary>
        public int Pos
        {
            get { return _pos; }
            set { _pos = value; }
        }
        /// <summary>
        /// Logo
        /// </summary>
        public string Logo
        {
            get { return _logo; }
            set { _logo = value; }
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
        public Links()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public Links(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _linkId = reader.GetInt32(reader.GetOrdinal("LinkID"));
                _linkName = reader.GetString(reader.GetOrdinal("LinkName"));
                _url = reader.GetString(reader.GetOrdinal("URL"));
                _pos = reader.GetInt32(reader.GetOrdinal("Pos"));
                _logo = reader.GetString(reader.GetOrdinal("Logo"));
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
        /// Truy xuất liên kết sắp xếp theo vị trí pos
        /// </summary>
        /// <returns></returns>
        public static IList<Links> GetAllOrderByPos()
        {
            DBHelp db = new DBHelp();
            IList<Links> list = new List<Links>();
            string strSelect = "SELECT  * FROM Link order by Pos ";
            SqlDataReader reader = db.ExecuteReader(strSelect, CommandType.Text);
            while (reader.Read())
            {
                list.Add(new Links(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất liên kết theo ID
        /// </summary>
        /// <returns></returns>
        public static Links GetByID(Links o)
        {
            Links obj = new Links();
            DBHelp db = new DBHelp();
            db.AddParameter("@LinkID", o.LinkID);
            SqlDataReader reader = db.ExecuteReader("sp_Link_Select", CommandType.StoredProcedure);
            if (reader.Read())
            {
                obj = new Links(reader);
            }
            reader.Close();
            return obj;
        }
        /// <summary>
        /// Thêm mới một liên kết
        /// </summary>
        /// <param name="o"></param>
        public static void Insert(Links o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@LinkName", o.LinkName);
            db.AddParameter("@URL", o.URL);
            db.AddParameter("@Pos", o.Pos);
            db.AddParameter("@Logo", o.Logo);
            db.AddParameter("@CreateDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@CreateUser", o.CreateUser);
            db.ExecuteNonQuery("sp_Link_Insert", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Cập nhập liên kết
        /// </summary>
        /// <param name="o"></param>
        public static void Update(Links o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@LinkID", o.LinkID);
            db.AddParameter("@Name", o.LinkName);
            db.AddParameter("@URL", o.URL);
            db.AddParameter("@Pos", o.Pos);
            db.AddParameter("@Logo", o.Logo);
            db.AddParameter("@EditDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@EditUser", o.EditUser);
            db.ExecuteNonQuery("sp_Link_Update", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Xóa liên kết
        /// </summary>
        /// <param name="b"></param>
        public static void Delete(Links o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@LinkID", o.LinkID);
            db.ExecuteNonQuery("sp_Link_Delete", CommandType.StoredProcedure);
        }
        
        #endregion
    }
}
