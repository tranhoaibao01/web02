using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.GlobalObjects
{
    public class LoginUser
    {
        #region Region: Khai báo hằng

        #endregion

        #region Region: Khai báo biến

        private bool isLogin = false;
        private string userName = "";
        private string password = "";

        #endregion

        #region Region: Định nghĩa thuộc tính

        /// <summary>
        /// Set/Get trạng thái login
        /// </summary>
        public bool IsLogin
        {
            get { return isLogin; }
            set { isLogin = value; }
        }
        /// <summary>
        /// Set/Get tên tài khoản đang đăng nhập hệ thống
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        private string Password
        {
            get { return password; }
        }

        #endregion

        #region Region: Định nghĩa các phương thức
        
        #endregion
    }
}
