using CryptoWeb.Repository;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace CryptoWeb.Hubs
{
    public class CryptoHub : Hub
    {
        CryptoRepository cryptoRepository;
        public CryptoHub(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            cryptoRepository = new CryptoRepository(connectionString);

        }
        public async Task GetCryptoData()
        {
            var cryptodata = cryptoRepository.GetCryptoValues();
            await Clients.All.SendAsync("ReceivedData", cryptodata);


        }
    }
}
