using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Colmeia
    {
        public int ID { get; set; }
        public string Localizacao { get; set; }
        public DateTime DataInstalacao { get; set; }
        public int NumeroAbelhas { get; set; }

        [AllowedValues("Saudável", "Doente", "Monitorada")]
        public string EstadoSaude { get; set; } 
        public string EspecieAbelhas { get; set; }
    }


}
