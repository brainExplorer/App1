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
    public partial class GenericFunctionForm : ContentPage
    {
        private ObservableCollection<GenericModel> observableCollection;

        public GenericFunctionForm()
        {
            InitializeComponent();
            BindingContext = this;
            GenericModel model = new GenericModel();
            try
            {
                var assembly = typeof(GenericFunctionForm).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    List<GenericModel> asyncModels = JsonConvert.DeserializeObject<List<GenericModel>>(json);
                    IEnumerable<GenericModel> elems = asyncModels.Where(x => x.topic == "Generic");
                    observableCollection = new ObservableCollection<GenericModel>(elems);
                    lvGenericElements.ItemsSource = observableCollection;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}