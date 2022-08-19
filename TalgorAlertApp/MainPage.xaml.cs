
using Plugin.FirebasePushNotification;
using TalgorAlertApp.Modles;
using TalgorAlertApp.Services;

namespace TalgorAlertApp
{
    
    public partial class MainPage : ContentPage
    {
        int count = 0;
        UserLoginServices userLoginServices = new UserLoginServices();
        User userObject = new User();
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LoginBtnClicked(object sender, EventArgs e)
        {
            FCMTokenGeneration fmessage = new FCMTokenGeneration();
            //StartTimeLabel.Text = fmessage.GetUserToken().Result.ToString();         

            userObject.UserId = 1;
            userObject.UserName = IdEntry.Text;
            userObject.Password= PasswordEntry.Text;
            userObject.FCMToken= App.PublishToken;
            var response = await userLoginServices.AutenticateUser(userObject);
            StartTimeLabel.Text = App.PublishToken;
            //if status is true then redirect
            if (response.status)
            {
                userObject = System.Text.Json.JsonSerializer.Deserialize<User>(response.message);
                var res=fmessage.SendNotification(userObject);
                Errortxt.Text= res.Result.ToString();
            }
            else
            {
                Errortxt.IsVisible = true;
                Errortxt.Text = "Invalid User";
            }

           

        }
    }
}