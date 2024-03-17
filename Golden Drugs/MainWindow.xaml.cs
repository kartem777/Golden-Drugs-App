using System.Windows;

namespace Golden_Drugs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool flag = false;
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                foreach (User user in users)
                {
                    if (user.name == loginbox.Text && user.Password == passwordbox.Text)
                    {
                        using (CurrentUserContext userdb = new CurrentUserContext())
                        {
                            flag = true;
                            User currentuser = new User { name = user.name, lvlPermission = user.lvlPermission, password = ""};
                            userdb.Users.Add(currentuser);
                            userdb.SaveChanges();
                        }
                        Menu window = new Menu();
                        window.Show();
                        Close();
                    }
                }
            }
            if (flag == false)
                MessageBox.Show("Incorrect login or password");
            //using (ApplicationContext db = new ApplicationContext())
            //{
            //    User tom = new User { name = "Tom", lvlPermission = 3, password = "12345" };
            //    User tom1 = new User { name = "Tom1", lvlPermission = 2, password = "123456" };
            //    User tom2 = new User { name = "Tom2", lvlPermission = 1, password = "12345" };
            //    db.Users.Add(tom1);
            //    db.Users.Add(tom2);
            //    db.Users.Add(tom);
            //    db.SaveChanges();
            //}
        }
    }
}