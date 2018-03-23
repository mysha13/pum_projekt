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

namespace boxitem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Register r = new Register();
            //r.Show();
            //Boxes b = new Boxes();
            //b.Show();
            //Items i = new Items();
            //i.Show();
            //RemindPassword rp = new RemindPassword();
            //rp.Show();
            //FindItem fi = new FindItem();
            //fi.Show();
            //BoxesList bl = new BoxesList();
            //bl.Show();
            AddPhoto ap = new AddPhoto();
            ap.Show();
            AddItem ai = new AddItem();
            ai.Show();
        }
    }
}
