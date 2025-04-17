using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wen.WpfApp.Common;
using Wen.WpfApp.DataAccess;
using Wen.WpfApp.Model;

namespace Wen.WpfApp.ViewModel
{
    /**
     * 登录窗口按键触发逻辑类
     */
    public class LoginViewModel:NotifyBase
    {
        /*
         * 用户数据模型 （实体类）
         */
        public LoginModel LoginModel { get; set; } = new LoginModel("wen", "", "");

        /**
         * 该属性名与登录窗口的Command相互绑定,用于关闭登录窗口
         */
        public CommandBase CloseWindowCommand { get; set; }

         /**
         * 该属性名与登录窗口的Command相互绑定,用于登录按钮逻辑
         */
        public CommandBase LoginCommand { get; set; }

        /**
         * 定义错误信息，用于登录失败的用户提示
         */
        private string errorMessage = "";

        /**
         * 是否展示登录进度条
         */
        private Visibility isLoadingLogin = Visibility.Collapsed;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { errorMessage = value; this.DoNotify(); }
        }

        public Visibility IsLoadingLogin
        {
            get { return isLoadingLogin; }
            set { isLoadingLogin = value; this.DoNotify(); }
        }



        public LoginViewModel() {
            // 绑定用户模型数据

            this.CloseWindowCommand = new CommandBase();
            // 创建DoExecute的委托实例，该实例函数用于关闭window窗口,在此处定义关闭逻辑
            this.CloseWindowCommand.DoExecute = new Action<object>((obj) =>
            {
                (obj as Window).Close();
            });
            this.CloseWindowCommand.DoCanExecute = new Func<object,bool>((obj) =>
            {
                return true;
            });

            // 创建委托实例，用于登录按钮的具体逻辑定义
            this.LoginCommand = new CommandBase();
            this.LoginCommand.DoExecute += new Action<object>(DoLogin);
            this.LoginCommand.DoCanExecute = new Func<object, bool>((obj) =>
            {
                return true;
            });
        }

        private void DoLogin(Object o)
        {
            this.ErrorMessage = "";
            this.IsLoadingLogin = Visibility.Visible;
            if (string.IsNullOrEmpty(LoginModel.UserName))
            {
                this.ErrorMessage = "请输入用户名！";
                this.IsLoadingLogin = Visibility.Collapsed;
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.PassWord))
            {
                this.ErrorMessage = "请输入密码！";
                this.IsLoadingLogin = Visibility.Collapsed;
                return;
            }
            if (string.IsNullOrEmpty(LoginModel.Validation))
            {
                this.ErrorMessage = "请输入验证码！";
                this.IsLoadingLogin = Visibility.Collapsed;
                return;
            }
            if (LoginModel.Validation.ToLower() != "7364")
            {
                this.ErrorMessage = "验证码输入错误！";
                this.IsLoadingLogin = Visibility.Collapsed;
                return;
            }
            Task.Run(new Action(() =>
            {
                try
                {
                    var user = LoginDataAccess.GetInstance().CheckUserInfo(LoginModel.UserName, LoginModel.PassWord);
                    if (user == null)
                    {
                        throw new Exception("登陆失败，用户名或者密码错误！");
                    }
                    GlobalValues.UserInfo = user;
                    this.IsLoadingLogin = Visibility.Collapsed;
                    Application.Current.Dispatcher.Invoke(() =>
                    {
                        // 关闭主窗口
                        (o as Window).DialogResult = true;
                    });
                } catch (Exception ex)
                {
                    this.ErrorMessage = ex.Message;
                    this.IsLoadingLogin = Visibility.Collapsed;
                    return;
                }
            }));
           
        }
    }
}
