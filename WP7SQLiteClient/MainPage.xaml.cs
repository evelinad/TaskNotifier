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
using System.Collections.ObjectModel;//ObservableCollection
using System.ComponentModel;
using SQLiteClient;
using Community.CsharpSqlite;
using System.Collections;
using WP7SQLiteClient.Dal;
namespace WP7SQLiteClient
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        ObservableCollection<Customer> _customerEntries = null;
        public MainPage()
        {


            InitializeComponent();
            

            //retrieve dat
         
            
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            //button4.Background = new SolidColorBrush(Color.FromArgb(0,255,125,0));
            
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
      //      CreateControls();
           
        }

        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void CreateControls( string str_name,int id, string str_where, string str_when, string str_pr, string str_st)
        {
            TextBlock where = new TextBlock();
            where.Text ="Where: " + str_where;
            TextBlock when = new TextBlock();
            when.Text = "When: "+str_when;
            TextBlock priority = new TextBlock();
            if (str_pr == "1") str_pr = "low";
            if (str_pr == "2") str_pr = "medium";
            if (str_pr == "3") str_pr = "high";
            priority.Text = "Priority: "+str_pr;
            TextBlock status = new TextBlock();
            status.Text = "Reminder: "+str_st;
            MyStackPanel stp1 = new MyStackPanel();
            stp1.id = id;
            
            
            stp1.DoubleTap += new EventHandler<System.Windows.Input.GestureEventArgs>(stp1_DoubleTap);
                //new EventHandler(stp1_MouseEnter);
            TextBlock name = new TextBlock();
            name.FontSize = 26;
            name.Text =  str_name;
            name.Foreground = new SolidColorBrush(Color.FromArgb(255, 255,0, 0));
            name.TextWrapping = where.TextWrapping= when.TextWrapping= priority.TextWrapping=status.TextWrapping=TextWrapping.Wrap;
         
            stp1.Height = name.Height + where.Height + priority.Height + when.Height + status.Height+300;
            
            stp1.Children.Add(name);
            stp1.Children.Add(where);
            stp1.Children.Add(when);
            stp1.Children.Add(priority);
            stp1.Children.Add(status);
            
            
           /* Button btnClick = new Button();
            btnClick.Content = "Click";
            btnClick.BorderThickness = new Thickness(0);
            
            btnClick.Foreground = new SolidColorBrush(Color.FromArgb(255, 255 , 255 ,255));
            
            StackPanel stp2 = new StackPanel();
            */
        //    stp2.Children.Add(where);
          //  stp2.Children.Add(when);
           // stp2.Children.Add(priority);
           // stp2.Children.Add(status);
          //  Canvas c = new Canvas();
           // c.Width = 438;
           // c.Height = 70;
           // c.Background = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
           // c.Children.Add(btnClick);
           // stackPanel1.Children.Add(c);
           
            stackPanel1.Children.Add(stp1);
        }

        void stp1_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            try
                {
            MyStackPanel mystp = (MyStackPanel)sender;
            App thisApp = App.Current as App;
            thisApp.id = mystp.id;
            string strSelect = "SELECT ID,Name,Place,Lat, Long, Date, Hour, Status, Priority, Desc FROM Customer ORDER BY ID ASC";
            _customerEntries = (Application.Current as App).db.SelectObservableCollection<Customer>(strSelect);
            foreach (Customer data in _customerEntries)
            {
                if (data.ID == thisApp.id)
                {

                    thisApp.Lat = Decimal.Parse(data.Lat);
                    thisApp.Long = Decimal.Parse(data.Long);

                }
            }
            NavigationService.Navigate(new Uri("/Page3.xaml", UriKind.RelativeOrAbsolute));
                }
                catch(Exception )
            {
                    
                }
                    //throw new NotImplementedException();
        
        }

        void stp1_MouseEnter(object sender, EventArgs e)
        {
            
        }


        

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {

        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {

        }

         private void NewTask(object sender, EventArgs e)
        {
            //NavigationService.Navigate(new Uri("/AddNotification.xaml", UriKind.RelativeOrAbsolute));
            NavigationService.Navigate(new Uri("/NewItem.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Settings(object sender, EventArgs e)
        {

        }

        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void GroupBy(object sender, EventArgs e)
        {

        }

        private void MyLocations(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/NewItem.xaml", UriKind.RelativeOrAbsolute));

        }

        private void LayoutRoot_Loaded(object sender, RoutedEventArgs e)
        {
            stackPanel1.Children.Clear();
            string strSelect = "SELECT ID,Name,Place,Lat, Long, Date, Hour, Status, Priority, Desc FROM Customer ORDER BY ID ASC";
            _customerEntries = (Application.Current as App).db.SelectObservableCollection<Customer>(strSelect);
            int nr = 0;
            foreach (Customer data in _customerEntries)
            {
                CreateControls(data.Name, data.ID, data.Place, data.Date + data.Hour, data.Priority, data.Status);
                nr++;
            }
            if (nr == 0)
            {
                TextBlock txtbox = new TextBlock();
                txtbox.Text = "No tasks available. ";
                txtbox.FontSize = 26;
                stackPanel1.Children.Add(txtbox);
            }

        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            // Navigate to the AddReminder page when the add button is clicked.
         
        
        }
    }
    class MyStackPanel : StackPanel
    {
       public int id;
    }
}
