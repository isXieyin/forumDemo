using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Wen.WpfApp.Common
{

    public class NotifyBase : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        /**
         * 通知，当窗口初始化时，像窗口绑定的对象传递模型数据
         */
        public void DoNotify([CallerMemberName]string propName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        public NotifyBase()
        {
        }

    }
}
