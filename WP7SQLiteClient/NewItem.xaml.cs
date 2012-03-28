using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using WP7SQLiteClient.Dal;
namespace WP7SQLiteClient
{
    public partial class NewItem : PhoneApplicationPage
    {
        public NewItem()
        {
            InitializeComponent();
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            int rec;
            App thisApp = App.Current as App;
            Random rnd = new Random();
            string strInsert = " Insert into Customer (Name,Place,Lat, Long, Date, Hour, Status, Priority,Desc) values (@Name,@Place,@Lat,@Long,@Date,@Hour,@Status,@Priority,@Desc)";
            thisApp.ok_set_coord = false;
            string spriority = "", splace = "", sdesc = "", status = "off";
            if (sPriority.Value.ToString() == "1") spriority = "low";
            if (sPriority.Value.ToString() == "2") spriority = "medium";
            if (sPriority.Value.ToString() == "3") spriority = "high";
            if (tbPlace.Text == "") splace = "Place not set yet.";
            else splace = tbPlace.Text;
            if (tbDescriere.Text == "") sdesc = "Description not added yet.";
            else sdesc = tbDescriere.Text;
            if (switch1.IsChecked == true) status = "Yes";
            else status = "No";
            Customer tst = new Customer
            {
                Name = tbTaskName.Text + " ",
                Place = splace + " ",

                Lat = thisApp.Lat.ToString() + " ",
                Long = thisApp.Long.ToString() + " ",
                Date = datepicker1.Value.ToString() + " ",
                Hour = timepicker.Value.ToString() + " ",
                Status = status,
                Priority = spriority + " ",
                Desc = sdesc + " "
            };
            if (tbTaskName.Text == "") MessageBox.Show("Your task must have a name.");
            else
            {
                rec = (Application.Current as App).db.Insert<Customer>(tst, strInsert);

                System.Diagnostics.Debug.WriteLine("\nInserted 5 " + " rows\r\nGenerated in " + (DateTime.Now - start).TotalSeconds);
                if (switch1.IsChecked == true) NavigationService.Navigate(new Uri("/AddNotification.xaml", UriKind.RelativeOrAbsolute));
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
            }
        }

        private void bMap_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Map.xaml", UriKind.RelativeOrAbsolute));
            
        }

        private void switch1_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void switch1_Checked(object sender, RoutedEventArgs e)
        {
            
        }

      
    }
}