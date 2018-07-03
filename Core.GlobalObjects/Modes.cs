using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.GlobalObjects
{
    public class Modes
    {
        #region Region: Khai báo các hằng số

        /// <summary>
        /// Form đang ở chế độ chọn từ danh mục khác, hoặc từ chứng từ
        /// </summary>
        public const string SELECT = "SELECT";
        /// <summary>
        /// 
        /// </summary>
        public const string VIEW = "VIEW";
        /// <summary>
        /// 
        /// </summary>
        public const string INSERT = "INSERT";
        /// <summary>
        /// 
        /// </summary>
        public const string DELETE = "DELETE";
        /// <summary>
        /// 
        /// </summary>
        public const string EDIT = "EDIT";
        /// <summary>
        /// 
        /// </summary>
        public const string FILTER = "FILTER";

        #endregion

        #region Region: Khai báo biến

        private string _mode;

        #endregion

        #region Region: Định nghĩa các thuộc tính

        public string Mode
        {
            get { return _mode; }
            set { _mode = value; }
        }

        #endregion

        #region Region: Định nghĩa các phương thức
        
        #endregion
    }
}
