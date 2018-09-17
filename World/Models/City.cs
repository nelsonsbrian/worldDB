using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World;

namespace World.Models
{
    public class City
    {
      public City(string name, int population)
      {
        Name = name;
        Population = population;
      }

      public string Name{ get; set;}
      public int Population { get; set;}



      public static List<City> FilterByCountry(string city)
      {
          List<City> allCities = new List<City> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM City WHERE CountryCode = '" + city + "' ORDER BY name ASC;";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            string cityName = rdr.GetString(1);
            int cityPopulation = rdr.GetInt32(4);

            City newCity = new City(cityName, cityPopulation);
            allCities.Add(newCity);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allCities;
      }





      public static List<City> GetAll()
      {
          List<City> allCities = new List<City> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM City ORDER BY name ASC;";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            string cityName = rdr.GetString(1);
            int cityPopulation = rdr.GetInt32(4);

            City newCity = new City(cityName, cityPopulation);
            allCities.Add(newCity);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allCities;
      }


    }
}
