using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreatPizzaServer;
using GreatPizzaServer.Controllers;
using DTO;

namespace GreatPizzaServer.Tests.Controllers
{
  [TestClass]
  public class GreatPizzaControllerTest
  {
    [TestMethod]
    public void getPizzas()
    {

      // Arrange
      GreatPIzzaController controller = new GreatPIzzaController();

      // Act
      IEnumerable<Pizza> result = controller.getPizzas();

      // Assert
      Assert.IsNotNull(result);
      Assert.AreEqual(4, result.Count());
    }

    [TestMethod]
    public void GetIngredientsByPizzaId()
    {
      // Arrange
      GreatPIzzaController controller = new GreatPIzzaController();

      // Act
      string result = controller.GetIngredientsByPizzaId(1);

      // Assert
      Assert.AreEqual("1,2", result);
    }
  }
}
