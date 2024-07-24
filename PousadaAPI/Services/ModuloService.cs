using PousadaAPI.Data.DTO.Modulo;
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
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

        #region Validações

        private bool ValidarModulo(CreateModuloDTO modulo)
        {
            if (string.IsNullOrWhiteSpace(modulo.Nome))
            {
                throw new Exception("Nome do módulo não pode ser vazio");
            }

            if (string.IsNullOrWhiteSpace(modulo.Descricao))
            {
                throw new Exception("Descrição do módulo não pode ser vazia");
            }

            return true;
        }

        #endregion
    }
}
