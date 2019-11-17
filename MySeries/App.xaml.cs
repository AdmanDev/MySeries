using System;
using System.Windows;
using MyFunctions;

namespace MySeries
{
    public partial class App : Application
    {
        public static string Language { get; private set; }
        public static ResourceDictionary LanguageResources { get; private set; }

        private void OnApplicationStart(object sender, StartupEventArgs e)
        {
            System.Windows.Forms.Application.EnableVisualStyles();

            SetAppLanguage(MySeries.Properties.Settings.Default.Language);

            Functions.CheckUpdate("https://admansoftware.wordpress.com/2017/04/14/myseries/");
        }

        public static void SetAppLanguage(string lang)
        {
            Language = lang;
            TranslateWords.language = lang;
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(lang);

            LanguageResources = new ResourceDictionary();
            string resDir = "pack://application:,,,/Resources/Translate/" + lang +"/string_" + lang + ".xaml";
            LanguageResources.Source = new Uri(resDir);

            MyFunctions.TranslateWords.language = lang;
        }

    }
}
