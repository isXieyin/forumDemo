using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wen.WpfApp.DataAccess.Entity;

namespace Wen.WpfApp.Common
{
    /**
     * 用户信息缓存类
     */
    public class GlobalValues
    {
        public static UserEntity UserInfo { get; set; }
    }
}
