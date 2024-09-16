using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebPadaria.Models
{
    public class Compra
    {
        [Key]
        public int Id_Compra { get; set; }
        public int Cliente_Id { get; set; }
        public int Produto_Id { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor_Total { get; set; }

        [ForeignKey("Cliente_Id")]
        public Cliente Cliente { get; set; }

        [ForeignKey("Produto_Id")]
        public Produto Produto { get; set; }
    }
}
