using System;
using System.Data;
using System.Collections.Generic;
using System.Data.SqlClient;
using Core.DAL;

namespace BAL.eCorp
{
    /// <summary>
    /// Summary description for News
    /// </summary>
    public class News
    {
        #region Region: Khai báo hằng
        const string CONST_TABLE_NAME = "News";
        #endregion

        #region Region: Khai báo biến
        protected int _newsId;
        protected string _title = String.Empty;
        protected string _imageURL = String.Empty;
        protected string _shortDescript = String.Empty;
        protected string _description = String.Empty;
        protected string _copyright = String.Empty;
        protected int _viewNumber;
        protected bool _isHotNews;
        protected DateTime? _postDate = null;
        // Hệ thống
        protected DateTime? _createDate = null;
        protected string _createUser = null;
        protected DateTime? _editDate = null;
        protected string _editUser = null;
        #endregion

        #region Region: Định nghĩa thuộc tính
        /// <summary>
        /// Mã tin tức
        /// </summary>
        public int NewsID
        {
            get { return _newsId; }
            set { _newsId = value; }
        }
        /// <summary>
        /// Tiêu đề tin tức
        /// </summary>
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        /// <summary>
        /// Hình ảnh
        /// </summary>
        public string ImageURL
        {
            get { return _imageURL; }
            set { _imageURL = value; }
        }
        /// <summary>
        /// Mô tả nội dung tin tức
        /// </summary>
        public string ShortDescript
        {
            get { return _shortDescript; }
            set { _shortDescript = value; }
        }
        /// <summary>
        /// Mô tả nội dung tin tức
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        /// <summary>
        /// Nguồn gốc mẫu tin
        /// </summary>
        public string Copyright
        {
            get { return _copyright; }
            set { _copyright = value; }
        }
        /// <summary>
        /// Số lần xem mẫu tin
        /// </summary>
        public int ViewNumber
        {
            get { return _viewNumber; }
            set { _viewNumber = value; }
        }
        /// <summary>
        /// Số lần xem mẫu tin
        /// </summary>
        public bool IsHotNews
        {
            get { return _isHotNews; }
            set { _isHotNews = value; }
        }
        /// <summary>
        /// Ngày đăng tin
        /// </summary>
        public DateTime? PostDate
        {
            get { return _postDate; }
            set { _postDate = value; }
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
        public News()
        { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="reader"></param>
        public News(SqlDataReader reader)
        {
            if (reader != null && !reader.IsClosed)
            {
                _newsId = reader.GetInt32(reader.GetOrdinal("NewsID"));
                _title = reader.GetString(reader.GetOrdinal("Title"));
                _imageURL = reader.GetString(reader.GetOrdinal("ImageURL"));
                _shortDescript = reader.GetString(reader.GetOrdinal("ShortDescript"));
                _description = reader.GetString(reader.GetOrdinal("Description"));
                _copyright = reader.GetString(reader.GetOrdinal("Copyright"));
                _viewNumber = reader.GetInt32(reader.GetOrdinal("ViewNumber"));
                _isHotNews = reader.GetBoolean(reader.GetOrdinal("IsHotNews"));
                if (!reader.IsDBNull(reader.GetOrdinal("PostDate")))
                    _postDate = reader.GetDateTime(reader.GetOrdinal("PostDate"));
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
        /// Truy xuất tất cả mâu tin và sắp xếp giảm dẫn theo NewsID
        /// </summary>
        /// <returns></returns>
        public static IList<News> GetAllOrderByID()
        {
            string strSelect = "SELECT * FROM News Order By NewsID DESC";
            DBHelp db = new DBHelp();
            SqlDataReader reader = db.ExecuteReader(strSelect, CommandType.Text);
            IList<News> list = new List<News>();
            while (reader.Read())
            {
                list.Add(new News(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất tất cả mâu tin và sắp xếp giảm dẫn theo NewsID
        /// </summary>
        /// <returns></returns>
        public static IList<News> GetAllOrderByPostDate()
        {
            DBHelp db = new DBHelp();
            SqlDataReader reader = db.ExecuteReader("sp_News_SelectAll", CommandType.StoredProcedure);
            IList<News> list = new List<News>();
            while (reader.Read())
            {
                list.Add(new News(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất tất cả mâu tin và sắp xếp giảm dẫn theo NewsID
        /// </summary>
        /// <returns></returns>
        public static IList<News> GetAllOrderByPostDateNotTop1()
        {
            DBHelp db = new DBHelp();
            SqlDataReader reader = db.ExecuteReader("sp_News_SelectAllNotTop1", CommandType.StoredProcedure);
            IList<News> list = new List<News>();
            while (reader.Read())
            {
                list.Add(new News(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất có giới hạn số lượng mẫu tin 
        /// </summary>
        /// <returns></returns>
        public static IList<News> GetTop1()
        {
            News obj = new News();
            DBHelp db = new DBHelp();

            SqlDataReader reader = db.ExecuteReader("sp_News_SelectTop1", CommandType.StoredProcedure);
            IList<News> list = new List<News>();
            while (reader.Read())
            {
                list.Add(new News(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất có giới hạn số lượng mẫu tin 
        /// </summary>
        /// <returns></returns>
        public static IList<News> GetTop7()
        {
            string strSelect = @"SELECT TOP 7 [NewsID],[Title],[ImageURL],[Description],[CreatedDate],[Copyright],[ViewNumber]
                                FROM [dbo].[News] ORDER By PostDate DESC";
            DBHelp db = new DBHelp();
            SqlDataReader reader = db.ExecuteReader(strSelect, CommandType.Text);
            IList<News> list = new List<News>();
            while (reader.Read())
            {
                list.Add(new News(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất có giới hạn số lượng mẫu tin 
        /// </summary>
        /// <returns></returns>
        public static IList<News> GetTop10()
        {
            News obj = new News();
            DBHelp db = new DBHelp();

            SqlDataReader reader = db.ExecuteReader("sp_News_SelectTop10", CommandType.StoredProcedure);
            IList<News> list = new List<News>();
            while (reader.Read())
            {
                list.Add(new News(reader));
            }
            reader.Close();
            return list;
        }
        /// <summary>
        /// Truy xuất mẫu tin tức theo NewsID
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public static News GetByID(News o)
        {
            News obj = new News();
            DBHelp db = new DBHelp();
            db.AddParameter("@NewsID", o.NewsID);
            SqlDataReader reader = db.ExecuteReader("sp_News_Select", CommandType.StoredProcedure);
            
            if (reader.Read())
            {
                obj = new News(reader);
            }
            reader.Close();
            return obj;
        }
        /// <summary>
        /// Thêm mới Tin tức
        /// </summary>
        /// <param name="o"></param>
        public static void Insert(News o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@Title", o.Title);
            db.AddParameter("@ImageURL", o.ImageURL);
            db.AddParameter("@ShortDescript", o.ShortDescript);
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@Copyright", o.Copyright);
            db.AddParameter("@IsHotNews", o.IsHotNews);
            db.AddParameter("@PostDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@CreateDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@CreateUser", o.CreateUser);
            db.ExecuteNonQuery("sp_News_Insert", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Cập nhập tin tức
        /// </summary>
        /// <param name="o"></param>
        public static void Update(News o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@NewsID", o.NewsID);
            db.AddParameter("@Title", o.Title);
            db.AddParameter("@ImageURL", o.ImageURL);
            db.AddParameter("@ShortDescript", o.ShortDescript);
            db.AddParameter("@Description", o.Description);
            db.AddParameter("@Copyright", o.Copyright);
            db.AddParameter("@ViewNumber", o.ViewNumber);
            db.AddParameter("@IsHotNews", o.IsHotNews);
            db.AddParameter("@PostDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@EditDate", DateTime.Now.ToShortDateString());
            db.AddParameter("@EditUser", o.EditUser);
            db.ExecuteNonQuery("sp_News_Update", CommandType.StoredProcedure);
        }
        /// <summary>
        /// Xóa một mẫu tin tức
        /// </summary>
        /// <param name="o"></param>
        public static void Delete(News o)
        {
            DBHelp db = new DBHelp();
            db.AddParameter("@NewsID", o.NewsID);
            db.ExecuteNonQuery("sp_News_Delete", CommandType.StoredProcedure);
        }
        #endregion
    }
}
