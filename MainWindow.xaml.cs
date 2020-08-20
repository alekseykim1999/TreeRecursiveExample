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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        static string[] massive_02 = new string[] { ".01", ".02", ".03", ".04", ".05", ".06", ".07", ".08", ".09", ".10", ".11", ".12", ".13", ".14", ".15", ".16", ".17" }; //massive  
        static int count = massive_02.Count();
        FileWorker worker = new FileWorker("Test.txt");

        Dictionary<string, string> codes = new Dictionary<string, string>();
       
        public MainWindow()
        {
            InitializeComponent();


            codes = worker.Get_Dictionary(); //получить все коды

            createTree();
        }



        void createTree() //create root leafs
        {
            foreach (KeyValuePair<string, string> keyValue in codes.Where(a=>!a.Key.Contains(".")))
            {
                var item = new TreeViewItem();
                item.Header = keyValue.Key + " " + keyValue.Value;
                this_tree.Items.Add(item);

                Function(item, keyValue.Key);              
            }
        }


        void Function(TreeViewItem copy, string test)
        {
            foreach (KeyValuePair<string, string> keyValue in codes)
            {
                for (int j = 0; j < count; j++)
                {

                    if (keyValue.Key == test + massive_02[j])
                    {
                        var subItem1 = new TreeViewItem();
                        subItem1.Header = keyValue.Key + " " + keyValue.Value;

                        copy.Items.Add(subItem1);

                        Function(subItem1, keyValue.Key);
                    }
                }
            }
        }
       

    }
}
