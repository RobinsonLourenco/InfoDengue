namespace InfoDengue.Domain.Models
{
    public class Solicitante
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string CPF { get; set; }
        public List<Relatorio> Relatorios { get; set; }
    }
}
