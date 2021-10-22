using Elite.Budget.Mobile.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Elite.Budget.Mobile
{
    public partial class MainPage : FlyoutPage
    {
        public MainPage()
        {
           InitializeComponent();

            this.sidebar.Navigate += Sidebar_Navigate;
        }

        private async void Sidebar_Navigate(object sender, SidebarNavigateEventArgs e)
        {
            this.IsPresented = false;
            var page = (Page)Activator.CreateInstance(e.SelectedItem.TargetType);
            await this.Detail.Navigation.PushAsync(page);
        }
    }
}