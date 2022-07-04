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

    public partial class DelegatesFunctionForm : ContentPage
    {
        private ObservableCollection<DelegateFunctionModel> observableCollection;

        public DelegatesFunctionForm()
        {
            InitializeComponent();
            BindingContext = this;
            DelegateFunctionModel model = new DelegateFunctionModel();
            try
            {
                var assembly = typeof(DelegatesFunctionForm).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    List<DelegateFunctionModel> delModels = JsonConvert.DeserializeObject<List<DelegateFunctionModel>>(json);
                    IEnumerable<DelegateFunctionModel> elems = delModels.Where(x => x.topic == "Delegates");
                    observableCollection = new ObservableCollection<DelegateFunctionModel>(elems);
                    lvDelegateElements.ItemsSource = observableCollection;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}