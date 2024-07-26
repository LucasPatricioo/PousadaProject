namespace PousadaAPI.Data.DTO.Modulo
{
    public class UpdateModuloDTO
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public bool? Ativo { get; set; }
    }
}
