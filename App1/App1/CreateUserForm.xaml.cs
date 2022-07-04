using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.User;
using System.ComponentModel;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CreateUserForm : ContentPage
    {
        public CreateUserForm()
        {
            InitializeComponent();
        }
        public async void Register_Clicked(object sender, EventArgs e)
        {
            if (EntryConfirm.Text == EntryPass.Text)
            {
                await Xamarin.Essentials.SecureStorage.SetAsync("Password", EntryPass.Text);
                await Xamarin.Essentials.SecureStorage.SetAsync("UserName", EntryUser.Text);
                await Navigation.PopModalAsync(IsEnabled);
            }
            else
            {
              await  DisplayAlert("Error", "Password doesnt match", "cancel");
            }
        }
    }
}