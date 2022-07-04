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
    public partial class ExceptionHandlingFunctionForm : ContentPage
    {
        private ObservableCollection<ExceptionHandlingModel> observableCollection;
        public ExceptionHandlingFunctionForm()
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
                    List<ExceptionHandlingModel> asyncModels = JsonConvert.DeserializeObject<List<ExceptionHandlingModel>>(json);
                    IEnumerable<ExceptionHandlingModel> elems = asyncModels.Where(x => x.topic == "Exception Handling");
                    observableCollection = new ObservableCollection<ExceptionHandlingModel>(elems);
                    lvExceptionElements.ItemsSource = observableCollection;
                }
            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}