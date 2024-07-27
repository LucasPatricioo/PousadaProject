using PousadaAPI.Data.DTO.Permissoes;

namespace PousadaAPI.Interfaces
{
    public interface IPermissaoDAO
    {
        public void InserirPermissao(CreatePermissaoDTO permissao);
        public void AtualizarPermissao(UpdatePermissaoDTO permissao);
        public void AssociarPermissaoUsuario(UpdatePermissaoUsuarioDTO permissaoUsuario);
        public IEnumerable<ReadPermissaoDTO> BuscarPermissoes();
        public IEnumerable<ReadPermissaoDTO> BuscarPermissoesPorIdUsuario(int idUsuario);
        public ReadPermissaoDTO BuscarPermissaoPorId(int id);
        public ReadPermissaoDTO BuscarPermissaoPorNome(string nome);
        public void DeletarPermissao(int id);
        public void DesassociarPermissaoUsuario(UpdatePermissaoUsuarioDTO permissaoUsuario);
    }
}
