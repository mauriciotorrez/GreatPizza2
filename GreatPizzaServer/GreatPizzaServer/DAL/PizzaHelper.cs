using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
  public class PizzaHelper
  {
    string connectionString = string.Empty;

    public PizzaHelper()
    {
      connectionString = ConfigurationManager.ConnectionStrings["greatPizzaConn"].ConnectionString;
    }


    public void AddPizza(Pizza pizza)
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand sp_com = new SqlCommand("SP_addPizza", connection);
        sp_com.CommandType = System.Data.CommandType.StoredProcedure;
        sp_com.Parameters.AddWithValue("@name", pizza.name_pizza);
        sp_com.Parameters.AddWithValue("@idIngredient", pizza.idIngredient);
        connection.Open();
        sp_com.ExecuteNonQuery();
        connection.Close();
      }
    }

    public void UpdatePizza(Pizza pizza)
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand sp_com = new SqlCommand("SP_editPizza", connection);
        sp_com.CommandType = System.Data.CommandType.StoredProcedure;
        sp_com.Parameters.AddWithValue("@idPizza", pizza.idIngredient);
        sp_com.Parameters.AddWithValue("@name", pizza.name_pizza);
        sp_com.Parameters.AddWithValue("@idIngredient", pizza.idIngredient);
        connection.Open();
        sp_com.ExecuteNonQuery();
        connection.Close();
      }
    }


    public IEnumerable<Pizza> GetAllPizzas()
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand sp_com = new SqlCommand("SP_getPizzas", connection);
        sp_com.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(sp_com);
        DataSet ds = new DataSet();
        da.Fill(ds);

        var empList = ds.Tables[0].AsEnumerable().Select(dataRow => new Pizza { id_pizza = dataRow.Field<int>("id_pizza"), name_pizza = dataRow.Field<string>("pizza_name") }).ToList();

        return empList;
      }
    }


    public IEnumerable<Ingredient> getAllIngredients()
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand sp_com = new SqlCommand("SP_getIngredients", connection);
        sp_com.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(sp_com);
        DataSet ds = new DataSet();
        da.Fill(ds);
        var empList = ds.Tables[0].AsEnumerable().Select(dataRow => new Ingredient { id_ingredient = dataRow.Field<int>("id_ingredient"), name_ingredient = dataRow.Field<string>("ingredient_name") }).ToList();

        return empList;
      }
    }

    public string GetIngredientsByPizzaId(int idPizza)
    {
      using (SqlConnection connection = new SqlConnection(connectionString))
      {
        SqlCommand sp_com = new SqlCommand("SP_getIngredientsByPizzaId", connection);
        sp_com.Parameters.AddWithValue("@idPizza", idPizza);
        sp_com.CommandType = System.Data.CommandType.StoredProcedure;
        SqlDataAdapter da = new SqlDataAdapter(sp_com);
        DataSet ds = new DataSet();
        da.Fill(ds);

        string checkedIngredients = string.Empty;
        if (ds.Tables[0].Rows.Count > 0)
        {
          foreach (DataRow item in ds.Tables[0].Rows)
          {
            checkedIngredients += item["id_ingredient"] + ",";
          }
          checkedIngredients = checkedIngredients.Remove(checkedIngredients.Length - 1);
        }
        return checkedIngredients;
      }

    }
  }
}
