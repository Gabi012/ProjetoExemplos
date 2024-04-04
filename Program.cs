using System;
using System.Dynamic;
using System.Net.Http.Json;
using RestSharp;
using Newtonsoft.Json.Linq;
using System.Security.Cryptography;
using NCalc;
class Program
{
    static void Main()
    {
        //ApiTeste.ApiTest();
        //Expando.ExpandoTest();
        /*
        Dictionary<string, double> dicBanco = new Dictionary<string, double>{
            {"Loja 1", 1000.50},
            {"Loja 2", 2500.10},
            {"Loja 3", 3000.55}
       };

        Dictionary<string, double> lstIntegracao = new Dictionary<string, double>{
            {"Loja 1", 1000.50},
            {"Loja 2", 500.10},
            {"Loja 3", 3000.55},
            {"Loja 4", 500.00}
       };
        
        Dictionary<string, double> dicDiferenca;
        List<string> lstLojas;

        Dicionario.RetornaDiferencaEntreDicionarios(dicBanco, lstIntegracao, out dicDiferenca, out lstLojas);
        Dicionario.PrintDicionario(dicDiferenca);


        string sql = Conversor.ConverteStringEmListaSql(lstLojas);
        Console.WriteLine(sql);

        string sqlteste = "select * from view where lojas in ";
        Console.WriteLine(sqlteste + sql);
        
        CompararListas();
        */

        var obj = new { QTD_PRODUTO = 2 };

        // Defina a expressão a ser avaliada
        string exp = "(3 * QTD_PRODUTO) * 0.6"; // 60% = 0.6

        // Crie um objeto Expression para a expressão
        Expression e = new Expression(exp);

        // Adicione variáveis ​​à expressão
        e.Parameters["QTD_PRODUTO"] = obj.QTD_PRODUTO;

        NcalcExp(e);
    }

    public static void NcalcExp(Expression e)
    {
        try
        {
            // Avalie a expressão
            object result = e.Evaluate();
            Console.WriteLine($"Resultado da expressão: {result}");
        }
        catch (EvaluationException ex)
        {
            Console.WriteLine($"Erro na avaliação da expressão: {ex.Message}");
        }
    }

    public static void CompararListas()
    {
        List<TotalVendasPorDiaViewModel> lstbanco = new List<TotalVendasPorDiaViewModel>{
            new TotalVendasPorDiaViewModel {undNome="loja 1", DataVenda = new DateTime(2024,01,01), BrutoVenda = 1000},
            new TotalVendasPorDiaViewModel {undNome="loja 1", DataVenda = new DateTime(2024,01,02), BrutoVenda = 2000},
            new TotalVendasPorDiaViewModel {undNome="loja 2", DataVenda = new DateTime(2024,01,01), BrutoVenda = 3000},
            new TotalVendasPorDiaViewModel {undNome="loja 2", DataVenda = new DateTime(2024,01,02), BrutoVenda = 3000}
        };

        List<TotalVendasPorDiaViewModel> lstcliente = new List<TotalVendasPorDiaViewModel>{
            new TotalVendasPorDiaViewModel {undNome="loja 1", DataVenda = new DateTime(2024,01,01), BrutoVenda = 5000},
            new TotalVendasPorDiaViewModel {undNome="loja 1", DataVenda = new DateTime(2024,01,02), BrutoVenda = 3000},
            new TotalVendasPorDiaViewModel {undNome="loja 2", DataVenda = new DateTime(2024,01,01), BrutoVenda = 3000},
            new TotalVendasPorDiaViewModel {undNome="loja 2", DataVenda = new DateTime(2024,01,02), BrutoVenda = 4000}
        };


        Dictionary<string, List<DateTime>> diferenca = new Dictionary<string, List<DateTime>>();


        foreach (var item in lstbanco)
        {
            if (string.IsNullOrEmpty(item.undNome))
            {
                // Se undNome for nulo ou vazio, você pode lidar com isso aqui, como ignorar o item ou lançar uma exceção
                continue; // Ignora o item e passa para o próximo
            }
            var clienteItem = lstcliente.FirstOrDefault(x => x.undNome == item.undNome && x.DataVenda == item.DataVenda);
            if (clienteItem != null && clienteItem.BrutoVenda != item.BrutoVenda)
            {

                if (!diferenca.ContainsKey(item.undNome))
                {
                    diferenca[item.undNome] = new List<DateTime>();
                }
                diferenca[item.undNome].Add(item.DataVenda);
            }
        }

        if (diferenca.Count > 0)
        {
            foreach (var kvp in diferenca)
            {
                Console.WriteLine(kvp.Key);
                foreach (var date in kvp.Value)
                {
                    Console.WriteLine(date);
                }
                Console.WriteLine("\n");
            }
        }
        else
        {
            Console.WriteLine("Não foram encontradas diferenças nas vendas.");
        }
        // Converter o dicionário em uma sequência de pares chave-valor
        var sequencia = diferenca.SelectMany(kvp => kvp.Value.Select(date => new KeyValuePair<DateTime, string>(date, kvp.Key)));

        // Agrupar a sequência por dia
        var agrupamentoPorDia = sequencia.GroupBy(kvp => kvp.Key, kvp => kvp.Value);

        // Imprimir os resultados
        foreach (var grupo in agrupamentoPorDia)
        {
            Console.WriteLine($"Dia: {grupo.Key}");
            Console.WriteLine($"Lojas: {string.Join(", ", grupo)}");
            Console.WriteLine();
        }
    }

}