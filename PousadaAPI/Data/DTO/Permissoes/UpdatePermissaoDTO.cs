namespace PousadaAPI.Data.DTO.Permissoes
{
    public class UpdatePermissaoDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public bool? Ativo { get; set; }
    }
}
