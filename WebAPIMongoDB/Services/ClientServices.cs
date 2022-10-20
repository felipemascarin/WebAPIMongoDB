using WebAPIMongoDB.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using WebAPIMongoDB.Utils;

namespace WebAPIMongoDB.Services
{
    public class ClientServices
    {
        private readonly IMongoCollection<Client> _clients;

        public ClientServices(IDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);
            _clients = database.GetCollection<Client>(settings.ClientCollectionName);
        }

        public Client Create(Client cliente)
        {
            _clients.InsertOne(cliente);
            return cliente;
        }

        public List<Client> Get() => _clients.Find(client => true).ToList();

        public Client Get(string id) => _clients.Find<Client>(client => client.Id == id).FirstOrDefault();

        public Client GetName(string nome) => _clients.Find<Client>(client => client.Nome == nome).FirstOrDefault();

        public Client GetAddress(string IdAddress) => _clients.Find<Client>(client => client.Address.Id == IdAddress).FirstOrDefault();

        public void Update(string id, Client clientein)
        {
            _clients.ReplaceOne(cliente => cliente.Id == id, clientein);
        }

        public void Remove(Client clientIn) => _clients.DeleteOne(client => client.Id == clientIn.Id);
    }
}