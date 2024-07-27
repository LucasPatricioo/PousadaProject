using PousadaAPI.Data.DTO.Permissoes;
using PousadaAPI.Exceptions;
using PousadaAPI.Interfaces;

namespace PousadaAPI.Services
{
    public class PermissaoService : IPermissaoService
    {
        private readonly IPermissaoDAO _permissaoContext;

        public PermissaoService(IPermissaoDAO permissaoDAO)
        {
            _permissaoContext = permissaoDAO;
        }

        public void InserirPermissao(CreatePermissaoDTO permissao)
        {
            try
            {
                if (ValidarPermissao(permissao))
                {
                    _permissaoContext.InserirPermissao(permissao);
                }
            }
            catch (PermissaoException pex)
            {
                throw new PermissaoException(pex.Message);
            }
            catch (Exception)
            {
                throw new Exception("Erro não mapeado ao inserir permissão");
            }
        }

        public void AtualizarPermissao(UpdatePermissaoDTO permissao)
        {
            try
            {
                ReadPermissaoDTO permissaoExistente = BuscarPermissaoPorId(permissao.Id);

                permissao = ValidarCamposPermissaoAtualizacao(permissao, permissaoExistente);

                _permissaoContext.AtualizarPermissao(permissao);
            }
            catch (PermissaoException pex)
            {
                throw new PermissaoException(pex.Message);
            }
            catch (Exception)
            {
                throw new Exception("Erro não mapeado ao atualizar permissão");
            }
        }

        public IEnumerable<ReadPermissaoDTO> BuscarPermissoes()
        {
            try
            {
                var permissoes = _permissaoContext.BuscarPermissoes();
                if (permissoes is null || permissoes.Count() == 0)
                {
                    throw new PermissaoNaoEncontradaException();
                }
                return permissoes;
            }
            catch (PermissaoNaoEncontradaException)
            {
                throw new PermissaoNaoEncontradaException();
            }
            catch (PermissaoException pex)
            {
                throw new PermissaoException(pex.Message);
            }
            catch (Exception)
            {
                throw new Exception("Erro não mapeado ao buscar permissões");
            }
        }

        public IEnumerable<ReadPermissaoDTO> BuscarPermissoesPorIdUsuario(int idUsuario)
        {
            try
            {
                var permissoes = _permissaoContext.BuscarPermissoesPorIdUsuario(idUsuario);
                if (permissoes is null || permissoes.Count() == 0)
                {
                    throw new PermissaoNaoEncontradaException();
                }
                return permissoes;
            }
            catch (PermissaoNaoEncontradaException)
            {
                throw new PermissaoNaoEncontradaException();
            }
            catch (PermissaoException pex)
            {
                throw new PermissaoException(pex.Message);
            }
            catch (Exception)
            {
                throw new Exception("Erro não mapeado ao buscar permissões por id de usuário");
            }
        }

        public ReadPermissaoDTO BuscarPermissaoPorId(int id)
        {
            try
            {
                ReadPermissaoDTO permissao = _permissaoContext.BuscarPermissaoPorId(id);

                if (permissao is null)
                {

                    throw new PermissaoNaoEncontradaException();
                }

                return permissao;
            }
            catch (PermissaoNaoEncontradaException)
            {
                throw new PermissaoNaoEncontradaException();
            }
            catch (PermissaoException pex)
            {
                throw new PermissaoException(pex.Message);
            }
            catch (Exception)
            {
                throw new Exception("Erro não mapeado ao buscar permissão por id");
            }
        }

        public void DeletarPermissao(int id)
        {
            try
            {
                ReadPermissaoDTO permissao = BuscarPermissaoPorId(id);

                _permissaoContext.DeletarPermissao(id);
            }
            catch (PermissaoException pex)
            {
                throw new PermissaoException(pex.Message);
            }
            catch (Exception)
            {
                throw new Exception("Erro não mapeado ao deletar permissão");
            }
        }

        #region Validações

        private bool ValidarPermissao(CreatePermissaoDTO permissao)
        {
            if (_permissaoContext.BuscarPermissaoPorNome(permissao.Nome) != null)
            {
                throw new PermissaoJaExisteException();
            }
            if (string.IsNullOrWhiteSpace(permissao.Nome))
            {
                throw new PermissaoNomeInvalidoException();
            }

            if (string.IsNullOrWhiteSpace(permissao.Descricao))
            {
                throw new PermissaoDescricaoInvalidaException();
            }

            return true;
        }

        private UpdatePermissaoDTO ValidarCamposPermissaoAtualizacao(UpdatePermissaoDTO permissaoAtualizacao, ReadPermissaoDTO permissaoRecuperado)
        {
            if (string.IsNullOrEmpty(permissaoAtualizacao.Nome))
            {
                permissaoAtualizacao.Nome = permissaoRecuperado.Nome;
            }

            if (string.IsNullOrEmpty(permissaoAtualizacao.Descricao))
            {
                permissaoAtualizacao.Descricao = permissaoRecuperado.Descricao;
            }

            if (permissaoAtualizacao.Ativo == null)
            {
                permissaoAtualizacao.Ativo = permissaoRecuperado.Ativo;
            }

            return permissaoAtualizacao;
        }

        #endregion

    }
}
