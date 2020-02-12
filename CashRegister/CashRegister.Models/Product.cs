using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace CashRegister.Models
{
    public class Product
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("price")]
        public decimal Price { get; set; }
    }
}
