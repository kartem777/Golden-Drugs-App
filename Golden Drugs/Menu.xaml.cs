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
    /// Interaction logic for Menu.xaml
    /// </summary>
    public partial class Menu : Window
    {
        public Menu()
        {
            InitializeComponent();
            using (CurrentUserContext userdb = new CurrentUserContext())
            {
                textb.Text = "Profile\nName: " + userdb.Users.OrderBy(user => user.Id).Last().Name + "\nPermission lvl: " + userdb.Users.OrderBy(user => user.Id).Last().LvlPermission;
            }
        }

        private void Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void AdminPanel_Click(object sender, RoutedEventArgs e)
        {
            using (CurrentUserContext userdb = new CurrentUserContext())
            {
                if (userdb.Users.OrderBy(user => user.Id).Last().LvlPermission >= 3)
                {
                    AdminPanel window = new AdminPanel();
                    window.Show();
                    Close();
                }
                else
                {
                    MessageBox.Show("Permission lvl is less than required");
                }
            }

        }
        private void Storage_Click(object sender, RoutedEventArgs e)
        {
            Storage window = new Storage();
            window.Show();
            Close();
        }
    }
}
