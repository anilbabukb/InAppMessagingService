

using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.Maui.Storage;
using Plugin.FirebasePushNotification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalgorAlertApp.Modles;

namespace TalgorAlertApp.Services
{
    class FCMTokenGeneration
    {
        //public async Task<string> GetToken()
        //{
        //    //try
        //    //{
         
        //    //GoogleCredential credential;
        //    //    credential = GoogleCredential.FromFile("private_key.json").CreateScoped(
        //    //        new string[] {
        //    //    "https://www.googleapis.com/auth/firebase.database",
        //    //    "https://www.googleapis.com/auth/userinfo.email" });
                
        //    //    ITokenAccess c = credential as ITokenAccess;
        //    //    var registrationToken = c.GetAccessTokenForRequestAsync();
        //    //    return await c.GetAccessTokenForRequestAsync();
        //    //}
        //    //catch(Exception ex)
        //    //{
        //    //    return ex.Message;
        //    //}

        //}
        public async Task<string> SendNotification( User user)
        {
            try
            {
                FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile("private_key.json"),
                });
                

                // See documentation on defining a message payload.
                var message = new Message()
                {
                    Data = new Dictionary<string, string>()
    {
        { "myData", "1337" },
    },
                    Token = user.FCMToken,
                    //Topic = "all",
                    Notification = new Notification()
                    {
                        Title = "Test from code",
                        Body = "Here is your test!"
                    }
                };

                // Send a message to the device corresponding to the provided
                // registration token.
                string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
                // Response is a message ID string.
                return response;

            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
    //[Service]

    //[IntentFilter(new[] { "com.google.firebase.INSTANCE_ID_EVENT" })]
    //public class MyFirebaseIIDService : FirebaseMessagingService
    //{
     
    //    string refreshedToken;      

    //    public override void OnNewToken(string p0)
    //    {
       
    //         refreshedToken = p0;          

    //    }
    //}
}
