using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AndroidCat
{
    internal class ApplicationValues
    {
        public enum Themes
        {
            Light, Dark
        };

        static private Themes NowTheme = Themes.Light;

        static public Frame MainContent;
        static public Page Content
        {
            get
            {
                return (Page)MainContent.Content;
            }
            set
            {
                MainContent.Content = value;
            }
        }
        static public Themes Theme
        {
            get
            {
                return NowTheme;
            }
            set
            {
                NowTheme = value;
                // 创建新值并替换
                var FBrush = new SolidColorBrush((value == Themes.Light) ? System.Windows.Media.Color.FromRgb(0, 0, 0) : System.Windows.Media.Color.FromRgb(255, 255, 255));
                Application.Current.Resources["FontColor"] = FBrush;
                var BBrush = new SolidColorBrush((value == Themes.Light) ? System.Windows.Media.Color.FromRgb(255, 255, 255) : System.Windows.Media.Color.FromRgb(0, 0, 0));
                Application.Current.Resources["BackgroundColor"] = BBrush;
                var BBBrush = new SolidColorBrush((value == Themes.Light) ? System.Windows.Media.Color.FromRgb(221, 221, 221) : System.Windows.Media.Color.FromRgb(0, 0, 0));
                Application.Current.Resources["ButtonBackgroundColor"] = BBBrush;
                var BBoBrush = new SolidColorBrush((value == Themes.Light) ? System.Windows.Media.Color.FromRgb(0, 0, 0) : System.Windows.Media.Color.FromRgb(221, 221, 221));
                Application.Current.Resources["ButtonBorderColor"] = BBoBrush;
            }
        }
    }
}