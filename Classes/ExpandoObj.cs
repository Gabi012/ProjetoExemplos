using Newtonsoft.Json.Linq;

public static class Expando{
      public static void ExpandoTest()
    {
        string json = @"
        {
            ""userId"": 1,
            ""id"": 1,
            ""title"": ""sunt aut facere repellat provident occaecati"",
            ""body"": ""quia et suscipit suscipit recusandae...""
        }";

        JObject dynamicObject = JObject.Parse(json);

        Console.WriteLine($"userId: {dynamicObject["userId"]}");
        Console.WriteLine($"id: {dynamicObject["id"]}");
        Console.WriteLine($"title: {dynamicObject["title"]}");
        Console.WriteLine($"body: {dynamicObject["body"]}");


    }
}