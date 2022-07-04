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
    public partial class DesignPatternsFunction : ContentPage
    {
        private ObservableCollection<DesignPatternModel> observableCollection;
        public DesignPatternsFunction()
        {
            InitializeComponent();
            BindingContext = this;
            DesignPatternModel model = new DesignPatternModel();
            try
            {
                var assembly = typeof(DesignPatternsFunction).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    List<DesignPatternModel> delModels = JsonConvert.DeserializeObject<List<DesignPatternModel>>(json);
                    IEnumerable<DesignPatternModel> elems = delModels.Where(x => x.topic == "Design Patterns");
                    observableCollection = new ObservableCollection<DesignPatternModel>(elems);
                    lvDesignElements.ItemsSource = observableCollection;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}