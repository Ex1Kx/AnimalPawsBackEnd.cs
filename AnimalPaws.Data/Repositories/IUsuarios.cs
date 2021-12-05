using AnimalPaws.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimalPaws.Data.Repositories
{
    public interface IUsuarios
    {
        Task<IEnumerable<Usuarios>> GetUsuarios();
        Task<bool> insertUsuarios(Usuarios usuarios);  
    }
}
