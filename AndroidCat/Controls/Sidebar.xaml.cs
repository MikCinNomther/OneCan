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

namespace AndroidCat.Controls
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

        }

        public void AddItem(string name,Page Content) 
        {
            WP.Children.Add(new SidebarItem(Content, name));
        }

        public void Init()
        {
            WP.Children.Clear();
        }

        private void Page_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
