using Microsoft.AspNetCore.Mvc;
using GrpcServicioRegistro;
using Grpc.Net.Client;


namespace GrpcAppCliente.Controllers
{
    public class PruebaController : Controller
    {
        
        private Greeter.GreeterClient greeterClient;

        public async Task<IActionResult> Index() { 
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Index(string nombre = "",
            string apellidos="") {
            
            var canal = GrpcChannel.ForAddress("https://localhost:7091/");
            greeterClient = new Greeter.GreeterClient(canal);

            var helloRequest = new HelloRequest();
            helloRequest.Nombre = nombre;   
            helloRequest.Apellidos = apellidos; 

            var mensaje = await greeterClient.SayHelloAsync(helloRequest);
            ViewBag.mensaje = mensaje.Message;
            return View();

        }

    }
}
