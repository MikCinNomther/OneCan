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
    /// SidebarItem.xaml 的交互逻辑
    /// </summary>
    public partial class SidebarItem : UserControl
    {
        public ImageSource ButtonIcon { get {
                return this.DasIcon.Source;
            } set { 
                this.DasIcon.Source = value;
            } }
        public String ButtonText { get { 
                return DasText.Text;
            } set { 
                DasText.Text = value;
            } }


        public SidebarItem()
        {
            InitializeComponent();
        }
        public SidebarItem(ImageSource Icon,String Text)
        {
            InitializeComponent();
            this.Loaded += (sender, e) =>
            {
                this.DasIcon.Source = Icon;
                this.DasText.Text = Text;
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (this.Click != null)
            {
                this.Click.Invoke(sender, e);
            }
        }
        public static void NULLF(object sender,EventArgs e) { }
        public EventHandler Click { get; set; } = new EventHandler(NULLF);
    }
}
