namespace Ritmo.Models
{
    public class Exercicio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int Duracao { get; set; } // duração em minutos
        public int Calorias { get; set; } // calorias queimadas
    }
}
