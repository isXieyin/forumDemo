using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Wen.WpfApp.View;

namespace Wen.WpfApp
{
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // 从登录页面进入主窗口
            if(new LoginView().ShowDialog() == true)
            {
                // 登录窗口关闭，则调用主窗口，此时程序进入阻塞状态
                new MainView().ShowDialog(); 
            }
            // 客户端程序关闭
            Application.Current.Shutdown();
        }
    }
}
