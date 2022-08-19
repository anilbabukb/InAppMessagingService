using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Firebase;
using Firebase.Messaging;
using Plugin.FirebasePushNotification;

namespace TalgorAlertApp
{
    [Application]
    public class MainApplication : MauiApplication
    {
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }


        public override void OnCreate()
        {
            base.OnCreate();

            //Set the default notification channel for your app when running Android Oreo
            if (Build.VERSION.SdkInt >= Android.OS.BuildVersionCodes.O)
            {
                //Change for your default notification channel id here
                FirebasePushNotificationManager.DefaultNotificationChannelId = "FirebasePushNotificationChannel";

                //Change for your default notification channel name here
                FirebasePushNotificationManager.DefaultNotificationChannelName = "General";

                FirebasePushNotificationManager.DefaultNotificationChannelImportance = NotificationImportance.Max;

            }

            
           //FirebaseOptions baseOptions = FirebaseOptions.FromResource(Android.App.Application.Context);
           // FirebaseOptions options = new FirebaseOptions.Builder(baseOptions).SetProjectId(baseOptions.StorageBucket.Split('.')[0]).Build();
           // FirebaseApp.ClearInstancesForTest();
           // FirebaseApp app = FirebaseApp.InitializeApp(Android.App.Application.Context, options);
            //App.PublishToken =  FirebaseMessaging.Instance.GetToken().ToString();

            //If debug you should reset the token each time.
#if DEBUG
            FirebasePushNotificationManager.Initialize(this, true);
#else
            FirebasePushNotificationManager.Initialize(this,false);
#endif
            //Handle notification when app is closed here
            CrossFirebasePushNotification.Current.OnNotificationReceived += (s, p) =>
            {
            };
          
        }
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
    }
}