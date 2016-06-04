using Estacionamento.Console.EstacionamentoServiceReference;
using Estacionamento.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Console
{
    class Program
    {
        #region Métodos Privados
        private static string GeraPlacaFake()
        {
            return Guid.NewGuid().ToString().Substring(0, 8);
        }
        #endregion

        static void Main(string[] args)
        {
            var client = new EstacionamentoServiceClient();

            try
            {
                for (int i = 0; i < 10; i++)
                {
                    // gera uma "placa" pseudoaleatória
                    var placa = GeraPlacaFake();

                    client.Checkin(placa);

                    System.Console.WriteLine("Inserindo placa '{0}'", placa);
                }
                client.Close();
            }
            catch (Exception)
            {
                client.Abort();
                throw;
            }

            System.Console.ReadKey();
        }
    }
}
