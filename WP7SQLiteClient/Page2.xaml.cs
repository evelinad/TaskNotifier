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
using System.Collections.ObjectModel;

namespace WP7SQLiteClient
{
    public partial class Page2 : PhoneApplicationPage
    {
        ObservableCollection<Customer> _customerEntries = null;
        App thisApp = App.Current as App;
        TextBlock textBlock0;
        TextBox tbWhere;
        TextBox tBDescription;
        public Page2()
        {
            InitializeComponent();
            tBDescription = new TextBox();
            tBDescription.TextWrapping = TextWrapping.Wrap;
            tBDescription.AcceptsReturn = true;

            textBlock0 = new TextBlock();
            textBlock0.FontSize = 26;
            textBlock0.TextWrapping = TextWrapping.Wrap;
            textBlock0.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            stp1.Children.Insert(0, textBlock0);
            tbWhere = new TextBox();
            tbWhere.AcceptsReturn = true;
            tbWhere.TextWrapping = TextWrapping.Wrap;

            stp1.Children.Insert(2, tbWhere);
            stp1.Children.Insert(11,tBDescription);
            string strSelect = "SELECT ID,Name,Place,Lat, Long, Date, Hour, Status, Priority, Desc FROM Customer ORDER BY ID ASC";
            _customerEntries = (Application.Current as App).db.SelectObservableCollection<Customer>(strSelect);
            foreach (Customer data in _customerEntries)
            {
                if (data.ID == thisApp.id)
                {
                    textBlock0.Text = data.Name;
                    tbWhere.Text = data.Place;
                    
                    if (data.Priority == "low") slider1.Value = 1;
                    if (data.Priority == "medium") slider1.Value = 2;
                    if (data.Priority == "high") slider1.Value = 3;
                    //slider1.Value = ((data.Priority != "low") ? (data.Priority == "medium" ? 2 : 3) : (1));
                    tBDescription.Text = data.Desc;
                    switch1.IsChecked = (data.Status == "No" ? false: true);

                }
                // CreateControls(data.ID, data.Place, data.Date + data.Hour, data.Priority, data.Status);
            }
        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void Save(object sender, EventArgs e)
        {
            string place, name, lat, Long,date, hour, status,pri, desc;
            place = tbWhere.Text;
            name = textBlock0.Text;
            if (thisApp.Lat != -1000 && thisApp.Long != -1000)
            {
                lat = thisApp.Lat.ToString();
                Long = thisApp.Long.ToString();

            }
            else
            {
                lat=Long="-1000";
            }
            date = datepicker1.Value.ToString();
            hour = timepicker.Value.ToString();
            status = (switch1.IsChecked == true) ? "Yes" : "No";
            pri = slider1.Value.ToString();
            desc = tBDescription.Text;
            
            DateTime start = DateTime.Now;
            string strDel = " Delete from Customer where ID=" + thisApp.id.ToString();
            (Application.Current as App).db.Delete<Customer>(strDel);

            System.Diagnostics.Debug.WriteLine("\nDelete last " + " record\r\n in " + (DateTime.Now - start).TotalSeconds);
        //    rec = (Application.Current as App).db.Insert<Customer>(tst, strInsert);
            string strInsert = " Insert into Customer (Name,Place,Lat, Long, Date, Hour, Status, Priority,Desc) values (@Name,@Place,@Lat,@Long,@Date,@Hour,@Status,@Priority,@Desc)";

            int rec;
            Customer tst = new Customer
            {
                Name = name,
                Place = place,
                Lat = lat,
                Long = Long,
                Date = date,
                Hour = hour,
                Status = status,
                Priority = pri,
                Desc = desc
            };
            
            rec = (Application.Current as App).db.Insert<Customer>(tst, strInsert);

            System.Diagnostics.Debug.WriteLine("\nInserted 5 " + " rows\r\nGenerated in " + (DateTime.Now - start).TotalSeconds);
            if (switch1.IsChecked == true) NavigationService.Navigate(new Uri("/AddNotification.xaml", UriKind.RelativeOrAbsolute));
            else  NavigationService.GoBack();
        }

        private void Cancel(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/Page3.xaml",UriKind.RelativeOrAbsolute));

        }

        private void Delete(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            string strDel = " Delete from Customer where ID=" + thisApp.id.ToString();
            (Application.Current as App).db.Delete<Customer>(strDel);

            System.Diagnostics.Debug.WriteLine("\nDelete last " + " record\r\n in " + (DateTime.Now - start).TotalSeconds);
            //    rec = (Application.Current as App).db.Insert<Customer>(tst, strInsert);
            

        }

        private void SetGeoCoord_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Map.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}