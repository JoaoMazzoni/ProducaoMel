using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Producao
    {
        public int Lote { get; set; }
        public DateTime DataColheita { get; set; }
        public int? ColmeiaID { get; set; } 
        public int? MelID { get; set; } 
        public double QuantidadeColhida { get; set; }

        [AllowedValues("Excelente", "Boa", "Regular", "Ruim")]
        public string QualidadeFinal { get; set; } 
    }


}
