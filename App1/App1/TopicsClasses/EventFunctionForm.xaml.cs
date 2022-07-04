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
    public partial class EventFunctionForm : ContentPage
    {
        private ObservableCollection<EventFunctionModel> observableCollection;
        public EventFunctionForm()
        {
            InitializeComponent();
            BindingContext = this;
            EventFunctionModel model = new EventFunctionModel();
            try
            {
                var assembly = typeof(EventFunctionForm).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    List<EventFunctionModel> asyncModels = JsonConvert.DeserializeObject<List<EventFunctionModel>>(json);
                    IEnumerable<EventFunctionModel> elems = asyncModels.Where(x => x.topic == "Event");
                    observableCollection = new ObservableCollection<EventFunctionModel>(elems);
                    lvEventElements.ItemsSource = observableCollection;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}