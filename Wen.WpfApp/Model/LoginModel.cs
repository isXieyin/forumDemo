using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.WpfApp.Common;

namespace Wen.WpfApp.Model
{
    public class LoginModel: NotifyBase
    {
        /*用户名(账号)*/
        private string userName;
        /*密码*/
        private string passWord;
        /*验证码*/
        private string validation;

        public LoginModel() { }

        public LoginModel(string userName, string passWord, string validation)
        {
            this.userName = userName;
            this.passWord = passWord;
            this.validation = validation;
        }

        /*
         * 对应属性
         */
        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                this.DoNotify();
            }
        }

        public string PassWord
        {
            get { return passWord; }
            set
            {
                passWord = value;
                this.DoNotify();
            }
        }

        public string Validation
        {
            get { return validation; }
            set
            {
                validation = value;
                this.DoNotify();
            }
        }
    }
}
