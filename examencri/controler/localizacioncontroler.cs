using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace examencri.controler
{
    public class localizacioncontroler
    {
        readonly SQLiteAsyncConnection _connection;
        //contructor de la clase
        public localizacioncontroler(string DBPath)
        {

            _connection = new SQLiteAsyncConnection(DBPath);
            _connection.CreateTableAsync<Models.localizacion>();
        }

        // public Task<int> SaveEmple(model.Empleado empleado)
        public Task<int> SaveGeo(Models.localizacion posicion)
        {
            if (posicion.id != 0)
                return _connection.UpdateAsync(posicion);
            else
                return _connection.InsertAsync(posicion);
        }
        public Task<Models.localizacion> Getlocalizaciones(int pid)
        {
            return _connection.Table<Models.localizacion>()
                .Where(i => i.id == pid)
                .FirstOrDefaultAsync();
        }

        public Task<List<Models.localizacion>> GetLisLocalizaciones()
        {
            return _connection.Table<Models.localizacion>().ToListAsync();
        }
        public Task<int> Deletelocalizacion(Models.localizacion posicion)
        {
            return _connection.DeleteAsync(posicion);
        }
    }
}
