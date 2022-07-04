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
    public partial class InheritanceFunctionForm : ContentPage
    {
        private ObservableCollection<InheritanceModel> observableCollection;

        public InheritanceFunctionForm()
        {
            InitializeComponent();
            BindingContext = this;
            GenericModel model = new GenericModel();
            try
            {
                var assembly = typeof(InheritanceFunctionForm).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    List<InheritanceModel> asyncModels = JsonConvert.DeserializeObject<List<InheritanceModel>>(json);
                    IEnumerable<InheritanceModel> elems = asyncModels.Where(x => x.topic == "Inheritance");
                    observableCollection = new ObservableCollection<InheritanceModel>(elems);
                    lvInheritanceElements.ItemsSource = observableCollection;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}