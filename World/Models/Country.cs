using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using World;

namespace World.Models
{
    public class Country
    {
      public Country(string name, string continent, int population)
      {
        Name = name;
        Continent = continent;
        Population = population;
      }

      public string Name{ get; set;}
      public string Continent { get; set;}
      public int Population { get; set;}

      public static List<Country> GetAll()
      {
          List<Country> allCountries = new List<Country> {};
          MySqlConnection conn = DB.Connection();
          conn.Open();
          MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
          cmd.CommandText = @"SELECT * FROM Country;";
          MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
          while(rdr.Read())
          {
            string countryName = rdr.GetString(1);
            int countryPopulation = rdr.GetInt32(6);
            string countryContinent = rdr.GetString(2);

            Country newCountry = new Country(countryName, countryContinent, countryPopulation);
            allCountries.Add(newCountry);
          }
          conn.Close();
          if (conn != null)
          {
              conn.Dispose();
          }
          return allCountries;
      }


    }
}
