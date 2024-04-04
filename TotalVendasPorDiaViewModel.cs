public class TotalVendasPorDiaViewModel
{
    public string? undNome { get; set; }
    public DateTime DataVenda { get; set; }
    public decimal BrutoVenda { get; set; }

    // Construtor padrão para garantir que todas as propriedades sejam inicializadas
    public TotalVendasPorDiaViewModel()
    {
        undNome = null; // Você pode inicializar com null ou um valor padrão conforme necessário
        DataVenda = DateTime.MinValue; // Inicialize a data com um valor padrão
        BrutoVenda = 0; // Inicialize o valor com um valor padrão
    }
}
