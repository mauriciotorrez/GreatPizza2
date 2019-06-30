using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace GreatPizzaServer.Controllers
{
  [RoutePrefix("api/GreatPizza")]
  public class GreatPIzzaController : ApiController
    {

        PizzaHelper helper;

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("GetPizzas")]
    public IEnumerable<Pizza> getPizzas()
        {
          helper = new PizzaHelper();
          return helper.GetAllPizzas();
        }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("GetIngredients")]
    public IEnumerable<Ingredient> getIngredients()
        {
          helper = new PizzaHelper();
          return helper.getAllIngredients();
        }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("GetIngredientsByPizzaId/{id}")]
    public string GetIngredientsByPizzaId(int id)
    {
      helper = new PizzaHelper();
      return helper.GetIngredientsByPizzaId(id);
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("AddPizza")]
    public IHttpActionResult AddPizza(Pizza pizza)
    {
      helper = new PizzaHelper();
      helper.AddPizza(pizza);
      return Ok();
    }

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("EditPizza")]
    public IHttpActionResult EditPizza(Pizza pizza)
    {
      helper = new PizzaHelper();
      helper.UpdatePizza(pizza);
      return Ok();
    }

    // GET: api/GreatPIzza/5
    public string Get(int id)
        {
            return "value";
        }

        // POST: api/GreatPIzza
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GreatPIzza/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GreatPIzza/5
        public void Delete(int id)
        {
        }
    }
}
