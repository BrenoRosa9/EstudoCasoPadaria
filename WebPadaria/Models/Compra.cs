using System.ComponentModel.DataAnnotations;

namespace WebPadaria.Models
{
    public class Compra
    {
        [Key]
        public int Id_Compra { get; set; }
        public int Cliente_Id { get; set; }
        public int Produto_Id { get; set; }
        public decimal Valor_Total { get; set; }
    }
}
