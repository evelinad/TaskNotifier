
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
    public partial class Page3 : PhoneApplicationPage
    {
        ObservableCollection<Customer> _customerEntries = null;
        App thisApp = App.Current as App;
        public Page3()
        {
            InitializeComponent();
                   }

        private void Edit(object sender, EventArgs e)
        {

            NavigationService.Navigate(new Uri("/Page2.xaml", UriKind.RelativeOrAbsolute));
        }

        private void Remove(object sender, EventArgs e)
        {
            DateTime start = DateTime.Now;
            string strDel = " Delete from Customer where ID=" + thisApp.id.ToString();
            (Application.Current as App).db.Delete<Customer>(strDel);

            System.Diagnostics.Debug.WriteLine("\nDelete last " + " record\r\n in " + (DateTime.Now - start).TotalSeconds);
            //    rec = (Application.Current as App).db.Insert<Customer>(tst, strInsert);
            
        }

        private void SeeMap(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/ViewMap.xaml", UriKind.RelativeOrAbsolute));
        }

        private void ContentPanel_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            stp1.Children.Clear();
            App thisApp = App.Current as App;
            TextBlock textBlock0 = new TextBlock();
            textBlock0.FontSize = 26;
            TextBlock tbWhen = new TextBlock();
            TextBlock tbWhere = new TextBlock();
            TextBlock tbPriority = new TextBlock();
            TextBlock tbDescription = new TextBlock();
            TextBlock textBlock1 = new TextBlock();
            TextBlock textBlock2 = new TextBlock();
            TextBlock textBlock3 = new TextBlock();
            TextBlock textBlock4 = new TextBlock();
            textBlock1.Text = "Where";
            textBlock2.Text = "When";
            textBlock3.Text = "Priority";
            textBlock4.Text = "Description";
            textBlock1.FontSize = textBlock2.FontSize = textBlock3.FontSize = textBlock4.FontSize = 26;
            tbWhen.TextWrapping =  textBlock0.TextWrapping= tbWhere.TextWrapping = tbPriority.TextWrapping = tbDescription.TextWrapping = TextWrapping.Wrap;
            textBlock0.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
            stp1.Children.Insert(0, textBlock0);
            stp1.Children.Add(textBlock1);
            stp1.Children.Add(tbWhere);
            stp1.Children.Add(textBlock2);
            stp1.Children.Add(tbWhen);
            stp1.Children.Add(textBlock3);
            stp1.Children.Add(tbPriority);
            stp1.Children.Add(textBlock4);
            stp1.Children.Add(tbDescription);
            string strSelect = "SELECT ID,Name,Place,Lat, Long, Date, Hour, Status, Priority, Desc FROM Customer ORDER BY ID ASC";
            _customerEntries = (Application.Current as App).db.SelectObservableCollection<Customer>(strSelect);
            foreach (Customer data in _customerEntries)
            {
                if (data.ID == thisApp.id)
                {
                    textBlock0.Text = data.Name;
                    textBlock0.TextWrapping = TextWrapping.Wrap;
                    tbWhere.Text = data.Place;
                    
                    tbWhen.Text = data.Date + data.Hour;
                    //if(data.Priority)
                    tbPriority.Text = data.Priority;
                    tbDescription.Text = data.Desc;

                }
                // CreateControls(data.ID, data.Place, data.Date + data.Hour, data.Priority, data.Status);
            }
 
        }
    }
}