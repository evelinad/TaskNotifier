﻿#pragma checksum "D:\My Documents\desktop\SQLLite2\WP7SQLiteClient\WP7SQLiteClient\NewItem.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "77131CCAA3B2026F1CB51C7DEF697F5F"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.261
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace WP7SQLiteClient {
    
    
    public partial class NewItem : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.TextBlock ApplicationTitle;
        
        internal System.Windows.Controls.TextBlock PageTitle;
        
        internal System.Windows.Controls.TextBox tbTaskName;
        
        internal System.Windows.Controls.TextBox tbPlace;
        
        internal System.Windows.Controls.TextBox tbDescriere;
        
        internal Microsoft.Phone.Controls.DatePicker datepicker1;
        
        internal Microsoft.Phone.Controls.TimePicker timepicker;
        
        internal System.Windows.Controls.Slider sPriority;
        
        internal Microsoft.Phone.Controls.ToggleSwitch switch1;
        
        internal System.Windows.Controls.Grid ContentPanel;
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Windows.Application.LoadComponent(this, new System.Uri("/WP7SQLiteClient;component/NewItem.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.ApplicationTitle = ((System.Windows.Controls.TextBlock)(this.FindName("ApplicationTitle")));
            this.PageTitle = ((System.Windows.Controls.TextBlock)(this.FindName("PageTitle")));
            this.tbTaskName = ((System.Windows.Controls.TextBox)(this.FindName("tbTaskName")));
            this.tbPlace = ((System.Windows.Controls.TextBox)(this.FindName("tbPlace")));
            this.tbDescriere = ((System.Windows.Controls.TextBox)(this.FindName("tbDescriere")));
            this.datepicker1 = ((Microsoft.Phone.Controls.DatePicker)(this.FindName("datepicker1")));
            this.timepicker = ((Microsoft.Phone.Controls.TimePicker)(this.FindName("timepicker")));
            this.sPriority = ((System.Windows.Controls.Slider)(this.FindName("sPriority")));
            this.switch1 = ((Microsoft.Phone.Controls.ToggleSwitch)(this.FindName("switch1")));
            this.ContentPanel = ((System.Windows.Controls.Grid)(this.FindName("ContentPanel")));
        }
    }
}

