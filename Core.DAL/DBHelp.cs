using System;
using System.Collections.Generic;
using System.Linq;
// eCorp
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Text;

namespace Core.DAL
{
    public class DBHelp
    {
        #region region: Khai báo hằng

        #endregion

        #region region: Khai báo biến

        private SqlCommand cmd;
        private bool isOpen;
        private bool handleErrors;
        private StringBuilder stringError = new StringBuilder();
        private bool inTransaction = false;

        #endregion

        #region region: Khai báo thuộc tính
        
        /// <summary>
        /// 
        /// </summary>
        protected bool HandleErrors
        {
            get { return handleErrors; }
            set { handleErrors = value; }
        }
        /// <summary>
        /// 
        /// </summary>
        protected StringBuilder StringError
        {
            get { return stringError; }
            set { stringError = value; }
        }
        /// <summary>
        /// Kiểm tra chuyển tác
        /// </summary>
        protected bool InTransaction
        {
            set { inTransaction = value; }
            get { return inTransaction; }
        }
        #endregion

        #region region: Định nghĩa các phương thức
        /// <summary>
        /// 
        /// </summary>
        public DBHelp()
        {
            // Tạo chuỗi kết nối: lấy từ file được mã hóa
            //string strSqlConnection = Core.GlobalObjects.SqlConnectionInfo.ConnectString;
            string strSqlConnection = ConfigurationManager.ConnectionStrings["eCorpConnectionString"].ConnectionString;

            // Thực hiện kết nối
            try
            {
                SqlConnection conn = new SqlConnection(strSqlConnection);
                this.cmd = conn.CreateCommand();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gán câu lệnh Sql và kiểu câu lệnh
        /// </summary>
        /// <param name="commandText">Câu lệnh Sql</param>
        /// <param name="type">Kiểu câu lệnh</param>
        public void SetCommandText(string commandText, CommandType type)
        {
            cmd.CommandText = commandText;
            cmd.CommandType = type;
            cmd.Parameters.Clear();
        }
        /// <summary>
        /// Thêm tham số với tên tham số & giá trị
        /// </summary>
        /// <param name="name">Tên tham số</param>
        /// <param name="value">Giá trị tham số</param>
        public void AddParameter(string name, object value)
        {
            SqlParameter para = cmd.CreateParameter();
            para.ParameterName = name;
            para.Value = value;
            cmd.Parameters.Add(para);
        }
        /// <summary>
        /// Thêm tham số với kiểu dữ liệu và xuất ra giá trị
        /// </summary>
        /// <param name="name">Tên tham số</param>
        /// <param name="value">Giá trị tham số</param>
        /// <param name="type">Kiểu dữ liệu tham số</param>
        /// <param name="direction">???</param>
        public void AddParameter(string name, object value, DbType type, ParameterDirection direction)
        {
            SqlParameter para = cmd.CreateParameter();
            para.ParameterName = name;
            para.Value = value;
            para.DbType = type;
            para.Direction = direction;
            cmd.Parameters.Add(para);
        }
        /// <summary>
        /// Thêm tham số
        /// </summary>
        /// <param name="parameter"></param>
        public void AddParameter(SqlParameter parameter)
        {
            cmd.Parameters.Add(parameter);
        }
        /// <summary>
        /// Dọn dẹp tham số
        /// </summary>
        public void ClearParameter()
        {
            cmd.Parameters.Clear();
        }
        /// <summary>
        /// Mở kết nối
        /// </summary>
        public void Open()
        {
            if (isOpen)
            {
                return;
            }
            if (this.InTransaction)
            {
                return;
            }
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
                isOpen = true;
            } 
        }
        /// <summary>
        /// Đóng kết nối
        /// </summary>
        public void Close()
        {
            cmd.Connection.Close();
            isOpen = false;
        }
        /// <summary>
        /// Giải phòng tài nguyên
        /// </summary>
        public void Dispose()
        {
            cmd.Connection.Dispose();
            cmd.Dispose();
            this.Close();
        }
        /// <summary>
        /// Sử dụng đối tượng truy xuất dữ liệu với SsqlDataReader
        /// </summary>
        /// <returns></returns>
        public SqlDataReader ExecuteReader()
        {
            SqlDataReader reader = null;
            try
            {
                this.Open();
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }

            return reader;
        }
        /// <summary>
        /// Sử dụng đối tượng truy xuất dữ liệu SqlDataReader với câu lệnh và kiểu câu lệnh
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string commandText, CommandType type)
        {
            SqlDataReader reader = null;
            try
            {
                this.Open();
                cmd.CommandText = commandText;
                cmd.CommandType = type;
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return reader;
        }
        /// <summary>
        /// Sử dụng câu lệnh SqlDataReader với câu lệnh, kiểu câu lệnh và tham số trực tiếp
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="type"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public SqlDataReader ExecuteReader(string commandText, CommandType type, SqlParameterCollection parameters)
        {
            SqlDataReader reader = null;
            try
            {
                this.Open();
                cmd.CommandText = commandText;
                cmd.CommandType = type;
                cmd.Parameters.Clear();

                foreach (SqlParameter para in parameters)
                {
                    cmd.Parameters.Add(para);
                }
                reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }

            return reader;
        }
        /// <summary>
        /// Thực thi câu lệnh Sql không có dữ liệu trả về
        /// </summary>
        /// <returns></returns>
        public int ExecuteNonQuery()
        {
            int row = 0;
            try
            {
                this.Open();
                row = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }

            return row;

        }
        /// <summary>
        /// Thực thi câu lệnh Sql không có dữ liệu trả về với kiểu câu lệnh
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string commandText, CommandType type)
        {
            int row = 0;
            try
            {
                this.Open();
                cmd.CommandText = commandText;
                cmd.CommandType = type;
                row = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }

            return row;
        }
        /// <summary>
        /// Thực thi câu lệnh không có dữ liệu trả về với tham số nhập trực tiếp
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="type"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public int ExecuteNonQuery(string commandText, CommandType type, SqlParameterCollection parameters)
        {
            int row = 0;
            try
            {
                this.Open();
                cmd.CommandText = commandText;
                cmd.CommandType = type;
                cmd.Parameters.Clear();
                foreach (SqlParameter para in parameters)
                {
                    cmd.Parameters.Add(para);
                }
                row = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return row;
        }
        /// <summary>
        /// Thực thi câu lệnh có dữ liệu trả về
        /// </summary>
        /// <returns></returns>
        public object ExecuteScalar()
        {
            object row = null;
            try
            {
                this.Open();
                row = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }

            return row;
        }
        /// <summary>
        /// Thực thi câu lệnh Sql có giá trị trả về với kiểu câu lệnh
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="type">Kiểu câu lệnh</param>
        /// <returns></returns>
        public object ExecuteScalar(string commandText, CommandType type)
        {
            object row = 0;
            try
            {
                this.Open();
                cmd.CommandText = commandText;
                cmd.CommandType = type;
                row = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return row;
        }
        /// <summary>
        /// Thực thi câu lệnh Sql có dữ liệu trả về với kiểu câu lệnh và tham số trực tiếp
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="type"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public object ExecuteScalar(string commandText, CommandType type, SqlParameterCollection parameters)
        {
            object row = null;
            try
            {
                this.Open();
                cmd.CommandText = commandText;
                cmd.CommandType = type;
                cmd.Parameters.Clear();
                foreach (SqlParameter para in parameters)
                {
                    cmd.Parameters.Add(para);
                }
                row = cmd.ExecuteScalar();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return row;
        }
        /// <summary>
        /// Thực thi câu lệnh bằng đối tượng DataSet
        /// </summary>
        /// <returns>Bảng dữ liệu</returns>
        public DataSet ExecuteDataSet()
        {
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            DataSet dtSet = new DataSet();
            try
            {
                dtAdapter.SelectCommand = cmd;
                dtAdapter.Fill(dtSet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return dtSet;
        }
        /// <summary>
        /// Điền dữ liệu vào DataSet
        /// </summary>
        /// <param name="dataSet"></param>
        /// <returns></returns>
        public int Fill(DataSet dataSet)
        {
            int result = 0;
            try
            {
                this.Open();
                SqlDataAdapter dtAdapter = new SqlDataAdapter();
                dtAdapter.SelectCommand = cmd;
                result = dtAdapter.Fill(dataSet);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return result;
        }
        /// <summary>
        /// Thực thi câu lệnh bằng đối tượng DataSet với câu lệnh Sql và kiểu câu lệnh
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string commandText, CommandType type)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            try
            {
                cmd.CommandText = commandText;
                cmd.CommandType = type;
                dtAdapter.SelectCommand = cmd;
                dtAdapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return ds;
        }
        /// <summary>
        /// Thực thi câu lệnh bằng đối tượng DataSet với câu lệnh Sql, kiểu câu lệnh và tham số
        /// </summary>
        /// <param name="commandText"></param>
        /// <param name="type"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public DataSet ExecuteDataSet(string commandText, CommandType type, SqlParameterCollection parameters)
        {
            DataSet ds = new DataSet();
            SqlDataAdapter dtAdapter = new SqlDataAdapter();
            try
            {
                cmd.CommandText = commandText;
                cmd.CommandType = type;
                cmd.Parameters.Clear();
                foreach (SqlParameter para in parameters)
                {
                    cmd.Parameters.Add(para);
                }
                dtAdapter.SelectCommand = cmd;
                dtAdapter.Fill(ds);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
            }
            return ds;
        }
        /// <summary>
        /// Chuyển tác
        /// </summary>
        public void BeginTransaction()
        {
            if (this.InTransaction)
            {
                return;
            }
            if (cmd.Connection.State != ConnectionState.Open)
            {
                cmd.Connection.Open();
            }
            SqlTransaction transaction = cmd.Connection.BeginTransaction();
            cmd.Transaction = transaction;
            InTransaction = true;
        }
        /// <summary>
        /// Chuyển tác có tham số
        /// </summary>
        /// <param name="lv"></param>
        public void BeginTransaction(IsolationLevel lv)
        {
            SqlTransaction transaction = cmd.Connection.BeginTransaction(lv);
            cmd.Transaction = transaction;
            InTransaction = true;
        }
        /// <summary>
        /// Thực hiện chuyển tác
        /// </summary>
        public void Comit()
        {
            if (InTransaction)
            {
                cmd.Transaction.Commit();
            }
            InTransaction = false;
        }
        /// <summary>
        /// Thực thi chuyển tác không thành công trở về ban đầu
        /// </summary>
        public void RollBack()
        {
            if (InTransaction)
            {
                try
                {
                    cmd.Transaction.Rollback();
                }
                catch (InvalidOperationException ex)
                {
                    if (HandleErrors)
                    {
                        StringError.Append("Error: RollBack");
                        StringError.Append(ex.Message);
                        StringError.Append("\n");
                    }
                    this.Close();
                }
                finally
                {
                    InTransaction = false;
                }
            }
        }
        /// <summary>
        /// Lỗi trả về
        /// </summary>
        /// <returns></returns>
        public string GetError()
        {
            return StringError.ToString();
        }
        /// <summary>
        /// Dọn dẹp lỗi trả về
        /// </summary>
        /// <returns></returns>
        public string ClearError()
        {
            string str = stringError.ToString();
            stringError = new StringBuilder();
            return str;
        }
        #endregion
    }
}