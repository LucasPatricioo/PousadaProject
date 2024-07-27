using PousadaAPI.Data.DTO.Modulo;

namespace PousadaAPI.Interfaces;

public interface IModuloService
{
    public void InserirModulo(CreateModuloDTO modulo);
    public void AtualizarModulo(UpdateModuloDTO modulo);
    public void AtualizarPermissoesModulo(UpdatePermissaoModuloDTO permissoes);
    public IEnumerable<ReadModuloDTO> BuscarModulos();
    public ReadModuloDTO BuscarModuloPorId(int id);
    public void DeletarModulo(int id);
}
