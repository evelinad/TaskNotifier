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
using Microsoft.Phone.Controls.Maps;
using System.Device.Location;

namespace WP7SQLiteClient
{
    public partial class ViewMap : PhoneApplicationPage
    {
        App thisApp = App.Current as App;
        bool ok = false;
        public ViewMap()
        {
            InitializeComponent();
            GeoCoordinateWatcher gcw;
            gcw = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            // gcw.PositionChanged += new EventHandler( "");
            gcw.Start();
            GeoCoordinate co;
            co = gcw.Position.Location;
            if (thisApp.Long == -1000 && thisApp.Lat == -1000) { MessageBox.Show("Geographical coordinates have not been set yet."); }
            else { co = new GeoCoordinate((double)thisApp.Lat, (double)thisApp.Long);

            var pushPin = new Pushpin();

            var location = co;
            PushpinLayer.AddChild(pushPin, location);
            
            
            }
            // co.Latitude = 45;
            // co.Longitude = 25;

            map1.SetView(co, 10);


        }

        private void GestureListener_Hold(object sender, GestureEventArgs e)
        {
            if (ok == false)
            {
                ok = true;
                var pushPin = new Pushpin();
                var position = e.GetPosition(map1);
                var location = map1.ViewportPointToLocation(position);
                thisApp.Lat = (decimal)location.Latitude;
                thisApp.Long = (decimal)location.Longitude;
                PushpinLayer.AddChild(pushPin, location);
            }
        }

        private void GestureListener_DoubleTap(object sender, GestureEventArgs e)
        {

        }





        private void ClearLocation_Click(object sender, EventArgs e)
        {
            ok = false;
            PushpinLayer.Children.Clear();
        }


        private void SelectLocation_Click(object sender, EventArgs e)
        {

            NavigationService.GoBack();
            thisApp.ok_set_coord = true;

        }

    }
}