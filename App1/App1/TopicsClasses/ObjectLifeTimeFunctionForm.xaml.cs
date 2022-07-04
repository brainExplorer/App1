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
    public partial class ObjectLifeTimeFunctionForm : ContentPage
    {
        private ObservableCollection<ObjectLifeTimeModel> observableCollection;

        public ObjectLifeTimeFunctionForm()
        {
            InitializeComponent();
            BindingContext = this;
            GenericModel model = new GenericModel();
            try
            {
                var assembly = typeof(ObjectLifeTimeFunctionForm).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    List<ObjectLifeTimeModel> asyncModels = JsonConvert.DeserializeObject<List<ObjectLifeTimeModel>>(json);
                    IEnumerable<ObjectLifeTimeModel> elems = asyncModels.Where(x => x.topic == "Object Life Time");
                    observableCollection = new ObservableCollection<ObjectLifeTimeModel>(elems);
                    lvOLTElements.ItemsSource = observableCollection;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}