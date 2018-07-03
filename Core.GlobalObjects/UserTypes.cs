using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// Custom using
using System.Windows.Forms;

namespace Core.GlobalObjects
{
    public static class UserTypes
    {
        public struct Cell
        {
            /// <summary>
            /// Khởi tạo cell với vị trí dòng, cột
            /// </summary>
            public Cell(int rowi, int columni)
            {
                _rowIndex = rowi;
                _columnIndex = columni;
                _value = string.Empty;
                _valueType = null;
            }
            /// <summary>
            /// Khởi tạo cell với giá trị 
            /// </summary>
            /// <param name="rowi"></param>
            /// <param name="columni"></param>
            /// <param name="value"></param>
            /// <param name="type"></param>
            public Cell(int rowi,int columni, string value, System.Type type)
            {
                _rowIndex = rowi;
                _columnIndex = columni;
                _value = value;
                _valueType = type;
            }

            /// <summary>
            /// Row index của cell
            /// </summary>
            public int RowIndex
            {
                get { return _rowIndex; }
                set { _rowIndex = value; }
            }
            /// <summary>
            /// Column index của cell
            /// </summary>
            public int ColumnIndex
            {
                get { return _columnIndex; }
                set { _columnIndex = value; }
            }
            /// <summary>
            /// Giá trị của cell
            /// </summary>
            public string Value
            {
                get { return _value; }
                set { _value = value; }
            }
            /// <summary>
            /// Kiểu dữ liệu của cell
            /// </summary>
            public System.Type ValueType
            {
                get { return _valueType; }
                set { _valueType = value; }
            }

            private int _rowIndex;
            private int _columnIndex;
            private string _value;
            private System.Type _valueType;
        }
    }
}
