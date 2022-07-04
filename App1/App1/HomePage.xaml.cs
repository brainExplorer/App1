using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();    
            MainPage mainPage = new MainPage();
            mainPage.Navigation.RemovePage(mainPage);
        }      

        async void AsynchronousFunction(object sender, EventArgs e)
        {            
            await Navigation.PushModalAsync(new TopicsClasses.AsynchronousForm());
        }


        async void DelegatesFunction(object s, EventArgs e)
        {
            await Navigation.PushModalAsync(new TopicsClasses.DelegatesFunctionForm());
        }

        async void DesignPatternsFunction(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new TopicsClasses.DesignPatternsFunction());
        }

        async void DynamicFunction(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new TopicsClasses.DynamicFunctionForm());
        }

        async void EventFunction(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new App1.TopicsClasses.EventFunctionForm());
        }

        async void ExceptionHandlingFunction(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new App1.TopicsClasses.ExceptionHandlingFunctionForm());
        }

        async void ExtensionsFunction(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new App1.TopicsClasses.ExtensionsFunctionForm());
        }

        async void GenericFunction(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new App1.TopicsClasses.GenericFunctionForm());
        }

        async void InheritanceFunction(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new App1.TopicsClasses.InheritanceFunctionForm());
        }

        async void LambdaExpressionsFunction(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new App1.TopicsClasses.LambdaExpressionsFunctionForm());
        }

        async void LinqFunction(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new App1.TopicsClasses.LinqFunctionForm());
        }
        async void NullableFunction(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new App1.TopicsClasses.NullableFunctionForm());
        }
        async void ObjectLifeTimeFunction(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new App1.TopicsClasses.ObjectLifeTimeFunctionForm());
        }
        async void PartialClassesFunction(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new App1.TopicsClasses.PartialClassesFunctionForm());
        }
        async void RegularExpressionsFunction(object o, EventArgs e)
        {
            await Navigation.PushModalAsync(new App1.TopicsClasses.RegularExpressionsFunctionForm());
        }
        async void TypeConversionsFunction(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new App1.TopicsClasses.TypeConversationsForm());        
        }
    }  
}