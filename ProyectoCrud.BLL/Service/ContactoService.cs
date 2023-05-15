using ProyectoCrud.DAL.DataContext.Repositorio;
using ProyectoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCrud.BLL.Service
{
    public class ContactoService : IContactoService
    {
        IGenericRepository<Contacto> _contactRepor;
        public ContactoService(IGenericRepository<Contacto> contactRepor)
        {
            _contactRepor = contactRepor;
        }
        public async Task<bool> Actualizar(Contacto modelo)
        {
            return await _contactRepor.Actualizar(modelo);
        }

        public async Task<bool> Eliminar(int id)
        {
            return await _contactRepor.Eliminar(id);
        }

        public async Task<bool> Insertar(Contacto modelo)
        {
            return await _contactRepor.Insertar(modelo);
        }

        public async Task<Contacto> Obtener(int id)
        {
            return await _contactRepor.Obtener(id);
        }

        public async Task<Contacto> ObtenerPorNombre(string nombreContacto)
        {
            IQueryable<Contacto> queryContactoSQL = await _contactRepor.ObtenerTodos();
            Contacto contacto = queryContactoSQL.Where(c => c.Nombre == nombreContacto).FirstOrDefault();
            return contacto;
        }

        public async Task<IQueryable<Contacto>> ObtenerTodos()
        {
            return await _contactRepor.ObtenerTodos();
        }
    }
}
