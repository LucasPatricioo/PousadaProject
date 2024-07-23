namespace PousadaAPI.Data.DTO.Usuario;

public class UpdateUsuarioDTO
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? Email { get; set; }
    public string? Senha { get; set; }
    public bool? Ativo { get; set; }
}
