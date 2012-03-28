using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;//INotifyPropertyChanged
namespace WP7SQLiteClient.Dal
{
 
    /// <summary>
    /// Gets the TestDataEntries property.
    /// Changes to that property's value raise the PropertyChanged event.
    /// <summary>

    //public class TestData : INotifyPropertyChanged
    public class Customer
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Place { get; set; }
        public string Lat{ get; set; }
        public string Long { get; set; }
        public string Date { get; set; }
        public string Hour { get; set; }
        public string Status { get; set; }
        public string Priority { get; set; }
        public string Desc { get; set; }
        public Customer() { }
        public Customer(int Id, string name, string place, string Long, string lat, string date, string hour, string status, string priority,string desc)
        {
            ID = Id;
            Name = name;
            Place = place;
            Lat = "a";
            Long = "a";
            Date = "a";
            Hour = "a";
            Status = "a";
            Priority = "a";
            Desc = desc;
        }
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void RaisePropertyChanged(string propertyName)   
        //{   
        //    var handler = PropertyChanged;   
        //    if (handler != null)   
        //    {   
        //        handler(this, new PropertyChangedEventArgs(propertyName));   
        //    }   
        //}   
    }
    public class TestData
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Bytes { get; set; }
        public DateTime Modified { get; set; }
        public bool Condition { get; set; }
        public byte[] Stream { get; set; }
        public TestData() { }
        public TestData(int Id, string name, decimal bytes, DateTime modified, bool condition, byte[] stream)
        {
            ID = Id;
            Name = name;
            Bytes = bytes;
            Modified = modified;
            Condition = condition;
            Stream = stream;
        }
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void RaisePropertyChanged(string propertyName)   
        //{   
        //    var handler = PropertyChanged;   
        //    if (handler != null)   
        //    {   
        //        handler(this, new PropertyChangedEventArgs(propertyName));   
        //    }   
        //}   
    }
}
