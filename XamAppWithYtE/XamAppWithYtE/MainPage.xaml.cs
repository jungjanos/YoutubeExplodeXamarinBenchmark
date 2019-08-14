using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using YoutubeExplode;

namespace XamAppWithYtE
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPageViewModel ViewModel
        {
            get => BindingContext as MainPageViewModel;
            set => BindingContext = value;
        }

        public MainPage(YoutubeClient youtubeClient)
        {
            ViewModel = new MainPageViewModel(youtubeClient);

            InitializeComponent();            
        }
    }
}
