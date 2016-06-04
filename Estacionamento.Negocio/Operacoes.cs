using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estacionamento.Negocio
{
    /// <summary>
    /// Classe com as operações de um estacionamento.
    /// </summary>
    public sealed class Operacoes
    {
        private const double VALOR_MIN = 5;
        private const int VAGAS_TOTAIS = 15;

        private static IDictionary<string, DateTime> estacionamento = new Dictionary<string, DateTime>();

        /// <summary>
        /// Retorna todos os carros no estacionamento
        /// </summary>
        public static IDictionary<string, DateTime> ObterTodosCarros()
        {
            return estacionamento;
        }

        /// <summary>
        /// Registra a entrada de um carro no estacionamento.
        /// </summary>
        public static void Checkin(string placa)
        {
            if (String.Equals(placa.Trim(), string.Empty))
                throw new Exception(String.Format("Placa inválida.", placa));

            if (estacionamento.Count == VAGAS_TOTAIS)
                throw new Exception("Estacionamento cheio!");

            if (estacionamento.ContainsKey(placa))
                throw new Exception(String.Format("Carro placa '{0}' já existe!", placa));

            estacionamento.Add(placa, DateTime.Now);
        }

        /// <summary>
        /// Registra a saída de um carro do estacionamento.
        /// </summary>
        public static double Checkout(string placa)
        {
            if (String.Equals(placa.Trim(), string.Empty))
                throw new Exception(String.Format("Placa inválida.", placa));

            if (!estacionamento.ContainsKey(placa))
                throw new Exception(String.Format("Carro placa '{0}' NÃO existe!", placa));
            
            var valor = CalculaEstacionamento(estacionamento[placa], DateTime.Now);
            estacionamento.Remove(placa);
            
            return valor;
        }
        public static int VagasRestantes()
        {
            return VAGAS_TOTAIS - estacionamento.Count;
        }
        /// <summary>
        /// Calcula o valor com base no tempo de permanência
        /// </summary>
        private static double CalculaEstacionamento(DateTime entrada, DateTime saida)
        {
            var permanencia = saida.Subtract(entrada);
            return Math.Round((permanencia.TotalMinutes / VALOR_MIN), 2);
        }
    }
}
