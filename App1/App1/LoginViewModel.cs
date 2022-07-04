using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace App1
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        public Action DisplayInvalidLoginPrompt;
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private string username;
        private string password;
        public string UserName
        {
            get { return username; }
            set
            {
                username = value;
                PropertyChanged(this, new PropertyChangedEventArgs("UserName"));
            }
        }
       
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));
            }
        }
        public ICommand SubmitCommand { protected set; get; }
        public LoginViewModel()
        {
            SubmitCommand = new Command(OnSubmit);
            
        }
        public void OnSubmit()
        {
            
            if (Password == Xamarin.Essentials.SecureStorage.GetAsync("Password").Result && UserName == Xamarin.Essentials.SecureStorage.GetAsync("UserName").Result)
            {
                Application.Current.MainPage.Navigation.PushModalAsync(new HomePage());               
            }
            else
            {
                DisplayInvalidLoginPrompt();
            }
        }
    }
}