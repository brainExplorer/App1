using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Windows.Input;
using App1.User;

namespace App1
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public static MainPage mainPage = null;
        public MainPage()
        {
            InitializeComponent();
            mainPage = this;
            var vm = new LoginViewModel();
            this.BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Invalid Login, try again", "OK");
            eUserName.Completed += (object sender, EventArgs e) =>
            {
                ePassword.Focus();
            };

            ePassword.Completed += (object sender, EventArgs e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }
        private void NewAccountCommand(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new CreateUserForm());
        }
        private void ForgotPasswordCommand(object sender, EventArgs e)
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new ForgotPasswordForm());
        }
    }
}