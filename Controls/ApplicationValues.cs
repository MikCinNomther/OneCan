using OneCan.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace OneCan
{
    static public class ApplicationValues
    {
        static public OneCan.Pages.Menu Menu = new Pages.Menu();
        static public QM QM = new QM();
        static public Unisoc Unisoc = new Unisoc();
        static public MTK MTK = new MTK();
        static public RK RK = new RK();
        static public AndroidCat.MainWindow AndroidCat = new AndroidCat.MainWindow();
    }
}
