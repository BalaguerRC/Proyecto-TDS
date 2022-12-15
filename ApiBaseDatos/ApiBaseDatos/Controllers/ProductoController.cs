using ApiBaseDatos.Data;
using ApiBaseDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiBaseDatos.Controllers
{
    public class ProductoController : ApiController
    {
        // GET api/<controller>
        public List<Producto> Get()
        {
            return ProductoData.Listar();
        }

        // GET api/<controller>/5
        public Producto Get(int Id)
        {
            return ProductoData.Obtener(Id);
        }

        // POST api/<controller>
        public bool Post([FromBody]Producto producto)
        {
            return ProductoData.Registrar(producto);
        }

    }
}