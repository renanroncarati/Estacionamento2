using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Estacionamento.Negocio;


namespace Estacionamento.Servicos
{
    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerCall)]
    public class EstacionamentoService : IEstacionamentoService
    {
        public void Checkin(string placa)
        {
            Operacoes.Checkin(placa);
        }


        public double CheckOut(string placa)
        {
            return Operacoes.Checkout(placa);            
        }


        public int VagasRestantes()
        {
            return Operacoes.VagasRestantes();
        }
    }
}
