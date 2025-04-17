using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Wen.WpfApp.ViewModel;

namespace Wen.WpfApp.View
{
    /// <summary>
    /// LoginView.xaml 的交互逻辑
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            // 创建LoginViewModel的对象，并初始化构造函数
            this.DataContext = new LoginViewModel();
        }

        /**
         * 窗口使用鼠标拖动逻辑
         */
        private void WinMove_LeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // MouseButtonEventArgs用于获取鼠标事件，当左键处于按下状态，则可以拖动窗口
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                this.DragMove();
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
