using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {

        private readonly ILogger<ClientController> _logger;

        public ClientController(ILogger<ClientController> logger)
        {
            _logger = logger;
        }

        [HttpGet("greet/grpc")]
        public async Task<string> GreetGRPC(string name)
        {
            using var channel = GrpcChannel.ForAddress("http://grpcapi");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = name });
            return reply.Message;
        }

        [HttpGet("greet/rest")]
        public async Task<string> GreetRest(string name)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage();
                request.RequestUri = new Uri($"http://restapi/rest/greet?name={name}");
                var response = await client.SendAsync(request);
                string result = await response.Content.ReadAsStringAsync();
                return result;
            }
        }
    }
}
