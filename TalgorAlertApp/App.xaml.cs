
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using Plugin.FirebasePushNotification;

namespace TalgorAlertApp
{
    public partial class App : Application
    {
        public static string PublishToken;
        public static string Url= "http://103.185.74.18/TalgorNotification/api";
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
          
            CrossFirebasePushNotification.Current.Subscribe("all");
            // Token event
            CrossFirebasePushNotification.Current.RegisterForPushNotifications();
            CrossFirebasePushNotification.Current.OnTokenRefresh += Current_OnTokenRefresh;
            App.PublishToken =  CrossFirebasePushNotification.Current.Token;
           // GetUserToken();
           // Push message received event
             CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
           
                System.Diagnostics.Debug.WriteLine("Received");

            };
            //Push message received event
            CrossFirebasePushNotification.Current.OnNotificationOpened += (s, p) =>
            {
                System.Diagnostics.Debug.WriteLine("Opened");
                foreach (var data in p.Data)
                {
                    System.Diagnostics.Debug.WriteLine($"{data.Key} : {data.Value}");
                }

            };

        }

        private void Current_OnTokenRefresh(object source, FirebasePushNotificationTokenEventArgs e)
        {
            
            PublishToken = e.Token;
            System.Diagnostics.Debug.WriteLine($"TOKEN : {e.Token}");
        }
        
        
    }
}
