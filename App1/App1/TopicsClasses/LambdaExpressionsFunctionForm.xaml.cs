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
    public partial class LambdaExpressionsFunctionForm : ContentPage
    {
        private ObservableCollection<LambdaExpressionsModel> observableCollection;

        public LambdaExpressionsFunctionForm()
        {
            InitializeComponent();
            BindingContext = this;
            GenericModel model = new GenericModel();
            try
            {
                var assembly = typeof(LambdaExpressionsFunctionForm).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    List<LambdaExpressionsModel> asyncModels = JsonConvert.DeserializeObject<List<LambdaExpressionsModel>>(json);
                    IEnumerable<LambdaExpressionsModel> elems = asyncModels.Where(x => x.topic == "Lambda Expressions");
                    observableCollection = new ObservableCollection<LambdaExpressionsModel>(elems);
                    lvLambdaElements.ItemsSource = observableCollection;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}