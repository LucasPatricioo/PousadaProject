using PousadaAPI.Data.DTO.Usuario;

namespace PousadaAPI.Interfaces;

public interface IUsuarioDAO
{
    public void InserirUsuario(CreateUsuarioDTO usuario);
    public void AtualizarUsuario(UpdateUsuarioDTO usuario);
    public IEnumerable<ReadUsuarioDTO> BuscarUsuarios();
    public ReadUsuarioDTO BuscarUsuarioPorId(int id);
    public ReadUsuarioDTO BuscarUsuarioPorEmail(string email);
    public void DeletarUsuario(int id);
}

