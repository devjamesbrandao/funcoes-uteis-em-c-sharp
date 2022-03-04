using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class Program
{
    private static readonly HttpClient _client = new HttpClient();
    
    public async static Task Main(string[] args)
    {
        await PostAsyncGenerico();
    }

    public static async Task<bool> PostAsyncGenerico()
    {
        try
        {
            // Cabeçalho
            _client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json");

            var dominio = "http://dominio.com.br/api/cadastrar";

            var autenticacao = $"usuario:senha";

            var base64Autenticacao = Convert.ToBase64String(
                System.Text.ASCIIEncoding.UTF8.GetBytes(autenticacao)
            );

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                "Basic", base64Autenticacao
            );


            // Body
            var parametros = JsonConvert.SerializeObject("objeto para serializar");

            var buffer = System.Text.Encoding.UTF8.GetBytes(parametros);

            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");


            // Requisição e resposta
            var Resposta = await _client.PostAsync(dominio, byteContent);

            Resposta.EnsureSuccessStatusCode();

            var JSONResposta = await Resposta.Content.ReadAsStringAsync();

            return await Task.FromResult(true);
        }
        catch(Exception)
        {
            return await Task.FromResult(false);
        }
    }
}
