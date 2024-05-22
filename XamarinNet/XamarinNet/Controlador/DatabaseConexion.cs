using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XamarinNet.Modelo;

namespace XamarinNet.Controlador
{
    public class DatabaseConexion
    {
        public SQLiteAsyncConnection Conection { get; set; }
        public DatabaseConexion(string path)
        {
            Conection = new SQLiteAsyncConnection(path);
            //Creamos una tabla Tarea
            Conection.CreateTableAsync<Tarea>().Wait();
        }
        public async Task<int> InsertItem(Tarea item)
        {
            return await Conection.InsertAsync(item);
        }
        public async Task<List<Tarea>> getItem()
        {
            return await Conection.Table<Tarea>().ToListAsync();
        }
        public async Task<int> DeleteItem( Tarea item)
        {
            return await Conection.DeleteAsync(item);
        }
        public async Task<int> UpdateItem(Tarea item)
        {
            return await Conection.UpdateAsync(item);
        }
    }
}
