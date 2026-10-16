using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace PA2_WcfService
{
    public class Service1 : IService1
    {
        // 1. SELECT por ID
        public Producto ObtenerProductoPorId(int id)
        {
            using (var db = new TiendaDBEntities())
            {
                var producto = db.Productos.FirstOrDefault(p => p.Id == id);
                return producto;
            }
        }

        // 2. INSERT con validaciones y retorno directo
        public string InsertarProductoSP(string nombre, string descripcion, decimal precio, int stock, int idCategoria, string urlImagen)
        {
            using (var db = new TiendaDBEntities())
            {
                if (string.IsNullOrEmpty(nombre)) return "El nombre es obligatorio.";
                if (precio <= 0) return "El precio debe ser mayor a cero.";
                if (stock < 0) return "El stock ingresado no es valido.";
                if (!db.Categorias.Any(c => c.Id == idCategoria)) return "La categoria especificada no existe.";

                db.sp_InsertarProducto(nombre, descripcion, precio, stock, idCategoria, urlImagen);
                return "Producto registrado correctamente.";
            }
        }

        // 3. UPDATE con validaciones y retorno directo
        public string ActualizarProductoSP(int id, string nombre, string descripcion, decimal precio, int stock, int idCategoria, string urlImagen)
        {
            using (var db = new TiendaDBEntities())
            {
                if (!db.Productos.Any(p => p.Id == id)) return "No existe un producto con el ID especificado.";
                if (string.IsNullOrEmpty(nombre)) return "El nombre es obligatorio.";
                if (precio <= 0) return "El precio debe ser mayor a cero.";
                if (stock < 0) return "El stock ingresado no es valido.";
                if (!db.Categorias.Any(c => c.Id == idCategoria)) return "La categoria especificada no existe.";

                db.sp_ActualizarProducto(id, nombre, descripcion, precio, stock, idCategoria, urlImagen);
                return "Producto actualizado correctamente.";
            }
        }

        // 4. DELETE con retorno directo
        public string EliminarProductoSP(int id)
        {
            using (var db = new TiendaDBEntities())
            {
                if (!db.Productos.Any(p => p.Id == id)) return "No se encontro un producto con el ID especificado.";

                db.sp_EliminarProducto(id);
                return "Producto eliminado correctamente.";
            }
        }
    }
}
