namespace PousadaAPI.Data.DTO.Modulo
{
    public class UpdatePermissaoModuloDTO
    {
        public int IdPermissao { get; set; }
        public int IdModulo { get; set; }
        public bool Leitura { get; set; }
        public bool Escrita { get; set; }
        public bool Edicao { get; set; }
        public bool Exclusao { get; set; }
    }
}
