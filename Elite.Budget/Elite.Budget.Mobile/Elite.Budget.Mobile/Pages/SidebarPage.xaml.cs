using Elite.Budget.Mobile.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elite.Budget.Mobile.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SidebarPage : ContentPage
    {
        public event EventHandler<SidebarNavigateEventArgs> Navigate;

        public SidebarPage()
        {
            InitializeComponent();
            this.listView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                var handler = this.Navigate;

                if (handler != null)
                {
                    handler(this, new SidebarNavigateEventArgs
                    {
                        SelectedItem = e.SelectedItem as SidebarMenuItem
                    });
                }

                this.listView.SelectedItem = null;
            }
        }
    }

    public class SidebarNavigateEventArgs : EventArgs
    {
        public SidebarMenuItem SelectedItem { get; set; }
    }
}