using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* */
using System.Data;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management;
using Microsoft.SqlServer.Management.Smo.Agent;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Sdk;

namespace Core.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class SqlServerManagements
    {
        #region Region: Khai báo hằng

        #endregion

        #region Region: Khai báo biến

        #endregion

        #region Region: Định nghĩa thuộc tính

        #endregion

        #region Region: Định nghĩa các phương thức

        /// <summary>
        /// Lấy danh sách các server có cài Sql Server trên mạng
        /// </summary>
        /// <returns></returns>
        public static DataTable GetNetworkSqlServer()
        {
            DataTable dtSqlServer = Microsoft.SqlServer.Management.Smo.SmoApplication.EnumAvailableSqlServers();
            return dtSqlServer;
        }

        /// <summary>
        /// Lấy danh sách các server co cài Sqlserver máy cục bộ
        /// </summary>
        /// <param name="local"></param>
        /// <returns></returns>
        public static DataTable GetLocalSqlServer()
        {
            DataTable dtSqlServer = Microsoft.SqlServer.Management.Smo.SmoApplication.EnumAvailableSqlServers(false);
            return dtSqlServer;
        }

        /// <summary>
        /// Lấy danh sách tên cơ sở dữ liệu 
        /// </summary>
        /// <param name="serverName">Tên Server</param>
        /// <returns>Bảng dữ liệu chứa tên cơ sở dữ liệu</returns>
        public static DataTable GetDatabaseNameList(string SqlServerName)
        {
            //Tao ket noi voi server
            ServerConnection serverConnection = new ServerConnection();
            serverConnection.LoginSecure = true;
            serverConnection.ServerInstance = SqlServerName;
            Server sqlServer = new Server(serverConnection);

            //Table tra ve ket qua
            DataTable dtTable = new DataTable();
            DataColumn dtc = new DataColumn();

            dtc.DataType = System.Type.GetType("System.String");
            dtc.ColumnName = "DatabaseName";
            dtc.Caption = "Database Name";
            dtc.ReadOnly = false;
            dtc.Unique = true;

            dtTable.Columns.Add(dtc);

            try
            {
                foreach (Database db in sqlServer.Databases)
                {
                    DataRow dtr = dtTable.NewRow();
                    dtr["DatabaseName"] = db.Name;
                    dtTable.Rows.Add(dtr);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dtTable;
        }
        /// <summary>
        /// Chức năng sao lưu dữ liệu 
        /// </summary>
        /// <param name="serverName"> </param>
        /// <returns> True/ False </returns>
        private static bool SqlDbBackUp()
        {
            return true;
        }

        /// <summary>
        /// Chức năng phục hồi dữ liệu
        /// </summary>
        /// <returns> True/ False </returns>
        private static bool SqlDbRestore()
        {
            return true;
        }

        /// <summary>
        /// Chức năng quản trị người dùng SQL: Xem, Thêm, Xóa, Sửa, thiết lập mật khẩu, phân quyền User trong Sql
        /// </summary>
        /// <returns></returns>
        private static bool SqlUserManagement()
        {
            return true;
        }

        #endregion
    }
    
}
