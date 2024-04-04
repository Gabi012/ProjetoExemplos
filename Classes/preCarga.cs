using System.Data;
using System.Data.Common;
using Dapper;

/*
public void CarregaProcVendas()
{
    string sql = "EXEC PROCVENDAS";
    try
    {
        using (IDbConnection cn = DbConnection)
        {
            cn.Open();
            cn.Execute(sql);
            cn.Close();
        }
    }
    catch (SqlException ex)
    {
        // Capturando a exceção específica lançada pela stored procedure
        Console.WriteLine("Erro ao executar a stored procedure: " + ex.Message);
        // Realizar ações apropriadas, como registrar o erro ou notificar o usuário
        // Você também pode optar por relançar a exceção se desejar que ela seja tratada em um nível superior
        // throw;
    }
}*/
