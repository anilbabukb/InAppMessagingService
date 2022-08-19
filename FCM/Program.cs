using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using System.Net;


namespace FCM
{
    class Program
    {
        static  void Main(string[] args)
        {
             
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("private_key.json"),                
            });
            // This registration token comes from the client FCM SDKs.
            //var registrationToken = "dW3nsKbUQ4Wdv7ztg9JS4R:APA91bHTq4HMg5ZJ6rPm7ZoBPPY309yskm3r3K2K8ElPQNaCYqWwP0rPEuIObsVKjPVO7s7KMXdaU9CRwmeBT35k2rxZl-20qRs_v3LEtvR9opmuoTXGTl7qbgyC0Sx4DHKdovlrlUP9\r\ndW3nsKbUQ4Wdv7ztg9JS4R:APA91bHTq4HMg5ZJ6rPm7ZoBPPY309yskm3r3K2K8ElPQNaCYqWwP0rPEuIObsVKjPVO7s7KMXdaU9CRwmeBT35k2rxZl-20qRs_v3LEtvR9opmuoTXGTl7qbgyC0Sx4DHKdovlrlUP9";

            // See documentation on defining a message payload.
            var message = new Message()
            {
                Data = new Dictionary<string, string>()
    {
        { "myData", "1337" },
    },
                Token = "dW3nsKbUQ4Wdv7ztg9JS4R:APA91bHTq4HMg5ZJ6rPm7ZoBPPY309yskm3r3K2K8ElPQNaCYqWwP0rPEuIObsVKjPVO7s7KMXdaU9CRwmeBT35k2rxZl-20qRs_v3LEtvR9opmuoTXGTl7qbgyC0Sx4DHKdovlrlUP9",
                //Topic = "all",
                Notification = new Notification()
                {
                    Title = "Test from code",
                    Body = "Here is your test!"
                }
            };

            // Send a message to the device corresponding to the provided
            // registration token.
            string response = FirebaseMessaging.DefaultInstance.SendAsync(message).Result;
            // Response is a message ID string.
            Console.WriteLine("Successfully sent message: " + response);
        }
    }
}