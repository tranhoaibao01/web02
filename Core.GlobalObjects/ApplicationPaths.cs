using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Core.GlobalObjects
{
    public static class ApplicationPaths
    {
        /// <summary>
        /// Thư mục hiện hành chạy ứng dụng
        /// </summary>
        #region Region: Khai báo hằng

        #endregion

        #region Region: Khai báo biến

        private static string _startupPath;
        private static string _documents;
        private static string _words;
        private static string _excels;
        private static string _pdfs;
        private static string _images;
        private static string _logs;
        private static string _icons;
        private static string _scripts;
        private static string _sqls;
        private static string _reports;
        private static string _en_Reports;
        private static string _vi_Reports;
        private static string _videos;
        private static string _audios;

        #endregion
        
        #region Region: Định nghĩa thuộc tính
        /// <summary>
        /// Trả về đường dẫn thư mục chương trình đang chạy
        /// </summary>
        public static string StartupPath
        {
            get { return _startupPath; }
            //set { startupPath = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mục Documents
        /// </summary>
        public static string Documents
        {
            get { return _documents; }
            //set { documents = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mục Words
        /// </summary>
        public static string Words
        {
            get { return _words; }
            //set { words = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mục Excels
        /// </summary>
        public static string Excels
        {
            get { return _excels; }
            //set { excels = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mục Pdfs
        /// </summary>
        public static string Pdfs
        {
            get { return _pdfs; }
            //set { pdfs = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mục Images
        /// </summary>
        public static string Images
        {
            get { return _images; }
            //set { images = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mục Logs
        /// </summary>
        public static string Logs
        {
            get { return _logs; }
            //set { logs = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mục Icons
        /// </summary>
        public static string Icons
        {
            get { return _icons; }
            //set { icons = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mục Scripts
        /// </summary>
        public static string Scripts
        {
            get { return _scripts; }
            //set { scripts = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mục Sqls
        /// </summary>
        public static string Sqls
        {
            get { return _sqls; }
            //set { sqls = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mục Reports
        /// </summary>
        public static string Reports
        {
            get { return _reports; }
            //set { reports = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mục Videos 
        /// </summary>
        public static string En_Reports
        {
            get { return _en_Reports; }
            //set { en_Reports = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mục Videos
        /// </summary>
        public static string Vi_Reports
        {
            get { return _vi_Reports; }
            //set { vi_Reports = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mục Videos
        /// </summary>
        public static string Videos
        {
            get { return _videos; }
            //set { videos = value; }
        }
        /// <summary>
        /// Trả về đường dẫn thư mực Audios
        /// </summary>
        public static string Audios
        {
            get { return _audios; }
            //set { audios = value; }
        }
        #endregion

        #region Region: Định nghĩa các phương thức

        /// <summary>
        /// Khởi tạo biến đường dẫn thư mục chương trình
        /// </summary>
        public static void Init()
        {
            _startupPath = Application.StartupPath;
            _documents = _startupPath + @"\Documents";
            _words = _documents + @"\Words";
            _excels = _documents + @"\Excels";
            _pdfs = _documents + @"\Pdfs";
            _images = _startupPath + @"\Images";
            _logs = _startupPath + @"\Logs";
            _icons = _startupPath + @"\Icons";
            _scripts = _startupPath + @"\Scripts";
            _sqls = _scripts + @"\Sqls";
            _reports = _startupPath + @"\Reports";
            _en_Reports = _reports + @"\En_Reports";
            _vi_Reports = _reports + @"\Vi_Reports";
            _videos = _startupPath + @"\Videos";
            _audios = _startupPath + @"\audios";
        }

        #endregion
    }
}
