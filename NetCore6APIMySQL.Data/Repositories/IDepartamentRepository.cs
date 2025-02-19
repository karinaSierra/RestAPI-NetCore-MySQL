using NetCore6APIMySQL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore6APIMySQL.Data.Repositories
{
    public interface IDepartamentRepository 
    {
        Task<IEnumerable<Departamento>> GetAllDep();
        Task<Departamento> GetDetailsDep(int iddepartamento);
        Task<bool> InsertDep(Departamento dep);
        Task<bool> UpdateDep(Departamento dep);
        Task<bool> DeleteDep(Departamento dep);
    }
    
}
