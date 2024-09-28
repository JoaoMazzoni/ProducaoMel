using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Flores
    {
        public int ID { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; } 
        public string PeriodoFloracao { get; set; }
        public string Origem { get; set; }
        public bool AtracaoAbelhas { get; set; }
    }




}
