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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wen.WpfApp.Common;
using Wen.WpfApp.ViewModel;

namespace Wen.WpfApp.View
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();

            MainViewModel model = new MainViewModel();
            this.DataContext = model;
            model.UserInfo.HeadPortrait = GlobalValues.UserInfo.HeadPortrait;
            model.UserInfo.UserName = GlobalValues.UserInfo.UserName;
            model.UserInfo.Gender = GlobalValues.UserInfo.Gender;

            // 设置窗口最大高度为屏幕高度，避免最大化时遮住任务栏
            this.MaxHeight = SystemParameters.PrimaryScreenHeight;
        }

        // 拖动窗口
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if(e.LeftButton == MouseButtonState.Pressed)
            {
                if(this.WindowState == WindowState.Maximized)
                {
                    // 当处于最大化窗口状态，先恢复默认窗口大小
                    this.WindowState = WindowState.Normal;
                    // 记录鼠标位置
                    //Point startPoint = this.PointToScreen(Mouse.GetPosition(this));
                    // 获取鼠标按下时的位置
                    Point mousePoint = e.GetPosition(this);
                    // 计算窗口中心点
                    Point centerPoint = new Point(this.ActualWidth / 2, this.ActualHeight / 2);
                    // 计算鼠标与中心点的偏移量
                    double offsetX = mousePoint.X - centerPoint.X;
                    double offsetY = mousePoint.Y - centerPoint.Y;
                    
                    //this.Left = mousePoint.X;
                    // 设置窗口位置距离顶端高度
                    this.Top = 10;
                }
                this.DragMove();
            }
        }

        // 最小化窗口
        private void btnMinWindow(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;  
        }

        // 最大化窗口
        private void btnMaxWindow(object sender, RoutedEventArgs e)
        {
            // 如果已经最大化，则恢复默认状态
            this.WindowState = this.WindowState == WindowState.Maximized?WindowState.Normal:WindowState.Maximized;
        }

        // 关闭窗口
        private void btnCloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
