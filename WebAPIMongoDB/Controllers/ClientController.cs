using WebAPIMongoDB.Models;
using WebAPIMongoDB.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace WebAPIMongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ClientServices _clientServices;
        private readonly AddressServices _addressServices;

        public ClientController(ClientServices clientServices, AddressServices addressServices)
        {
            _clientServices = clientServices;
            _addressServices = addressServices;
        }

        [HttpGet]
        public ActionResult<List<Client>> Get() => _clientServices.Get();

        [HttpGet("{id:length(24)}", Name = "GetClient")]
        public ActionResult<Client> Get(string id)
        {
            var cliente = _clientServices.Get(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpGet("GetName/{nome}", Name = "GetClientName")]
        public ActionResult<Client> GetName(string nome)
        {
            var cliente = _clientServices.GetName(nome);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpGet("GetAddress/{idAddress:length(24)}", Name = "GetClientAddress")]
        public ActionResult<Client> GetAddress(string idAddress)
        {
            var cliente = _clientServices.GetAddress(idAddress);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        [HttpPost]
        public ActionResult<Client> Create(Client client)
        {
            var address = _addressServices.Create(client.Address);
            client.Address.Id = address.Id;
            _clientServices.Create(client);
            return CreatedAtRoute("GetClient", new { id = client.Id.ToString() }, client);
        }

        [HttpPut]
        public ActionResult<Client> Update(string id, Client clientIn)
        {
            var client = _clientServices.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            clientIn.Id = id;

            _clientServices.Update(id, clientIn);

            return CreatedAtRoute("GetClient", new { id = clientIn.Id.ToString() }, clientIn);
        }

        [HttpDelete]
        public ActionResult Remove(string id)
        {
            var client = _clientServices.Get(id);

            if (client == null)
            {
                return NotFound();
            }

            _clientServices.Remove(client);

            return NoContent();
        }
    }
}