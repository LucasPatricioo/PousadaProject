namespace PousadaAPI.Models
{
    public class Modulo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
        public bool Leitura { get; set; }
        public bool Escrita { get; set; }
        public bool Edicao { get; set; }
        public bool Exclusao { get; set; }
    }
}
