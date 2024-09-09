using System.ComponentModel.DataAnnotations;

namespace WebPadaria.Models
{
    public class Produto
    {
        [Key]
        public int Id_Produto { get; set; }
        public string Nome_Produto { get; set; }
        public decimal Valor_Produto { get; set; }
    }
}
