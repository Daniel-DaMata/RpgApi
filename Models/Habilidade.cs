using System.Collections.Generic;

namespace RpgApi.Models
{
    public class Habilidade
    {
        public List<PersonagemHabilidade> PersonagemHabilidades { get; set; }
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Dano { get; set; }
    }
}