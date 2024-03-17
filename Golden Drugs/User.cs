using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace Golden_Drugs
{
    public class User : INotifyPropertyChanged
    {
        public string? name;
        public int lvlPermission;
        public int Id { get; set; }
        public string? password;
        public string? Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
        public int LvlPermission
        {
            get { return lvlPermission; }
            set { lvlPermission = value; OnPropertyChanged("LvlPermission"); }
        }
        public string? Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged("Password"); }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
    }
}
