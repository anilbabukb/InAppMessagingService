﻿
using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalgorAlertApp
{
    internal class FCM
    {
        
    //    FirebaseApp.Create(new AppOptions()
    //    {
    //        Credential = GoogleCredential.FromFile("private_key.json")
    //        });

    //        // This registration token comes from the client FCM SDKs.
    //        //var registrationToken = "TOKEN_HERE";

    //        // See documentation on defining a message payload.
    //        var message = new Message()
    //        {
    //            Data = new Dictionary<string, string>()
    //{
    //    { "myData", "1337" },
    //},
    //            //Token = registrationToken,
    //            Topic = "all",
    //            Notification = new Notification()
    //            {
    //                Title = "Test from code",
    //                Body = "Here is your test!"
    //            }
    //        };

    //    // Send a message to the device corresponding to the provided
    //    // registration token.
    //    string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
    //    // Response is a message ID string.
    //    Console.WriteLine("Successfully sent message: " + response);
    //    }

}
}
