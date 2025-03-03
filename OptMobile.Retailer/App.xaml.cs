using OptMobile.Retailer.Control;
using OptMobile.Retailer.Views;

namespace OptMobile.Retailer
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            if(Application.Current != null) 
            Application.Current.UserAppTheme = AppTheme.Light;
            MainPage = new AppShell();

            //var navigationPage = new NavigationPage(new LoginPage());
            //MainPage = navigationPage;

//            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping(nameof(BorderLessEntry), (handler, view) =>
//            {
//#if __ANDROID__
//                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
//#elif __IOS__
//                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
//                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
//#endif
//            });
        }
    }
}
