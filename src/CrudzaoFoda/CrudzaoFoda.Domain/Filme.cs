namespace CrudzaoFoda.Domain
{
    public class Filme
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Genero { get; set; } = string.Empty;
        public DateTime DataDeLancamento { get; set; }
    }
}
