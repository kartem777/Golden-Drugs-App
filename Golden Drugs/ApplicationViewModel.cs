using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;

namespace Golden_Drugs
{
    public class ApplicationViewModel
    {
        ApplicationContext db = new ApplicationContext();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        public ObservableCollection<User> Users { get; set; }
        public ApplicationViewModel()
        {
            db.Database.EnsureCreated();
            db.Users.Load();
            Users = db.Users.Local.ToObservableCollection();
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand((o) =>
                {
                    UserWindow userWindow = new UserWindow(new User());
                    if (userWindow.ShowDialog() == true)
                    {
                        User user = userWindow.User;
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                }));
            }
        }
        public RelayCommand EditCommand
        {
            get
            {
                return editCommand ?? (editCommand = new RelayCommand((selectedItem) =>
                {
                    User? user = selectedItem as User;
                    if (user == null) { return; }
                    User vm = new User
                    {
                        Id = user.Id,
                        Name = user.Name,
                        LvlPermission = user.LvlPermission,
                        Password = user.Password,
                    };
                    UserWindow userWindow = new UserWindow(vm);
                    if (userWindow.ShowDialog() == true)
                    {
                        user.Name = userWindow.User.Name;
                        user.LvlPermission = userWindow.User.LvlPermission;
                        user.Password = userWindow.User.Password;
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }));
            }
        }
        public RelayCommand DeleteCommand
        {
            get
            {
                return deleteCommand ?? (deleteCommand = new RelayCommand((selectedItem) =>
                {
                    User? user = selectedItem as User;
                    if (user == null) { return; }
                    db.Users.Remove(user);
                    db.SaveChanges();
                }));
            }
        }
    }
}
