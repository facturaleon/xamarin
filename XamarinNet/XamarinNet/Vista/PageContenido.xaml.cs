using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XamarinNet.Modelo;
using XamarinNet.Controlador;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static SQLite.SQLite3;

namespace XamarinNet.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PageContenido : ContentPage
    {
        private Tarea _tarea;
        public PageContenido(Tarea tarea)
        {
            InitializeComponent();
            _tarea = tarea;

            if (_tarea != null)
            {
                // Inicializa los campos con los datos de la tarea para editar
                nombre.Text = _tarea.Nombre;
                descripcion.Text = _tarea.Descripcion;
            }
        }

        private async void btn_guardar_Clicked(object sender, EventArgs e) 
        { 
            try
            {
                if (_tarea == null)
                {
                    var item = new Tarea
                    {
                        Nombre = nombre.Text,
                        Descripcion = descripcion.Text,
                    };
                    var result = await App.DatabaseConexion.InsertItem(item);
                    if (result == 1)
                    {
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo guardar", "Aceptar");
                    }
                }
                else
                {
                    // Actualizar la tarea existente
                    _tarea.Nombre = nombre.Text;
                    _tarea.Descripcion = descripcion.Text;

                    var resultUpdate = await App.DatabaseConexion.UpdateItem(_tarea);
                    if (resultUpdate == 1)
                    {
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert("Error", "No se pudo Actualizar", "Aceptar");
                    }
                }
                
                
        
            }catch(Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Aceptar");
            }

        }
    }
}