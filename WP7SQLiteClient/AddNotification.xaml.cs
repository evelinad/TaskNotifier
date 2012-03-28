
using System;
using System.Windows;
using Microsoft.Phone.Controls;

using Microsoft.Phone.Scheduler;

namespace sdkScheduledNotificationsCS
{
    public partial class AddNotification : PhoneApplicationPage
    {
        public AddNotification()
        {
            InitializeComponent();
        }

        private void ApplicationBarSaveButton_Click(object sender, EventArgs e)
        {
           
            String name = System.Guid.NewGuid().ToString();

            DateTime date = (DateTime)beginDatePicker.Value;
            DateTime time = (DateTime)beginTimePicker.Value;
            DateTime beginTime = date + time.TimeOfDay;

            if (beginTime < DateTime.Now)
            {
                MessageBox.Show("The begin date must be in the future.");
                return;
            }

            date = (DateTime)expirationDatePicker.Value;
            time = (DateTime)expirationTimePicker.Value;
            DateTime expirationTime = date + time.TimeOfDay;


            if (expirationTime < beginTime)
            {
                MessageBox.Show("Expiration time must be after the begin time.");
                return;
            }

            
            RecurrenceInterval recurrence = RecurrenceInterval.None;
            if (dailyRadioButton.IsChecked == true)
            {
                recurrence = RecurrenceInterval.Daily;
            }
            else if (weeklyRadioButton.IsChecked == true)
            {
                recurrence = RecurrenceInterval.Weekly;
            }
            else if (monthlyRadioButton.IsChecked == true)
            {
                recurrence = RecurrenceInterval.Monthly;
            }
            else if (endOfMonthRadioButton.IsChecked == true)
            {
                recurrence = RecurrenceInterval.EndOfMonth;
            }
            else if (yearlyRadioButton.IsChecked == true)
            {
                recurrence = RecurrenceInterval.Yearly;
            }


            string param1Value = "";
            string param2Value = "";
            string queryString = "";
            if (param1Value != "" && param2Value != "")
            {
                queryString = "?param1=" + param1Value + "&param2=" + param2Value;
            }
            else if (param1Value != "" || param2Value != "")
            {
                queryString = (param1Value != null) ? "?param1=" + param1Value : "?param2=" + param2Value;
            }

            Uri navigationUri = new Uri("/ShowParams.xaml" + queryString, UriKind.Relative);

                Reminder reminder = new Reminder(name);
                reminder.Title = titleTextBox.Text;
                reminder.Content = contentTextBox.Text;
                reminder.BeginTime = beginTime;
                reminder.ExpirationTime = expirationTime;
                reminder.RecurrenceType = recurrence;
                reminder.NavigationUri = navigationUri;                           
                ScheduledActionService.Add(reminder);
            

            // Navigate back to the main reminder list page.
           // NavigationService.GoBack();
                NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void reminderRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            titleTextBox.IsEnabled = true;
        }

        private void alarmRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            titleTextBox.Text = "";
            titleTextBox.IsEnabled = false;
        }

        private void Cancel(object sender, EventArgs e)
        {
       
            NavigationService.Navigate(new Uri("/NewItem.xaml",UriKind.RelativeOrAbsolute));

       
        }
    }


}
