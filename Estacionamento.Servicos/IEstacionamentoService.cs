using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Estacionamento.Servicos
{
    [ServiceContract]
    public interface IEstacionamentoService
    {
        // DESCOMENTE PARA USAR VIA REST
        // ----------------------------------------
        //[WebGet(UriTemplate = "checkin/{placa}", 
        //    BodyStyle= WebMessageBodyStyle.Bare, 
        //    RequestFormat=WebMessageFormat.Json)]
        //-----------------------------------------
        [OperationContract]
        void Checkin(string placa);
        [OperationContract]
        double CheckOut(string placa);
        [OperationContract]
        int VagasRestantes();
    }
}
