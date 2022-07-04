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
    public partial class PartialClassesFunctionForm : ContentPage
    {
        private ObservableCollection<PartialClassModel> observableCollection;

        public PartialClassesFunctionForm()
        {
            InitializeComponent();
            BindingContext = this;
            GenericModel model = new GenericModel();
            try
            {
                var assembly = typeof(PartialClassesFunctionForm).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    List<PartialClassModel> asyncModels = JsonConvert.DeserializeObject<List<PartialClassModel>>(json);
                    IEnumerable<PartialClassModel> elems = asyncModels.Where(x => x.topic == "Partial Classes");
                    observableCollection = new ObservableCollection<PartialClassModel>(elems);
                    lvpartialClassElements.ItemsSource = observableCollection;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}