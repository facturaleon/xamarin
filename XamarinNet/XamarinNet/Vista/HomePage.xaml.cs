using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinNet.Modelo;

namespace XamarinNet.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            //Carga inicial y carga de elementos
            base.OnAppearing();
            loadItems();
        }

        private async void loadItems()
        {
            var items = await App.DatabaseConexion.getItem();
            lista_tareas.ItemsSource = items;
        }

        private async void ToolbarItem_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PageContenido(null));
        }

        private async void BtnDelete_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Confirmación","Está seguro de eliminar el elemento?","Aceptar","cancelar"))
            {
                var item = (Tarea)(sender as MenuItem).CommandParameter;
                var result = await App.DatabaseConexion.DeleteItem(item);
                if(result ==1)
                {
                    loadItems();
                }
            }
        }

        private async void lista_tareas_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item == null) return;

            var selectedTask = e.Item as Tarea;
            if (selectedTask != null)
            {
                // Navegar a la página de contenido con el elemento seleccionado
                await Navigation.PushAsync(new PageContenido(selectedTask));
            }

            // Deselecciona el item
            ((ListView)sender).SelectedItem = null;

        }
    }
}