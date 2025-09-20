using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OneCan.MediaTek.Pages
{
    /// <summary>
    /// FlashFencus.xaml 的交互逻辑
    /// </summary>
    public partial class FlashFencus : Page
    {
        public FlashFencus()
        {
            InitializeComponent();
            List.Add(new PropertiesValuesDataGridKeyValuesData("设备状态", "未知"));
            List.Add(new PropertiesValuesDataGridKeyValuesData("存储空间", "31.82GB"));
            Fenqu.Add(new FenquDui() { 名称 = "System", 大小 = "114514MB" , 起始扇区 ="0x114514", 结束扇区 = "0xFA1145" });
        }
        static public List<PropertiesValuesDataGridKeyValuesData> List = new List<PropertiesValuesDataGridKeyValuesData>();
        static public List<FenquDui> Fenqu = new List<FenquDui>();

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.InfoboxD.ItemsSource = List;
            this.InfoboxDucom.ItemsSource = Fenqu;
        }

        public class  PropertiesValuesDataGridKeyValuesData
        {
            private int thisId = 0;
            public PropertiesValuesDataGridKeyValuesData(string property, string value)
            {
                项目 = property;
                值 = value;
                this.thisId = (Numt++);
            }
            static public int Numt = 0;

            public string ID { get { return  thisId.ToString(); } }
            public string 项目 { get; private set; }
            public string 值 { get; private set; }
        }

        public class FenquDui
        {
            static public int Numt = 0;
            private int thisId = (Numt++);
            public string ID { get { return thisId.ToString(); } }
            public string 名称 { get; set; }
            public string 大小 { get; set; }
            public string 起始扇区 { get; set; }
            public string 结束扇区 { get; set; }
        }
    }
}
