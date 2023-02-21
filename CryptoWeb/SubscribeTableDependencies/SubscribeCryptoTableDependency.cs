using CryptoWeb.Hubs;
using CryptoWeb.Models;
using System;
using TableDependency.SqlClient;

namespace CryptoWeb.SubscribeTableDependencies
{
    public class SubscribeCryptoTableDependency : ISubscribeTableDependency
    {
        SqlTableDependency<Crypto> tableDependency;
        CryptoHub _cryptodHub;

        public SubscribeCryptoTableDependency(CryptoHub cryptodHub)
        {
            this._cryptodHub = cryptodHub;
        }

        public void SubscribeTableDependency(string connectionString)
        {
            tableDependency = new SqlTableDependency<Crypto>(connectionString);
            tableDependency.OnChanged += TableDependency_OnChanged;
            tableDependency.OnError += TableDependency_OnError;
            tableDependency.Start();
        }

        private void TableDependency_OnChanged(object sender, TableDependency.SqlClient.Base.EventArgs.RecordChangedEventArgs<Crypto> e)
        {
            if (e.ChangeType != TableDependency.SqlClient.Base.Enums.ChangeType.None)
            {
                _cryptodHub.GetCryptoData();
            }
        }

        private void TableDependency_OnError(object sender, TableDependency.SqlClient.Base.EventArgs.ErrorEventArgs e)
        {
            Console.WriteLine($"{nameof(Crypto)} SqlTableDependency error: {e.Error.Message}");
        }
    }
}
