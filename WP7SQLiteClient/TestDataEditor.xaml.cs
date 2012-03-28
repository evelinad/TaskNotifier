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
using System.Collections.ObjectModel;//ObservableCollection
using System.ComponentModel;
using SQLiteClient;
using Community.CsharpSqlite;
using System.Collections;

namespace WP7SQLiteClient
{
    public partial class TestDataEditor : PhoneApplicationPage
    {

        ObservableCollection<Customer> _customerEntries = null;
        public TestDataEditor()
        {
            InitializeComponent();

            //retrieve dat
            string strSelect = "SELECT ID,Name,Place,Lat, Long, Date, Hour, Status, Priority, Desc FROM Customer ORDER BY ID ASC";
            _customerEntries = (Application.Current as App).db.SelectObservableCollection<Customer>(strSelect);

            foreach (Customer data in _customerEntries)
            {
                TextBlockID.Text += data.ID + Environment.NewLine;
                TextBlockName.Text +=data.Name + Environment.NewLine;
                TextBlockEmail.Text +=data.Place + Environment.NewLine;
                TextBlockDesc.Text +=data.Desc + Environment.NewLine;
            }

        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = DateTime.Now;
            int rec;
            Random rnd = new Random();
            string strInsert = " Insert into Customer (Name,Place,Lat, Long, Date, Hour, Status, Priority,Desc) values (@Name,@Place,@Lat,@Long,@Date,@Hour,@Status,@Priority,@Desc)";

            for (int i = 0; i < 5; i++)
            {
                Customer tst = new Customer
                {
                    Name = "Name " + i,
                    Place = Name + "@" + "aaa.com",
                    Lat = Name + "@" + "aaa.com",
                    Long = Name + "@" + "aaa.com",
                    Date = Name + "@" + "aaa.com",
                    Hour = Name + "@" + "aaa.com",
                    Status = Name + "@" + "aaa.com",
                    Priority = Name + "@" + "aaa.com",
                    Desc = "Desc for " + i
                };
                rec = (Application.Current as App).db.Insert < Customer>(tst,strInsert);
            }
            System.Diagnostics.Debug.WriteLine("\nInserted 5 " + " rows\r\nGenerated in " + (DateTime.Now - start).TotalSeconds);
        }

        private void btnDel_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = DateTime.Now;
            string strDel = " Delete from Customer where ID="+ "(SELECT COUNT(*) FROM Customer)" ;
            (Application.Current as App).db.Delete<Customer>(strDel);

            System.Diagnostics.Debug.WriteLine("\nDelete last " + " record\r\n in " + (DateTime.Now - start).TotalSeconds);
        }

    }
}