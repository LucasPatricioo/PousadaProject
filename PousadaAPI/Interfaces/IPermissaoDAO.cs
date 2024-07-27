using PousadaAPI.Data.DTO.Permissoes;

namespace PousadaAPI.Interfaces
{
    public interface IPermissaoDAO
    {
        public void InserirPermissao(CreatePermissaoDTO permissao);
        public void AtualizarPermissao(UpdatePermissaoDTO permissao);
        public IEnumerable<ReadPermissaoDTO> BuscarPermissoes();
        public IEnumerable<ReadPermissaoDTO> BuscarPermissoesPorIdUsuario(int idUsuario);
        public ReadPermissaoDTO BuscarPermissaoPorId(int id);
        public ReadPermissaoDTO BuscarPermissaoPorNome(string nome);
        public void DeletarPermissao(int id);
    }
}
