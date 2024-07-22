using PousadaAPI.Data.DTO;

namespace PousadaAPI.Interfaces;

public interface IUsuarioDAO
{
    public void InserirUsuario(CreateUsuarioDTO usuario);
}

