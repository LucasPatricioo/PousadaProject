using PousadaAPI.Data.DTO.Modulo;
using PousadaAPI.Interfaces;

namespace PousadaAPI.Data.DAO;

public class ModuloDAO : IModuloDAO
{
    private readonly string _connectionString;

    public ModuloDAO(string connectionString)
    {
        _connectionString = connectionString;
    }

    public void InserirModulo(CreateModuloDTO modulo)
    {
        throw new System.NotImplementedException();
    }

    public void AtualizarModulo(UpdateModuloDTO modulo)
    {
        throw new System.NotImplementedException();
    }

    public IEnumerable<ReadModuloDTO> BuscarModulos()
    {
        throw new System.NotImplementedException();
    }

    public ReadModuloDTO BuscarModuloPorId(int id)
    {
        throw new System.NotImplementedException();
    }

    public void DeletarModulo(int id)
    {
        throw new System.NotImplementedException();
    }
}
