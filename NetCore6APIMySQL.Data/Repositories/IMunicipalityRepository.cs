using NetCore6APIMySQL.Model;

namespace NetCore6APIMySQL.Data.Repositories
{
    public interface IMunicipalityRepository 
    {
        Task<IEnumerable<Municipio>> GetAllMun();
        Task<Municipio> GetDetailsMun(int idmunicipio);
        Task<bool> InsertMun(Municipio mun);
        Task<bool> UpdateMun(Municipio mun);
        Task<bool> DeleteMun(Municipio mun);
    }
}
