using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Mel
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Cor { get; set; }
        public string Consistencia { get; set; } 
        public string Sabor { get; set; }
        public string Aroma { get; set; }
        public string Composicao { get; set; }
        public int? FlorID { get; set; } 
    }



}
