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
using System.Windows.Shapes;

namespace Golden_Drugs
{
    /// <summary>
    /// Interaction logic for Storage.xaml
    /// </summary>
    public partial class Storage : Window
    {
        public Storage()
        {
            InitializeComponent();
            DataContext = new StorageViewModel();
        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            Menu window = new Menu();
            window.Show();
            Close();
        }
    }
}
