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
    public partial class RegularExpressionsFunctionForm : ContentPage
    {
        private ObservableCollection<RegularexpressionsModel> observableCollection;
        public RegularExpressionsFunctionForm()
        {
            InitializeComponent();
            BindingContext = this;
            GenericModel model = new GenericModel();
            try
            {
                var assembly = typeof(RegularExpressionsFunctionForm).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    List<RegularexpressionsModel> asyncModels = JsonConvert.DeserializeObject<List<RegularexpressionsModel>>(json);
                    IEnumerable<RegularexpressionsModel> elems = asyncModels.Where(x => x.topic == "Regular Expressions");
                    observableCollection = new ObservableCollection<RegularexpressionsModel>(elems);
                    lvRegexElements.ItemsSource = observableCollection;
                }

            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}