using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Golden_Drugs
{
    public class Item : INotifyPropertyChanged
    {
        public string? name;
        public int numberof;
        public int price;
        public int Id { get; set; }
        public string? Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }
        public int Numberof
        {
            get { return numberof; }
            set { numberof = value; OnPropertyChanged("Numberof"); }
        }
        public int Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged("Price"); }
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }
    }
}
