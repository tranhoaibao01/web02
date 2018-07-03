using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace Core.Librarys
{
    public static class TextInfo
    {
        /// <sumary>
        /// Các hàm liên quan thêm, xóa, sửa, cập nhật dữ liệu
        /// </sumary>
        #region Region: Khai báo hằng

        #endregion

        #region Region: Khai báo biến

        #endregion

        #region Region: Định nghĩa thuộc tính

        #endregion

        #region Region: Định nghĩa các phương thức

        /// <summary>
        /// Hàm kiểm tra xem có tồn tại không?
        /// </summary>
        /// <param name="strFileName">Chứa đường dẫn tới file</param>
        /// <returns></returns>
        public static bool isExists(string fileName)
        {
            return fileName != null && File.Exists(fileName) ? true : false;
        }
        /// <summary>
        /// Hàm kiểm tra xem có đúng là file text không, kiểm tra từ file hệ thống?
        /// </summary>
        /// <param name="strFileName">Chứa đường dẫn tới file</param>
        /// <returns></returns>
        public static bool isTextFile(string fileName)
        {
            return fileName != null && Path.GetExtension(fileName) == ".txt" ? true : false;
        }
        /// <summary>
        /// Kiểm tra tên file có .txt không?
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        static bool isTextFromString(string fileName)
        {
            return fileName != null &&
                fileName.EndsWith(".txt", StringComparison.Ordinal);
        }
        /// <summary>
        /// Hàm tạo file text
        /// </summary>
        /// <param name="path">Đường dẫn đến thư mục tạo chứa file</param>
        /// <param name="name">Tên file *.txt</param>
        /// <returns></returns>
        public static bool CreateTextFile(string path, string name)
        {
            string fileName = "";
            // Kiểm tra xem có phần mở rộng không? Nếu không có thì cộng vào
            //string ext = name.Substring(name.LastIndexOf('.'));
            if (name.Substring(name.Length - 4, 4) != ".txt")
            {
                name = name + ".txt";
            }

            fileName = path + @"\" + name;

            if (File.Exists(fileName)){return true;}

            try
            {
                File.CreateText(fileName);
                return true;
            }
            catch
            {
                MsgBox.Show("Lỗi tạo file " + name + ".txt", "Tạo file text");
                return false;
            }
        }
        /// <summary>
        /// Lấy tên file từ đường dẫn có chứa tên file 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns> Tên file</returns>
        public static string GetFileName(string fileName)
        {
            string[] separators = {@"\"};
            string[]  arrName = fileName.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return arrName[arrName.Count()-1].ToString();
        }
        /// <summary>
        /// Lấy phần mở rộng của file từ đường dẫn chứa tên file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetExtension(string fileName)
        {
            string[] separators = {"."};
            string name = GetFileName(fileName);
            string [] extension = name.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            return extension[1].ToString();
        }
        /// <summary>
        /// Xóa nội dung file text, xóa trắng toàn bộ file
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static bool DeleteContent(string fileName)
        {
            // Kiểm tra file có tồn tại không?
            if (!isExists(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không tồn tại!", "Kiểm tra file");
                return false;
            }

            if (!isTextFile(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không đúng file *.txt!", "Kiểm tra file");
            }
          
            StreamWriter sw = new StreamWriter(fileName);
            sw.Write("");
            sw.Flush();
            sw.Dispose();
            return true;
        }
        /// <summary>
        /// Xóa dòng có chứa chuỗi endsWith ở cuối dòng
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="endsWith"></param>
        /// <returns></returns>
        public static bool DeleteLineOf(string fileName, string lineOf)
        {
            IList<string> ilstBegin = new List<string>();

            // Kiểm tra file có tồn tại không?
            if (!isExists(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không tồn tại!", "Kiểm tra file");
                return false;
            }

            if (!isTextFile(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không đúng file *.txt!", "Kiểm tra file");
            }

            ilstBegin = IListReadLine(fileName);
            DeleteContent(fileName);

            foreach (string list in ilstBegin)
            {
                if (list.IndexOf(lineOf) == -1)
                {
                    WriteEndLine(fileName, list);
                }
            }

            return true;
        }
        /// <summary>
        /// Đọc dữ liệu theo dòng và trả về kiểu dữ liệu IList
        /// </summary>
        public static IList<string> IListReadLine(string fileName)
        {
            IList<string> IList1 = new List<string>();
            // Kiểm tra file có tồn tại không?
            if (!isExists(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không tồn tại!", "Kiểm tra file");
                return null;
            }
            // Kiểm tra có file txt file không?
            if (!isTextFile(fileName)) 
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không đúng file *.txt!", "Kiểm tra file");
                return null;
            }

            StreamReader sr = new StreamReader(fileName);
            while(!sr.EndOfStream)
            {
                IList1.Add(sr.ReadLine());
            }
            sr.Dispose();
            return IList1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static DataTable TableReadLine(string fileName)
        {
            DataTable Table1 = new DataTable();
            // Kiểm tra file có tồn tại không?
            if (!isExists(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không tồn tại!", "Kiểm tra file");
                return null;
            }
            // Kiểm tra có file txt file không?
            if (!isTextFile(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không đúng file *.txt!", "Kiểm tra file");
                return null;
            }

            DataColumn dtc;
            dtc = new DataColumn();
            dtc.DataType = System.Type.GetType("System.String");
            dtc.ColumnName = "TextValue";
            dtc.Caption = "TextValue";
            dtc.ReadOnly = false;
            dtc.Unique = true;
            Table1.Columns.Add(dtc);

            StreamReader sr = new StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                DataRow dtr = Table1.NewRow();
                dtr["TextValue"] = sr.ReadLine();
                Table1.Rows.Add(dtr);
            }
            sr.Dispose();
            return Table1;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool Write(string fileName, string text)
        {
            // Kiểm tra file có tồn tại không?
            if (!isExists(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không tồn tại!", "Kiểm tra file");
                return false;
            }
            // Kiểm tra có file txt file không?
            if (!isTextFile(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không đúng file *.txt!", "Kiểm tra file");
                return false;
            }

            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(text);
            sw.Flush();
            sw.Dispose();

            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool WriteLine(string fileName, string text)
        {
            // Kiểm tra file có tồn tại không?
            if (!isExists(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không tồn tại!", "Kiểm tra file");
                return false;
            }
            // Kiểm tra có file txt file không?
            if (!isTextFile(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không đúng file *.txt!", "Kiểm tra file");
                return false;
            }

            StreamWriter sw = new StreamWriter(fileName);
            sw.WriteLine(text);
            sw.Flush();
            sw.Dispose();

            return true;
        }
        /// <summary>
        /// Ghi tiếp sau dòng cuối cùng của file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool WriteEndLine(string fileName, string text)
        {
            // Kiểm tra file có tồn tại không?
            if (!isExists(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không tồn tại!", "Kiểm tra file");
                return false;
            }
            // Kiểm tra có file txt file không & có tồn tại hay không?
            if (!isTextFile(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không đúng file *.txt!", "Kiểm tra file");
                return false;
            }

            StreamReader sr = new StreamReader(fileName);
            string Content = sr.ReadToEnd();
            sr.Dispose();

            StreamWriter sw = new StreamWriter(fileName);
            
            // Kiểm tra nếu chưa có kí tự xuống dòng thì tự thêm vào
            // Thực chất cũng không cần thiết vì nếu dùng hàm WriteLine nó đã tự thêm \r\n rồi
            // Chỉ để cho vui
            if (Content != "" & !Content.EndsWith("\r\n", StringComparison.Ordinal))
            {
                text = "\r\n" + text;
            }
            Content = Content + text;
            sw.WriteLine(Content);
            sw.Flush();
            sw.Dispose();

            return true;
        }
        /// <summary>
        /// Ghi vào dòng đầu tiên của file
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool WriteBeginLine(string fileName, string text)
        {
            // Kiểm tra file có tồn tại không?
            if (!isExists(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không tồn tại!", "Kiểm tra file");
                return false;
            }
            // Kiểm tra có file txt file không & có tồn tại hay không?
            if (!isTextFile(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không đúng file *.txt!", "Kiểm tra file");
                return false;
            }

            StreamReader sr = new StreamReader(fileName);
            string content = sr.ReadToEnd();
            sr.Dispose();

            StreamWriter sw = new StreamWriter(fileName);

            content = text + "\r\n" + content;

            sw.Write(content);
            sw.Flush();
            sw.Dispose();
            
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="text"></param>
        /// <param name="row">Số dòng,dòng bắt đầu từ 1</param>
        /// <returns></returns>
        public static bool WriteAtLine(string fileName, string text, int row)
        {
            int i = 0;
            string line = "";
            string content = "";
            // Kiểm tra file có tồn tại không?
            if (!isExists(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không tồn tại!", "Kiểm tra file");
                return false;
            }
            // Kiểm tra có file txt file không không?
            if (!isTextFile(fileName))
            {
                MsgBox.Show("File " + GetFileName(fileName) + " không đúng file *.txt!", "Kiểm tra file");
                return false;
            }

            StreamReader sr = new StreamReader(fileName);
            do
            {
                i++;
                line = sr.ReadLine();
                if (i <= row - 1)
                {   
                    if (content == "")
                    {
                        content = content + line;
                    }
                    else
                    {
                        content = content + "\r\n" + line;
                    }
                }
                else if (i == row)
                {
                    content = content + text + "\r\n" + line;
                }
                else
                {
                    content = content + "\r\n" + line;
                }
            } while (line != null);

            sr.Dispose();

            StreamWriter sw = new StreamWriter(fileName);
            sw.Write(content);
            sw.Flush();
            sw.Dispose();

            return true;
        }
        #endregion
    }
}
