public static class Conversor
{
    public static string ConverteStringEmListaSql(List<string> listalojas)
    {
        int indice = 0;  // Substitua isso pelo índice que você quer verificar

        // Usando um loop foreach para percorrer a lista
        int ultimoIndice = listalojas.Count - 1;
        string sql = "";
        foreach (var l in listalojas)
        {
            if (listalojas.Count == 1)
            {
                sql += "('" + l + "'" + ")";
            }
            else
            if (indice == 0)
            {
                sql += "('" + l + "'" + ",";
            }
            else if (indice < ultimoIndice)
            {
                sql += "'" + l + "'" + ",";
            }
            else
            {
                sql += "'" + l + "'" + ")";
            }
            indice++;
        }
        return sql;
    }
}
