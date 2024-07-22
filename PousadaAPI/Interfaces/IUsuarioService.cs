using Models;
using PousadaAPI.Data.DTO;

namespace PousadaAPI.Interfaces;

public interface IUsuarioService
{
    public void NovoUsuario(CreateUsuarioDTO usuario);
    public Usuario BuscarUsuarioPorId(int id);
    public Usuario BuscarUsuarioPorEmail(string email);
}
