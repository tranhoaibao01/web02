using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using Core.DAL;

namespace BAL.eCorp
{
    public class Categories
    {
        #region region: Khai báo hằng
        const string CONST_TABLE_NAME = "Categories";
        #endregion

        #region region: Khai báo biến
        protected int _id;
        protected int _parentId;
        protected int _level;
        protected string _cateId;
        protected string _cateName = String.Empty;
        protected string _imageURL = string.Empty;
        protected int _catePos;
        // Hệ thống
        protected DateTime? _createDate = null;
        protected string _createUser = string.Empty;
        protected DateTime? _editDate = null;
        protected string _editUser = string.Empty;
        #endregion

        #region region: Định nghĩa thuộc tính
        /// <summary>
        /// Mã loại sản phẩm
        /// </summary>
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }
        
        /// <summary>
        /// ID mẹ
        /// </summary>
        public int ParentID
        {
            get { return _parentId; }
            set { _parentId = value; }
        }
        /// <summary>
        /// Bậc
        /// </summary>
        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }
        /// <summary>
        /// Mã loại sản phẩm
        /// </summary>
        public string CateID
        {
            get { return _cateId; }
            set { _cateId = value; }
        }
        /// <summary>
        /// Tên loại sản phẩm
        /// </summary>
        public string CateName
        {
            get { return _cateName; }
            set { _cateName = value; }
        }
        /// <summary>
        /// Hình hảnh
        /// </summary>
        public string ImageURL
        {
            get { return _imageURL; }
            set { _imageURL = value; }
        }
        /// <summary>
        /// Vị trí của thể loại
        /// </summary>
        public int CatePos
        {
            get { return _catePos; }
            set { _catePos = value; }
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

        #region region: Định nghĩa các phương thức
        /// <summary>
        /// Chẳng để làm gì
        /// </summary>
        public Categories()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public Categories(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _id = reader.GetInt32(reader.GetOrdinal("ID"));
                _parentId = reader.GetInt32(reader.GetOrdinal("ParentID"));
                _level = reader.GetInt32(reader.GetOrdinal("Level"));
                _cateId = reader.GetString(reader.GetOrdinal("CateID"));
                _cateName = reader.GetString(reader.GetOrdinal("CateName"));
                _imageURL = reader.GetString(reader.GetOrdinal("ImageURL"));
                _catePos = reader.GetInt32(reader.GetOrdinal("CatePos"));
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
        /// Truy xuất bản
        /// </summary>
        /// <returns></returns>
        public static IList<Categories> GetAll()
        {
            DBHelp db = new DBHelp();

            IList<Categories> list = new List<Categories>();
            SqlDataReader reader = db.ExecuteReader("sp_Categories_SelectAll", CommandType.StoredProcedure);
            while(reader.Read())
            {
                list.Add(new Categories(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất bản
        /// </summary>
        /// <returns></returns>
        public static Categories GetByID(Categories o)
        {
            Categories obj = new Categories();

            DBHelp db = new DBHelp();
            db.AddParameter("@CateID", o.CateID);

            SqlDataReader reader = db.ExecuteReader("sp_Categories_Select", CommandType.StoredProcedure);
            if (reader.Read())
            {
                obj = new Categories(reader);
            }
            reader.Close();
            return obj;
        }
        /// <summary>
        /// Truy xuất các Categories co mẹ là ParentId
        /// </summary>
        /// <returns></returns>
        public static IList<Categories> GetByPrentID(Categories o)
        {
            IList<Categories> list = new List<Categories>();

            DBHelp db = new DBHelp();
            db.AddParameter("@ParentID", o.ParentID);

            SqlDataReader reader = db.ExecuteReader("sp_Categories_SelectByParentID", CommandType.StoredProcedure);
            while (reader.Read())
            {
                list.Add(new Categories(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất bản
        /// </summary>
        /// <returns></returns>
        public static IList<Categories> GetByLevel(Categories o)
        {
            IList<Categories> list = new List<Categories>();

            DBHelp db = new DBHelp();
            db.AddParameter("@Level", o.Level);

            SqlDataReader reader = db.ExecuteReader("sp_Categories_SelectByLevel", CommandType.StoredProcedure);
            while (reader.Read())
            {
                list.Add(new Categories(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Phương thức chèn dữ liệu
        /// </summary>
        /// <param name="o"></param>
        public static void Insert(Categories o)
        {
            DBHelp db = new DBHelp();

            db.AddParameter("@ParentID", o.ParentID);
            db.AddParameter("@Level", o.Level);
            db.AddParameter("@CateID", o.CateID);
            db.AddParameter("@CateName", o.CateName);
            db.AddParameter("@ImageURL", o.ImageURL);
            db.AddParameter("@CatePos", o.CatePos);
            db.AddParameter("@CreateDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@CreateUser", o.CreateUser);
            db.ExecuteNonQuery("sp_Categories_Insert", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Phương thức cập nhật dữ liệu
        /// </summary>
        /// <param name="o"></param>
        public static void Update(Categories o)
        {
            DBHelp db = new DBHelp();

            db.AddParameter("@ID", o.ID);
            db.AddParameter("@ParentID", o.ParentID);
            db.AddParameter("@Level", o.Level);
            db.AddParameter("@CateID", o.CateID);
            db.AddParameter("@CateName", o.CateName);
            db.AddParameter("@ImageURL", o.ImageURL);
            db.AddParameter("@CatePos", o.CatePos);
            db.AddParameter("@EditDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@EditUser", o.EditUser);
            db.ExecuteNonQuery("sp_Categories_Update", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Phương thức xóa dữ liệu
        /// </summary>
        /// <param name="o"></param>
        public static void Delete(Categories o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@CateID", o.CateID);
            db.ExecuteNonQuery("sp_Categories_Delete", CommandType.StoredProcedure);
        }
        #endregion
    }
}