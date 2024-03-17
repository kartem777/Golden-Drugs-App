using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Golden_Drugs
{
    public class StorageViewModel
    {
        StorageContext db = new StorageContext();
        RelayCommand? addCommand;
        RelayCommand? editCommand;
        RelayCommand? deleteCommand;
        public ObservableCollection<Item> Items { get; set; }
        public StorageViewModel()
        {
            db.Database.EnsureCreated();
            db.Items.Load();
            Items = db.Items.Local.ToObservableCollection();
        }
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand((o) =>
                {
                    ItemWindow itemWindow = new ItemWindow(new Item());
                    if (itemWindow.ShowDialog() == true)
                    {
                        Item item = itemWindow.Item;
                        db.Items.Add(item);
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
                    Item? item = selectedItem as Item;
                    if (item == null) { return; }
                    Item vm = new Item
                    {
                        Id = item.Id,
                        Name = item.Name,
                        Numberof = item.Numberof,
                        Price = item.Price,
                    };
                    ItemWindow itemWindow = new ItemWindow(vm);
                    if (itemWindow.ShowDialog() == true)
                    {
                        item.Name = itemWindow.Item.Name;
                        item.Numberof = itemWindow.Item.Numberof;
                        item.Price = itemWindow.Item.Price;
                        db.Entry(item).State = EntityState.Modified;
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
                    Item? item = selectedItem as Item;
                    if (item == null) { return; }
                    db.Items.Remove(item);
                    db.SaveChanges();
                }));
            }
        }
    }
}
