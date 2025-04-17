using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Wen.WpfApp.Common;
using Wen.WpfApp.Model;

namespace Wen.WpfApp.ViewModel

{
    public class MainViewModel : NotifyBase
    {

        public UserModel UserInfo { get; set; }

        // 搜索框内容
        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set { _searchText = value; this.DoNotify(); }
        }

        // 窗口主体内容
        private FrameworkElement _mainContent;

        public FrameworkElement MainContent
        {
            get { return _mainContent; }
            set { _mainContent = value; this.DoNotify(); }
        }

        public CommandBase NavChangedCommand { get; set; }

        public MainViewModel(){
            UserInfo = new UserModel();
            this.NavChangedCommand = new CommandBase();
            this.NavChangedCommand.DoExecute = new Action<object>(DoNavChanged);
            this.NavChangedCommand.DoCanExecute = new Func<object, bool>((o) => true);

            // 窗口加载完成之后，进入首页
            DoNavChanged("FirstPageView");
        }

        // 更改窗口主体内容
        private void DoNavChanged(Object obj) {
            // 获取相应按钮点击时得到的类路径 根据反射来获取对应类视图控件
            Type type = Type.GetType("Wen.WpfApp.View."+obj.ToString());
            ConstructorInfo cti = type.GetConstructor(System.Type.EmptyTypes);
            this.MainContent = (FrameworkElement)cti.Invoke(null);
        }
    }
}
