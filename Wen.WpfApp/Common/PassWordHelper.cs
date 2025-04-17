using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Wen.WpfApp.Common
{
    /**
     * 该类用于密码框设置密码
     */
    public class PassWordHelper
    {
        /**
         * RegisterAttached方法是用于在WPF应用程序中注册一个附加属性的静态方法。
         */
        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("PassWord", typeof(string), typeof(PassWordHelper), new
                FrameworkPropertyMetadata("", new PropertyChangedCallback(OnPropertyChanged)));

        public static string GetPassWord(DependencyObject obj)
        {
            return obj.GetValue(PasswordProperty).ToString();
        }

        public static void SetPassWord(DependencyObject obj,string value)
        {
            obj.SetValue(PasswordProperty,value);
        }

        // 标记
        static bool _isUpdating = false;

        private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = d as PasswordBox;
            password.PasswordChanged -= Password_PasswordChanged;
            if (!_isUpdating)
                password.Password = e.NewValue.ToString();
            password.PasswordChanged += Password_PasswordChanged;
        }


        public static readonly DependencyProperty AttachProperty =
           DependencyProperty.RegisterAttached("Attach", typeof(bool), typeof(PassWordHelper), new
               FrameworkPropertyMetadata(default(bool), new PropertyChangedCallback(OnAttach)));

        public static bool GetAttach(DependencyObject obj)
        {
            return (bool)obj.GetValue(AttachProperty);
        }

        public static void SetAttach(DependencyObject obj, bool value)
        {
            obj.SetValue(AttachProperty, value);
        }

        private static void OnAttach(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PasswordBox password = d as PasswordBox;
            // 增加一个绑定事件,该事件只会挂载一次
            password.PasswordChanged += Password_PasswordChanged;
        }

        private static void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PasswordBox passwordBox = sender as PasswordBox;
            _isUpdating = true;
            SetPassWord(passwordBox, passwordBox.Password);
            _isUpdating = false;
        }
    }
}
