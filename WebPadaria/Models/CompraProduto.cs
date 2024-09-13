namespace WebPadaria.Models
{
	public class CompraProduto
	{
		public int CompraId { get; set; }
		public Compra Compra { get; set; }

		public int ProdutoId { get; set; }
		public Produto Produto { get; set; }

		public int Quantidade { get; set; }
	}
}
