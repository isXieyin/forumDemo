using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wen.WpfApp.DataAccess.Entity
{
    /**
     * 用户user表  实体类
     */
    public class UserEntity
    {

        public int Id { get; set; }

        public string UserAccount {  get; set; }

        public string UserName { get; set; }

        public string PassWord { get; set; }

        public string HeadPortrait { get; set; }

        public int Gender {  get; set; }
    }
}
