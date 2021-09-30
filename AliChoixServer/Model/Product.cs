using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliChoixServer.Model
{

    [BsonIgnoreExtraElements]
    public class Product
    {
        [BsonElement("_id")]
        public string UniversalProductCode { get; set; }

        [BsonElement("product_name")]
        public string Name { get; set; }

        [BsonElement("nutriscore_score")]
        public int NutriScore { get; set; }

        [BsonElement("ecoscore_score")]
        public int EcoScore { get; set; }

        [BsonElement("nutriments")]
        public Nutriments Nutriments { get; set; }

        [BsonElement("ingredients")]
        public List<Ingredient> Ingredients { get; set; }
    }

    [BsonIgnoreExtraElements]
    public partial class Ingredient
    {
        [BsonElement("text")]
        public string IngredientName { get; set; }
    }

    [BsonIgnoreExtraElements]
    public partial class Nutriments
    {
        [BsonElement("calcium_100g")]
        public double Calcium100G { get; set; }

        [BsonElement("calcium_serving")]
        public double CalciumServing { get; set; }

        [BsonElement("carbohydrates_100g")]
        public double Carbohydrates100G { get; set; }

        [BsonElement("carbohydrates_serving")]
        public double CarbohydratesServing { get; set; }

        [BsonElement("cholesterol_100g")]
        public double Cholesterol100G { get; set; }

        [BsonElement("cholesterol_serving")]
        public double CholesterolServing { get; set; }

        [BsonElement("energy-kcal_100g")]
        public double EnergyKcal100G { get; set; }

        [BsonElement("energy-kcal_serving")]
        public double EnergyKcalServing { get; set; }

        [BsonElement("energy_100g")]
        public double Energy100G { get; set; }

        [BsonElement("energy_serving")]
        public double EnergyServing { get; set; }

        [BsonElement("fat_100g")]
        public double Fat100G { get; set; }

        [BsonElement("fat_serving")]
        public double FatServing { get; set; }

        [BsonElement("fiber_100g")]
        public double Fiber100G { get; set; }

        [BsonElement("fiber_serving")]
        public double FiberServing { get; set; }

        [BsonElement("iron_100g")]
        public double Iron100G { get; set; }

        [BsonElement("iron_serving")]
        public double IronServing { get; set; }

        [BsonElement("proteins_100g")]
        public double Proteins100G { get; set; }

        [BsonElement("proteins_serving")]
        public double ProteinsServing { get; set; }

        [BsonElement("saturated-fat_100g")]
        public double SaturatedFat100G { get; set; }

        [BsonElement("saturated-fat_serving")]
        public double SaturatedFatServing { get; set; }

        [BsonElement("sodium_100g")]
        public double Sodium100G { get; set; }

        [BsonElement("sodium_serving")]
        public double SodiumServing { get; set; }

        [BsonElement("sugars_100g")]
        public double Sugars100G { get; set; }

        [BsonElement("sugars_serving")]
        public double SugarsServing { get; set; }

        [BsonElement("trans-fat_100g")]
        public double TransFat100G { get; set; }

        [BsonElement("trans-fat_serving")]
        public double TransFatServing { get; set; }

        [BsonElement("vitamin-a_100g")]
        public double VitaminA100G { get; set; }

        [BsonElement("vitamin-a_serving")]
        public double VitaminAServing { get; set; }

        [BsonElement("vitamin-c_100g")]
        public double VitaminC100G { get; set; }

        [BsonElement("vitamin-c_serving")]
        public double VitaminCServing { get; set; }
    }
}

