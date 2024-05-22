using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNet.Controlador;
using XamarinNet.Vista;

namespace XamarinNet
{
    public partial class App : Application
    {
        public static DatabaseConexion DatabaseConexion { get; set; }
        public App()
        {
            InitializeComponent();
            InitializeDatabase();

            //MainPage = new HomePage();
            MainPage = new NavigationPage(new HomePage());
        }

        private void InitializeDatabase()
        {
            var folderApp = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var dbPath = System.IO.Path.Combine(folderApp, "Tareadb.db3");
            DatabaseConexion = new DatabaseConexion(dbPath);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
