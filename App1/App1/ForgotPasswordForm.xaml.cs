using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForgotPasswordForm : ContentPage
    {
        public ForgotPasswordForm()
        {
            InitializeComponent();
        }

        private async void ButtonRenew_Clicked(object sender, EventArgs e)
        {
            if (EntryConfirm.Text == EntryPass.Text && EntryUser.Text == Xamarin.Essentials.SecureStorage.GetAsync("UserName").Result)
            {
                await Xamarin.Essentials.SecureStorage.SetAsync("Password", EntryPass.Text);                
                await Navigation.PopModalAsync(IsEnabled);
            }
            else
            {
                await DisplayAlert("Error", "Password doesnt match", "cancel");
            }
        }
    }
}