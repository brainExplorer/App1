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
    public partial class DynamicFunctionForm : ContentPage
    {
        private ObservableCollection<DynamicModel> observableCollection;
        public DynamicFunctionForm()
        {
            InitializeComponent();
            BindingContext = this;
            DynamicModel dynamicModel = new DynamicModel();
            var assembly = typeof(DynamicFunctionForm).GetTypeInfo().Assembly;
            Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
            try 
            { 
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    List<DynamicModel> dModels = JsonConvert.DeserializeObject<List<DynamicModel>>(json);
                    IEnumerable<DynamicModel> elems = dModels.Where(x => x.topic == "Dynamic");
                    observableCollection = new ObservableCollection<DynamicModel>(elems);
                    lvDynamicElements.ItemsSource = observableCollection;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}