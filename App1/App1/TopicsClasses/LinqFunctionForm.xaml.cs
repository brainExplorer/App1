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
    public partial class LinqFunctionForm : ContentPage
    {
        private ObservableCollection<LinqModel> observableCollection;

        public LinqFunctionForm()
        {
            InitializeComponent();
            BindingContext = this;
            GenericModel model = new GenericModel();
            try
            {
                var assembly = typeof(LinqFunctionForm).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    List<LinqModel> asyncModels = JsonConvert.DeserializeObject<List<LinqModel>>(json);
                    IEnumerable<LinqModel> elems = asyncModels.Where(x => x.topic == "Linq");
                    observableCollection = new ObservableCollection<LinqModel>(elems);
                    lvLinqElements.ItemsSource = observableCollection;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}