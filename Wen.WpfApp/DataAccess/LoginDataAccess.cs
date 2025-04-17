using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using Wen.WpfApp.DataAccess.Entity;

namespace Wen.WpfApp.DataAccess
{
    /**
     * 登录逻辑数据库访问操作类
     */
    public class LoginDataAccess
    {
        private static LoginDataAccess instance;

        public LoginDataAccess()
        {
        }

        public static LoginDataAccess GetInstance()
        {
            return instance ?? (instance = new LoginDataAccess());
        }

        MySqlConnection conn;

        MySqlCommand comm;

        MySqlDataAdapter adapter;

        /**
         * 销毁方法
         */
        private void Dispose()
        {
            if(adapter != null)
            {
                adapter.Dispose();
                adapter = null;
            }
            if(comm != null)
            {
                comm.Dispose();
                conn = null;
            }
            if(conn != null) { 
                conn.Close();
                conn.Dispose(); 
                conn = null;
            }
        }

        /**
         * 数据库连接初始化
         */
        private bool DataBaseConnectionInit()
        {
            // 从app.config文件中读取数据库配置信息
            string connStr = ConfigurationManager.ConnectionStrings["db"].ConnectionString;
            if(conn == null)
            {
                conn = new MySqlConnection(connStr);
            }
            try
            {
                conn.Open();
                return true;
            } catch 
            {
                return false;
            }
        }

        /**
         * 用户登录，检查用户账号与密码是否匹配
         */
        public UserEntity CheckUserInfo(string userAccount, string pwd)
        {
            try
            {
                if (DataBaseConnectionInit())
                 {
                    string queryUserSql = "select * from tb_user where user_account =@user_name and password =@pwd";
                    
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = queryUserSql;

                    // 设置命令的类型，普通的sql命令是字符串的用Text即可 ，如果是存储过程则用 CommandType.StoredProcedure
                    cmd.CommandType = CommandType.Text;

                    cmd.Parameters.AddWithValue("@user_name", userAccount);
                    cmd.Parameters.AddWithValue("@pwd", pwd);
                    adapter = new MySqlDataAdapter(cmd);
                    /*adapter.SelectCommand.Parameters.Add(new SqlParameter("@user_name", SqlDbType.VarChar)
                    { Value = userAccount});
                    adapter.SelectCommand.Parameters.Add(new SqlParameter("@pwd", SqlDbType.VarChar) 
                    { Value = pwd });*/
                    // 执行查询
                    DataTable dataTable = new DataTable();
                    int count = adapter.Fill(dataTable);

                    if(count <= 0)
                    {
                        throw new Exception("用户名或密码不正确！");
                    }
                    DataRow dr = dataTable.Rows[0];
                    
                    // 从结果集中读取用户信息
                    UserEntity userInfo = new UserEntity();
                    userInfo.UserAccount = dr.Field<string>("user_account");
                    userInfo.UserName = dr.Field<string>("user_name");
                    userInfo.PassWord = dr.Field<string>("password");
                    userInfo.HeadPortrait = dr.Field<string>("head_portrait");
                    userInfo.Gender = dr.Field<int>("gender");

                    return userInfo;
                 }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                this.Dispose();
            }
            return null;
        }

    }
}
