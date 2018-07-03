using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//
using Core.Librarys;

namespace Core.GlobalObjects
{
    public static class SqlConnectionInfo
    {
        /// <sumary>
        /// Thông tin kết nối CSDL Sql, khi chạy chương trình sẽ tự động load.
        /// Khi load dữ liệu phải kiểm tra kết nối, nếu 
        /// - Không kết nối đc thì gọi form kết nối
        /// - Nếu kết nối thành công thì load lại dữ liệu lên 
        /// </sumary>

        #region Region: Khai báo hằng

        const string WINDOWS_AUTHENTICATION = "WINDOWS AUTHENTICATION";
        const string SQL_SERVER_AUTHENTICATION = "SQL SERVER AUTHENTICATION";

        #endregion

        #region Region: Khai báo biến

        private static string _connectString;
        private static string _serverName;
        private static string _databaseName;
        private static string _authentication;
        private static string _login;
        private static string _password;
        
        #endregion

        #region Region: Định nghĩa thuộc tính
        /// <summary>
        /// 
        /// </summary>
        public static string ConnectString 
        {
            get { return _connectString; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string ServerName 
        {
            get { return _serverName; } 
        }
        /// <summary>
        /// 
        /// </summary>
        public static string DatabaseName
        {
            get { return _databaseName; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string Authentication
        {
            get { return _authentication; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string Login
        {
            get { return _login; }
        }
        /// <summary>
        /// 
        /// </summary>
        public static string Password
        {
            get { return _password; }
        }
        #endregion

        #region Region: Định nghĩa các phương thức
        /// <summary>
        /// Lấy chuổi kết nối từ file text, thực hiện kết nối thử, gán thông tin lên đối tượng
        /// </summary>
        /// <returns></returns>
        public static void Init()
        {
            // Mẫu dữ liệu trên file text
            //Authentication=SQL Server Authentication
            //Data Source=VAIO\SQLEXPRESS2005
            //Initial Catalog=CplusWinformApp1
            //User ID=SQL Server Authentication
            //Password=123456

            IList<string> ilstConnInfo = new List<string>();

            ilstConnInfo = TextInfo.IListReadLine(GlobalObjects.ApplicationPaths.Logs + @"\ConnectInfo_log.txt");

            foreach (string list in ilstConnInfo)
            {
                string[] separator = {"="};
                string[] arrConnInfo = list.Split(separator, StringSplitOptions.RemoveEmptyEntries);
                switch (arrConnInfo[0].ToString())
                {
                    case "Authentication":
                        _authentication = arrConnInfo[1].ToString();
                        break;
                    case "Data Source":
                        _serverName = arrConnInfo[1].ToString();
                        break;
                    case "Initial Catalog":
                        _databaseName = arrConnInfo[1].ToString();
                        break;
                    case "User ID":
                        _login = arrConnInfo[1].ToString();
                        break;
                    case "Password":
                        _password = arrConnInfo[1].ToString();
                        break;
                }
            }

            if (_authentication.ToUpper() == WINDOWS_AUTHENTICATION)
            {
                _connectString = "Data Source=" + _serverName + ";Initial Catalog=" + _databaseName + ";Integrated Security=True";
            }
            else if (_authentication.ToUpper() == SQL_SERVER_AUTHENTICATION)
            {
                
                _connectString = "Data Source=" + _serverName + ";Initial Catalog=" + _databaseName + ";User ID=" + _login + ";Password=" + _password;
            }
        }

        #endregion
    }
}
