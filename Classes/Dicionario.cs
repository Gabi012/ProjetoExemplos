public static class Dicionario
{
    public static void RetornaDiferencaEntreDicionarios(Dictionary<string, double> dicBanco, Dictionary<string, double> lstIntegracao, out Dictionary<string, double> dif, out List<string> lstLojas)
    {
        dif = new Dictionary<string, double>();
        lstLojas = new List<string>();
        foreach (var loja in dicBanco)
        {
            if (lstIntegracao.TryGetValue(loja.Key, out double totalLoja) && totalLoja != loja.Value)
            {
                var diferenca = totalLoja - loja.Value;
                lstLojas.Add(loja.Key);
                dif.Add(loja.Key, diferenca);
            }
        }
    }

    public static void PrintDicionario<TKey, TValue>(Dictionary<TKey, TValue> dicionario) where TKey : notnull
    {
        foreach (var par in dicionario)
        {
            Console.WriteLine($"Chave: {par.Key}, Valor: {par.Value}");
        }
    }


}