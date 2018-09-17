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

      public City(string name, int population, string code)
      {
        Name = name;
        Population = population;
        CountryCode = code;
        ComputeContinent();
      }

      public string Name{ get; set;}
      public int Population { get; set;}
      public string CountryCode { get; set;}
      public string Continent { get; set;}
      public string Region { get; set;}


      public void ComputeContinent()
      {
        MySqlConnection conn = DB.Connection();
        conn.Open();
        MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
        cmd.CommandText = @"SELECT * FROM Country WHERE Code = '" + CountryCode + "';";
        MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
        while(rdr.Read())
        {
          Continent = rdr.GetString(2);
          Region = rdr.GetString(3);
        }
        conn.Close();
        if (conn != null)
        {
            conn.Dispose();
        }
      }


      public static List<City> FilterByCountry(string city, string sorting)
      {
          List<City> allCities = new List<City> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM City WHERE CountryCode = '" + city + "' ORDER BY Population " + sorting + ";";
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
            string cityCode = rdr.GetString(2);

            City newCity = new City(cityName, cityPopulation, cityCode);
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
