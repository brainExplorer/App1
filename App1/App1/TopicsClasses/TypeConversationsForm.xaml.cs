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
    public partial class TypeConversationsForm : ContentPage
    {
        private ObservableCollection<TypeConversationsModel> observableCollection;
        public TypeConversationsForm()
        {
            InitializeComponent();
            BindingContext = this;
            GenericModel model = new GenericModel();
            try
            {
                var assembly = typeof(TypeConversationsForm).GetTypeInfo().Assembly;
                Stream stream = assembly.GetManifestResourceStream("App1.LectureExplains.json");
                using (var reader = new StreamReader(stream))
                {
                    var json = reader.ReadToEnd();
                    List<TypeConversationsModel> asyncModels = JsonConvert.DeserializeObject<List<TypeConversationsModel>>(json);
                    IEnumerable<TypeConversationsModel> elems = asyncModels.Where(x => x.topic == "Type Conversations");
                    observableCollection = new ObservableCollection<TypeConversationsModel>(elems);
                    lvTypeConvElements.ItemsSource = observableCollection;
                }

            }
            catch (Exception e)
            {
                DisplayAlert("Exception", e.Message, "Cancel");
            }
        }
    }
}