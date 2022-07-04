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
    public partial class ExtensionsFunctionForm : ContentPage
    {
        private ObservableCollection<ExtensionsFunctionClassModel> observableCollection;

        public ExtensionsFunctionForm()
        {
            InitializeComponent();
            BindingContext = this;
            ExceptionHandlingModel model = new ExceptionHandlingModel();
            try
            {
                var assembly = typeof(ExceptionHandlingFunctionForm).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    List<ExtensionsFunctionClassModel> asyncModels = JsonConvert.DeserializeObject<List<ExtensionsFunctionClassModel>>(json);
                    IEnumerable<ExtensionsFunctionClassModel> elems = asyncModels.Where(x => x.topic == "Extensions");
                    observableCollection = new ObservableCollection<ExtensionsFunctionClassModel>(elems);
                    lvExtensionElements.ItemsSource = observableCollection;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}