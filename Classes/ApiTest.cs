using RestSharp;

public static class ApiTeste
{
    public static void ApiTest()
    {
        string apiUrl = "https://jsonplaceholder.typicode.com/posts/1";

        var client = new RestClient(apiUrl);
        var request = new RestRequest(apiUrl, Method.Get);

        RestResponse response = client.Execute(request);

        if (response.IsSuccessful)
        {
            Console.WriteLine("Dados da API: " + response.Content);
        }
        else
        {
            Console.WriteLine("Erro ao buscar dados da API. Status Code: " + response.StatusCode);
        }
    }

}