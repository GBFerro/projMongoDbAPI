using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using projMongoDbAPI.Models;
using projMongoDbAPI.Services;

namespace projMongoDbAPI.Controllers
{
    // Define o prefixo para o roteamento de requisições, que será "api/Client"
    [Route("api/[controller]")]
    // Define que esta classe é um controlador de API
    [ApiController]
    public class ClientController : ControllerBase
    {
        // Declara uma instância da classe ClientService, que será responsável por realizar
        // as operações no banco de dados MongoDB relacionadas ao modelo "Client".
        private readonly ClientService _clientService;

        // Define o construtor da classe ClientController, que recebe uma instância da classe
        // ClientService como parâmetro e a injeta no objeto _clientService.
        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        // Define o endpoint HTTP GET para obter todos os objetos "Client" do banco de dados.
        // Retorna uma lista de objetos Client encapsulada em um objeto ActionResult.
        [HttpGet]
        public ActionResult<List<Client>> Get() => _clientService.Get();

        // Define o endpoint HTTP GET para obter um objeto "Client" específico do banco de dados, definido pelo parâmetro id.
        // Retorna um objeto Client encapsulado em um objeto ActionResult. Se o objeto não for encontrado, retorna NotFound().
        [HttpGet("{id:length(24)}", Name = "GetClient")]
        public ActionResult<Client> Get(string id)
        {
            var client = _clientService.Get(id);
            if (client == null) return NotFound();

            return client;
        }

        // Define o endpoint HTTP POST para criar um novo objeto "Client" no banco de dados.
        // Recebe um objeto Client como parâmetro e retorna o mesmo objeto encapsulado em um objeto ActionResult.
        [HttpPost]
        public ActionResult<Client> Create(Client client) => _clientService.Create(client);

        // Define o endpoint HTTP PUT para atualizar um objeto "Client" específico no banco de dados, definido pelo parâmetro id.
        // Recebe um objeto Client como parâmetro e retorna Ok() se a atualização for bem-sucedida.
        // Se o objeto não for encontrado, retorna NotFound().
        [HttpPut("{id:length(24)}", Name = "PutClient")]
        public ActionResult Update(string id, Client client)
        {
            var c = _clientService.Get(id);
            if (c == null) return NotFound();

            _clientService.Update(id, client);

            return Ok();
        }

        // Define o endpoint HTTP DELETE para remover um objeto "Client" específico do banco de dados, definido pelo parâmetro id.
        // Retorna Ok() se a remoção for bem-sucedida. Se o objeto não for encontrado, retorna NotFound().
        [HttpDelete("{id:length(24)}", Name = "DeleteClient")]
        public ActionResult Delete(string id)
        {
            if (id == null) return NotFound();

            var client = _clientService.Get(id);
            if (client == null) return NotFound();

            _clientService.Delete(id);

            return Ok();
        }
    }
}
