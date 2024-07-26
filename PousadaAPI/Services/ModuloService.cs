using PousadaAPI.Data.DTO.Modulo;
using PousadaAPI.Exceptions;
using PousadaAPI.Interfaces;

namespace PousadaAPI.Services
{
    public class ModuloService : IModuloService
    {
        private readonly IModuloDAO _moduloContext;

        public ModuloService(IModuloDAO moduloDAO)
        {
            _moduloContext = moduloDAO;
        }

        public void InserirModulo(CreateModuloDTO modulo)
        {
            try
            {
                if (ValidarModulo(modulo))
                {
                    _moduloContext.InserirModulo(modulo);
                }
            }
            catch (ModuloException mex)
            {
                throw new ModuloException(mex.Message);
            }
            catch (Exception)
            {
                throw new Exception("Erro não mapeado ao inserir módulo");
            }
        }

        public void AtualizarModulo(UpdateModuloDTO modulo)
        {
            try
            {
                ReadModuloDTO moduloExitente = BuscarModuloPorId(modulo.Id);

                modulo = ValidarCamposModuloAtualizacao(modulo, moduloExitente);

                _moduloContext.AtualizarModulo(modulo);
            }
            catch (ModuloException mex)
            {
                throw new ModuloException(mex.Message);
            }
            catch (Exception)
            {
                throw new Exception("Erro não mapeado ao atualizar módulo");
            }
        }

        public IEnumerable<ReadModuloDTO> BuscarModulos()
        {
            try
            {
                var modulos = _moduloContext.BuscarModulos();
                if (modulos is null || modulos.Count() == 0)
                {
                    throw new ModuloNaoEncontradoException();
                }
                return modulos;
            }
            catch (ModuloNaoEncontradoException)
            {
                throw new ModuloNaoEncontradoException();
            }
            catch (ModuloException mex)
            {
                throw new ModuloException(mex.Message);
            }
            catch (Exception)
            {
                throw new Exception("Erro não mapeado ao buscar módulos");
            }
        }

        public ReadModuloDTO BuscarModuloPorId(int id)
        {
            try
            {
                ReadModuloDTO modulo = _moduloContext.BuscarModuloPorId(id);

                if (modulo is null)
                {
                    throw new ModuloNaoEncontradoException();
                }

                return modulo;
            }
            catch (ModuloNaoEncontradoException)
            {
                throw new ModuloNaoEncontradoException();
            }
            catch (ModuloException mex)
            {
                throw new ModuloException(mex.Message);
            }
            catch (Exception)
            {
                throw new Exception("Erro não mapeado ao buscar módulo");
            }
        }

        public void DeletarModulo(int id)
        {
            try
            {
                ReadModuloDTO modulo = BuscarModuloPorId(id);

                _moduloContext.DeletarModulo(modulo.Id);
            }
            catch (ModuloException mex)
            {
                throw new ModuloException(mex.Message);
            }
            catch (Exception)
            {
                throw new Exception("Erro não mapeado ao deletar módulo");
            }
        }

        #region Validações

        private bool ValidarModulo(CreateModuloDTO modulo)
        {
            if (_moduloContext.BuscarModuloPorNome(modulo.Nome) != null)
            {
                throw new ModuloJaExisteException();
            }
            if (string.IsNullOrWhiteSpace(modulo.Nome))
            {
                throw new ModuloNomeInvalidoException();
            }

            if (string.IsNullOrWhiteSpace(modulo.Descricao))
            {
                throw new ModuloDescricaoInvalidaException();
            }

            return true;
        }

        private UpdateModuloDTO ValidarCamposModuloAtualizacao(UpdateModuloDTO moduloAtualizado, ReadModuloDTO moduloRecuperado)
        {
            if (string.IsNullOrEmpty(moduloAtualizado.Nome))
            {
                moduloAtualizado.Nome = moduloRecuperado.Nome;
            }

            if (string.IsNullOrEmpty(moduloAtualizado.Descricao))
            {
                moduloAtualizado.Descricao = moduloRecuperado.Descricao;
            }

            if (moduloAtualizado.Ativo == null)
            {
                moduloAtualizado.Ativo = moduloRecuperado.Ativo;
            }

            return moduloAtualizado;
        }

        #endregion
    }
}
