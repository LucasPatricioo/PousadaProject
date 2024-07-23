using Models;
using PousadaAPI.Data.DTO.Usuario;

namespace PousadaAPI.Interfaces;

public interface IUsuarioService
{
    public void InserirUsuario(CreateUsuarioDTO usuario);
    public void AtualizarUsuario(UpdateUsuarioDTO usuario);
    public ReadUsuarioDTO BuscarUsuarioPorId(int id);
    public ReadUsuarioDTO BuscarUsuarioPorEmail(string email);
    public void DeletarUsuario(int id);
}
