using Elite.Budget.Mobile.Import;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elite.Budget.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ImportPage : ContentPage
    {
        public ImportPage()
        {
            InitializeComponent();
            this.importButton.Clicked += ImportButton_Clicked;
        }

        private async void ImportButton_Clicked(object sender, EventArgs e)
        {
            var options = new PickOptions
            {
                PickerTitle = "Pick a CSV file to import"
            };

            var result = await FilePicker.PickAsync(options);

            IImporter importer = new CSVImporter();

            using (var file = await result.OpenReadAsync())
                await importer.Import(file);

 
        }
    }
}