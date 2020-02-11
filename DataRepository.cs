using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace HairSalon.Data
{
    public class DataRepository
    {
        private const string ConnectionString = "server=127.0.0.1;uid=root;pwd=amsvp120486;database=hair_salon";
        
        public IEnumerable<StartPage> GetStartPageForFirstPage()
        {
            var startPages = new List<StartPage>();
            var connection = new MySqlConnection(ConnectionString);
            var command = connection.CreateCommand();
            command.CommandText = "select*from hair_salon.startPage";
            command.CommandType = CommandType.Text;
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    startPages.Add(MapStartPage(reader));
                }

            } catch(Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

            //startPages.Add(new StartPage()
            //{
            //    Id = 3,
            //    ShortDescription = "Nākotnes Plāni",
            //    Description = "dddddddddddddddddddddddddddddddddddddd",
            //    BigPicturePath = "3wwwwwwwwwwwwwwwww"
            //});
            return startPages;
        }
        public IEnumerable<PriceTag> GetPriceTag (int count=4) //cik daudz būs lauciņu
        {
            var priceTags = new List<PriceTag>();
            var startPages = new List<PriceTag>();
            var connection = new MySqlConnection(ConnectionString);
            var command = connection.CreateCommand();
            command.CommandText = "select*from hair_salon.priceTag";
            command.CommandType = CommandType.Text;
            try
            {
                connection.Open();
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    priceTags.Add(MapPriceTag(reader));
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
            //priceTags.Add(new PriceTag()
            //{
            //    Id = 3,
            //    ShortDescription = "Bērnu matu griezums",
            //    Description = "abbbbbbbbbbbbbbbbbbbaaaaaaaaaaaaaaaa",
            //    PriceTags = "30 euro",
            //    BigPicturePath = "3wwwwwwwwwwwwwwwww",
            //    Path = "3WWWWWWWWWWWW"
            //});
            return priceTags;
        }
        private bool IsNotNull(string columnName, MySqlDataReader reader)
        {
            return !reader.IsDBNull(reader.GetOrdinal(columnName));
        }
        private StartPage MapStartPage (MySqlDataReader reader)
        {
            return new StartPage()
            {
                Id = reader.GetInt32("startPages_id"),

                ShortDescription = IsNotNull("startPages_short_description", reader)
                            ? reader.GetString("startPages_short_description")
                            : "",
                Description = IsNotNull("startPages_description", reader)
                            ? reader.GetString("startPages_description")
                            : "",
                BigPicturePath = IsNotNull("startPages_description", reader)
                            ? reader.GetString("startPages_description")
                            : "",
            };
        }
        private PriceTag MapPriceTag(MySqlDataReader reader)
        {
            return new PriceTag()
            {
                Id = reader.GetInt32("priceTags_id"),

                ShortDescription = IsNotNull("priceTags_short_description", reader)
                            ? reader.GetString("priceTags_short_description")
                            : "",
                Description = IsNotNull("priceTags_description", reader)
                            ? reader.GetString("priceTags_description")
                            : "",
                PriceTags = IsNotNull("priceTags_price_tags", reader)
                            ? reader.GetString("priceTags_price_tags")
                            : "",
                BigPicturePath = IsNotNull("priceTags_description", reader)
                            ? reader.GetString("priceTags_description")
                            : "",
                Path = IsNotNull("priceTags_path", reader)
                            ? reader.GetString("priceTags_path")
                            : "",
            };
        }
    }
}
