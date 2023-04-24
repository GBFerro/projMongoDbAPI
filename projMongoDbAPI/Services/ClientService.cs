using System.Globalization;
using MongoDB.Driver;
using projMongoDbAPI.Config;
using projMongoDbAPI.Models;

namespace projMongoDbAPI.Services
{
    public class ClientService
    {
        private readonly IMongoCollection<Client> _client;

        // Construtor que configura a coleção de clientes do MongoDB
        public ClientService(IProjMDSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _client = database.GetCollection<Client>(settings.ClientCollectionName);
        }

        // Obtém todos os clientes da coleção de clientes do MongoDB
        public List<Client> Get() => _client.Find(c => true).ToList();

        // Obtém um cliente específico pelo ID da coleção de clientes do MongoDB
        public Client Get(string id) => _client.Find(c => c.Id == id).FirstOrDefault();

        // Cria um novo cliente na coleção de clientes do MongoDB
        public Client Create(Client client)
        {
            _client.InsertOne(client);
            return client;
        }

        // Atualiza um cliente na coleção de clientes do MongoDB usando o objeto do cliente
        public void Update(Client client) => _client.ReplaceOne(c => c.Id == client.Id, client);

        // Atualiza um cliente na coleção de clientes do MongoDB usando o ID do cliente e o objeto do cliente atualizado
        public void Update(string id, Client client) => _client.ReplaceOne(c => c.Id == id, client);

        // Deleta um cliente da coleção de clientes do MongoDB pelo ID do cliente
        public void Delete(string id) => _client.DeleteOne(c => c.Id == id);

        // Deleta um cliente da coleção de clientes do MongoDB usando o objeto do cliente

        public void Delete (Client client) => _client.DeleteOne(c => c.Id == client.Id);
    }
}
