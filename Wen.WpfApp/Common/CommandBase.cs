using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wen.WpfApp.Common
{
    /**
     * ICommand接口  命令用于将用户界面上的操作（如按钮点击、菜单项选择等）与 ViewModel 中的方法进行绑定。
     */
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        /*
         * 定义命令是否可执行的逻辑 返回false则按钮不可执行
         */
        public bool CanExecute(object parameter)
        {
            return DoCanExecute?.Invoke(parameter) == true;
        }

        /*
         * 定义命令的执行逻辑
         */
        public void Execute(object parameter)
        {
            // 如果不为空，则调用DoExecute委托类型的实例，
            DoExecute?.Invoke(parameter);
            //throw new NotImplementedException();
        }

        public Action<Object> DoExecute{ get; set; }

        public Func<Object,bool> DoCanExecute { get; set; }
    }
}
