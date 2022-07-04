using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Reflection;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App1.TopicsModels;
using System.Collections.ObjectModel;

namespace App1.TopicsClasses
{
      [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AsynchronousForm : ContentPage
    {
        private ObservableCollection<AsyncModel> observableCollection;
        public AsynchronousForm()
        {           
            InitializeComponent();
            BindingContext = this;
            AsyncModel model = new AsyncModel();
            try
            {
                var assembly = typeof(AsynchronousForm).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();               
                    List<AsyncModel> asyncModels = JsonConvert.DeserializeObject<List<AsyncModel>>(json);
                    IEnumerable<AsyncModel> elems = asyncModels.Where(x=>x.topic== "Asynchronous");
                    observableCollection = new ObservableCollection<AsyncModel>(elems);
                    lvAsyncElements.ItemsSource = observableCollection;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Exception",e.Message,"Cancel");
            }
        }              
    }
}


