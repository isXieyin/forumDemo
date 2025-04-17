using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.WpfApp.Common;

namespace Wen.WpfApp.Model
{
    public class UserModel:NotifyBase
    {
		private string headPortrait;

		public string HeadPortrait
        {
			get { return headPortrait; }
			set { headPortrait = value; this.DoNotify(); }
		}

        private string username;

        public string UserName
        {
            get { return username; }
            set { username = value; DoNotify(); }
        }

        private int gender;

        public int Gender
        {
            get { return gender; }
            set { gender = value; this.DoNotify(); }
        }

    }
}
