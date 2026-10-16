using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PA2_WcfService
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        Producto ObtenerProductoPorId(int id);

        [OperationContract]
        string InsertarProductoSP(string nombre, string descripcion, decimal precio, int stock, int idCategoria, string urlImagen);

        [OperationContract]
        string ActualizarProductoSP(int id, string nombre, string descripcion, decimal precio, int stock, int idCategoria, string urlImagen);

        [OperationContract]
        string EliminarProductoSP(int id);
    }
}
