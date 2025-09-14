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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneCan.Controls
{
    /// <summary>
    /// Sidebar.xaml 的交互逻辑
    /// </summary>
    public partial class Sidebar : Page
    {
        public Sidebar()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.Home.Click += (sender, e) =>
            {
                MainWindow.App.TranaFrame(ApplicationValues.Menu);
            };
            this.QM.Click += (sender, e) =>
            {
                MainWindow.App.TranaFrame(ApplicationValues.QM);
            };
            this.MTK.Click += (sender, e) =>
            {
                MainWindow.App.TranaFrame(ApplicationValues.MTK);
            };
            this.Unisoc.Click += (sender, e) =>
            {
                MainWindow.App.TranaFrame(ApplicationValues.Unisoc);
            };
            this.RK.Click += (sender, e) =>
            {
                MainWindow.App.TranaFrame(ApplicationValues.RK);
            };
            this.AndroidCat.Click += (sender, e) =>
            {
                MainWindow.App.TranaFrame(ApplicationValues.AndroidCat);
            };
        }
    }
}
