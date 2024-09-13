using System.ComponentModel.DataAnnotations;

namespace WebPadaria.Models
{
    public class Compra
    {
        [Key]
        public int Id_Compra { get; set; }
        public decimal Valor_Total { get; set; }
    }
}
