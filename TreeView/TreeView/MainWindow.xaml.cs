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

namespace TreeView
{

    public partial class MainWindow : Window
    {
        Random rndm = new Random();
        //  ObservableCollection<Employee> lstEmployee = new ObservableCollection<Employee>();
        public int s=1;
        public int x = 25;
        public int i;
        public int ic=0;
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Load_Click(object sender,RoutedEventArgs e)
        {
            int j;
            Random rnd = new Random();
            for (i =ic; i < x; i++){
                ListBoxItem newItem = new ListBoxItem();
                //newItem.Name = "Category"+s;
                newItem.Content = "Category"+s.ToString();
                Listbox.Items.Add(newItem);

                j = rndm.Next(1, 11);
                while (j>0)
                {
                    int jk = rnd.Next(1, 31);
                    Listbox.Items.Add("        •  item"+jk);
                    j = j - 1;
                }
                s = s + 1;
            }
            x = x + 25;
            ic = ic + 25;

        }
        private void Changed(object sender, EventArgs e)
        {
           
            for (int i = 0; i < Listbox.Items.Count; i++)
            {
                
            }
        }
        private void Doub(object sender, RoutedEventArgs e)
        {
            textBox.Text = "";
        }
    }
}
