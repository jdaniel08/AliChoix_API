using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AliChoixServer.Model
{

    [BsonIgnoreExtraElements]
    public class OffMongoDbProduct
    {
        [BsonElement("_id")][JsonProperty("_id")]
        public string UniversalProductCode { get; set; }

        [BsonElement("product_name")][JsonProperty("product_name")]
        public string Name { get; set; }

        [JsonProperty("image_url")]
        [BsonElement("image_url")]
        public Uri ImageUrl { get; set; }

        [BsonElement("serving_quantity")][JsonProperty("serving_quantity")]
        public double ServingQuantity;

        [BsonElement("nutriscore_grade")][JsonProperty("nutriscore_grade")]
        public string NutriScore { get; set; }

        [BsonElement("ecoscore_grade")][JsonProperty("ecoscore_grade")]
        public string EcoScore { get; set; }

        [BsonElement("nutriments")][JsonProperty("nutriments")]
        public OffNutriments Nutriments { get; set; }

        [BsonElement("ingredients")][JsonProperty("ingredients")]
        public List<OffIngredient> Ingredients { get; set; }
    }

    [BsonIgnoreExtraElements]
    public partial class OffIngredient
    {
        [BsonElement("text")][JsonProperty("text")]
        public string IngredientName { get; set; }
    }

    [BsonIgnoreExtraElements]
    public partial class OffNutriments
    {
        [BsonElement("calcium")][JsonProperty("calcium")]
        public double Calcium { get; set; }

        [BsonElement("calcium_100g")][JsonProperty("calcium_100g")]
        public double Calcium100G { get; set; }

        [BsonElement("calcium_serving")][JsonProperty("calcium_serving")]
        public double CalciumServing { get; set; }

        [BsonElement("calcium_unit")][JsonProperty("calcium_unit")]
        public string CalciumUnit { get; set; }

        [BsonElement("calcium_value")][JsonProperty("calcium_value")]
        public double CalciumValue { get; set; }

        [BsonElement("carbohydrates")][JsonProperty("carbohydrates")]
        public double Carbohydrates { get; set; }

        [BsonElement("carbohydrates_100g")][JsonProperty("carbohydrates_100g")]
        public double Carbohydrates100G { get; set; }

        [BsonElement("carbohydrates_serving")][JsonProperty("carbohydrates_serving")]
        public double CarbohydratesServing { get; set; }

        [BsonElement("carbohydrates_unit")][JsonProperty("carbohydrates_unit")]
        public string CarbohydratesUnit { get; set; }

        [BsonElement("carbohydrates_value")][JsonProperty("carbohydrates_value")]
        public double CarbohydratesValue { get; set; }

        [BsonElement("cholesterol")][JsonProperty("cholesterol")]
        public double Cholesterol { get; set; }

        [BsonElement("cholesterol_100g")][JsonProperty("cholesterol_100g")]
        public double Cholesterol100G { get; set; }

        [BsonElement("cholesterol_serving")][JsonProperty("cholesterol_serving")]
        public double CholesterolServing { get; set; }

        [BsonElement("cholesterol_unit")][JsonProperty("cholesterol_unit")]
        public string CholesterolUnit { get; set; }

        [BsonElement("cholesterol_value")][JsonProperty("cholesterol_value")]
        public double CholesterolValue { get; set; }

        [BsonElement("energy")][JsonProperty("energy")]
        public double Energy { get; set; }

        [BsonElement("energy-kcal")][JsonProperty("energy-kcal")]
        public double EnergyKcal { get; set; }

        [BsonElement("energy-kcal_100g")][JsonProperty("energy-kcal_100g")]
        public double EnergyKcal100G { get; set; }

        [BsonElement("energy-kcal_serving")][JsonProperty("energy-kcal_serving")]
        public double EnergyKcalServing { get; set; }

        [BsonElement("energy-kcal_unit")][JsonProperty("energy-kcal_unit")]
        public string EnergyKcalUnit { get; set; }

        [BsonElement("energy-kcal_value")][JsonProperty("energy-kcal_value")]
        public double EnergyKcalValue { get; set; }

        [BsonElement("energy_100g")][JsonProperty("energy_100g")]
        public double Energy100G { get; set; }

        [BsonElement("energy_serving")][JsonProperty("energy_serving")]
        public double EnergyServing { get; set; }

        [BsonElement("energy_unit")][JsonProperty("energy_unit")]
        public string EnergyUnit { get; set; }

        [BsonElement("energy_value")][JsonProperty("energy_value")]
        public double EnergyValue { get; set; }

        [BsonElement("fat")][JsonProperty("fat")]
        public double Fat { get; set; }

        [BsonElement("fat_100g")][JsonProperty("fat_100g")]
        public double Fat100G { get; set; }

        [BsonElement("fat_serving")][JsonProperty("fat_serving")]
        public double FatServing { get; set; }

        [BsonElement("fat_unit")][JsonProperty("fat_unit")]
        public string FatUnit { get; set; }

        [BsonElement("fat_value")][JsonProperty("fat_value")]
        public double FatValue { get; set; }

        [BsonElement("fiber")][JsonProperty("fiber")]
        public double Fiber { get; set; }

        [BsonElement("fiber_100g")][JsonProperty("fiber_100g")]
        public double Fiber100G { get; set; }

        [BsonElement("fiber_serving")][JsonProperty("fiber_serving")]
        public double FiberServing { get; set; }

        [BsonElement("fiber_unit")][JsonProperty("fiber_unit")]
        public string FiberUnit { get; set; }

        [BsonElement("fiber_value")][JsonProperty("fiber_value")]
        public double FiberValue { get; set; }

        [BsonElement("iron")][JsonProperty("iron")]
        public double Iron { get; set; }

        [BsonElement("iron_100g")][JsonProperty("iron_100g")]
        public double Iron100G { get; set; }

        [BsonElement("iron_serving")][JsonProperty("iron_serving")]
        public double IronServing { get; set; }

        [BsonElement("iron_unit")][JsonProperty("iron_unit")]
        public string IronUnit { get; set; }

        [BsonElement("iron_value")][JsonProperty("iron_value")]
        public double IronValue { get; set; }

        [BsonElement("monounsaturated-fat_100g")][JsonProperty("monounsaturated")]
        public double MonounsaturatedFat100G { get; set; }

        [BsonElement("monounsaturated-fat_serving")][JsonProperty("monounsaturated-fat_serving")]
        public double MonounsaturatedFatServing { get; set; }

        [BsonElement("monounsaturated-fat_unit")][JsonProperty("monounsaturated-fat_unit")]
        public string MonounsaturatedFatUnit { get; set; }

        [BsonElement("monounsaturated-fat_label")][JsonProperty("monounsaturated-fat_label")]
        public double MonounsaturatedFatLabel { get; set; }

        [BsonElement("monounsaturated-fat")][JsonProperty("monounsaturated-fat")]
        public double MonounsaturatedFat { get; set; }

        [BsonElement("monounsaturated-fat_value")][JsonProperty("monounsaturated-fat_value")]
        public double MonounsaturatedFatValue { get; set; }

        [BsonElement("nova-group")][JsonProperty("nova-group")]
        public double NovaGroup { get; set; }

        [BsonElement("nova-group_100g")][JsonProperty("nova-group_100g")]
        public double NovaGroup100G { get; set; }

        [BsonElement("nova-group_serving")][JsonProperty("nova-group_serving")]
        public double NovaGroupServing { get; set; }

        [BsonElement("polyunsaturated-fat_unit")][JsonProperty("polyunsaturated-fat_unit")]
        public string PolyunsaturatedFatUnit { get; set; }

        [BsonElement("polyunsaturated-fat_serving")][JsonProperty("polyunsaturated-fat_serving")]
        public double PolyunsaturatedFatServing { get; set; }

        [BsonElement("polyunsaturated-fat_value")][JsonProperty("polyunsaturated-fat_value")]
        public double PolyunsaturatedFatValue { get; set; }

        [BsonElement("polyunsaturated-fat_label")][JsonProperty("polyunsaturated-fat_label")]
        public double PolyunsaturatedFatLabel { get; set; }

        [BsonElement("polyunsaturated-fat_100g")][JsonProperty("polyunsaturated-fat_100g")]
        public double PolyunsaturatedFat100G { get; set; }

        [BsonElement("polyunsaturated-fat")][JsonProperty("polyunsaturated-fat")]
        public double PolyunsaturatedFat { get; set; }

        [BsonElement("proteins")][JsonProperty("proteins")]
        public double Proteins { get; set; }

        [BsonElement("proteins_100g")][JsonProperty("proteins_100g")]
        public double Proteins100G { get; set; }

        [BsonElement("proteins_serving")][JsonProperty("proteins_serving")]
        public double ProteinsServing { get; set; }

        [BsonElement("proteins_unit")][JsonProperty("proteins_unit")]
        public string ProteinsUnit { get; set; }

        [BsonElement("proteins_value")][JsonProperty("proteins_value")]
        public double ProteinsValue { get; set; }

        [BsonElement("salt")][JsonProperty("salt")]
        public double Salt { get; set; }

        [BsonElement("salt_100g")][JsonProperty("salt_100g")]
        public double Salt100G { get; set; }

        [BsonElement("salt_serving")][JsonProperty("salt_serving")]
        public double SaltServing { get; set; }

        [BsonElement("salt_unit")][JsonProperty("salt_unit")]
        public string SaltUnit { get; set; }

        [BsonElement("salt_value")][JsonProperty("salt_value")]
        public double SaltValue { get; set; }

        [BsonElement("saturated-fat")][JsonProperty("saturated-fat")]
        public double SaturatedFat { get; set; }

        [BsonElement("saturated-fat_100g")][JsonProperty("saturated-fat_100g")]
        public double SaturatedFat100G { get; set; }

        [BsonElement("saturated-fat_serving")][JsonProperty("saturated-fat_serving")]
        public double SaturatedFatServing { get; set; }

        [BsonElement("saturated-fat_unit")][JsonProperty("saturated-fat_unit")]
        public string SaturatedFatUnit { get; set; }

        [BsonElement("saturated-fat_value")][JsonProperty("saturated-fat_value")]
        public double SaturatedFatValue { get; set; }

        [BsonElement("sodium")][JsonProperty("sodium")]
        public double Sodium { get; set; }

        [BsonElement("sodium_100g")][JsonProperty("sodium_100g")]
        public double Sodium100G { get; set; }

        [BsonElement("sodium_serving")][JsonProperty("sodium_serving")]
        public double SodiumServing { get; set; }

        [BsonElement("sodium_unit")][JsonProperty("sodium_unit")]
        public string SodiumUnit { get; set; }

        [BsonElement("sodium_value")][JsonProperty("sodium_value")]
        public double SodiumValue { get; set; }

        [BsonElement("sugars")][JsonProperty("sugars")]
        public double Sugars { get; set; }

        [BsonElement("sugars_100g")][JsonProperty("sugars_100g")]
        public double Sugars100G { get; set; }

        [BsonElement("sugars_serving")][JsonProperty("sugars_serving")]
        public double SugarsServing { get; set; }

        [BsonElement("sugars_unit")][JsonProperty("sugars_unit")]
        public string SugarsUnit { get; set; }

        [BsonElement("sugars_value")][JsonProperty("sugars_value")]
        public double SugarsValue { get; set; }

        [BsonElement("trans-fat")][JsonProperty("trans-fat")]
        public double TransFat { get; set; }

        [BsonElement("trans-fat_100g")][JsonProperty("trans-fat_100g")]
        public double TransFat100G { get; set; }

        [BsonElement("trans-fat_serving")][JsonProperty("trans-fat_serving")]
        public double TransFatServing { get; set; }

        [BsonElement("trans-fat_unit")][JsonProperty("trans-fat_unit")]
        public string TransFatUnit { get; set; }

        [BsonElement("trans-fat_value")][JsonProperty("trans-fat_value")]
        public double TransFatValue { get; set; }

        [BsonElement("vitamin-a")][JsonProperty("vitamin-a")]
        public double VitaminA { get; set; }

        [BsonElement("vitamin-a_100g")][JsonProperty("vitamin-a_100g")]
        public double VitaminA100G { get; set; }

        [BsonElement("vitamin-a_serving")][JsonProperty("vitamin-a_serving")]
        public double VitaminAServing { get; set; }

        [BsonElement("vitamin-a_unit")][JsonProperty("vitamin-a_unit")]
        public string VitaminAUnit { get; set; }

        [BsonElement("vitamin-a_value")][JsonProperty("vitamin-a_value")]
        public double VitaminAValue { get; set; }

        [BsonElement("vitamin-c")][JsonProperty("vitamin-c")]
        public double VitaminC { get; set; }

        [BsonElement("vitamin-c_100g")][JsonProperty("vitamin-c_100g")]
        public double VitaminC100G { get; set; }

        [BsonElement("vitamin-c_serving")][JsonProperty("vitamin-c_serving")]
        public double VitaminCServing { get; set; }

        [BsonElement("vitamin-c_unit")][JsonProperty("vitamin-c_unit")]
        public string VitaminCUnit { get; set; }

        [BsonElement("vitamin-c_value")][JsonProperty("vitamin-c_value")]
        public double VitaminCValue { get; set; }

        [BsonElement("vitamin-e_unit")][JsonProperty("vitamin-e_unit")]
        public string VitaminEUnit { get; set; }

        [BsonElement("vitamin-e")][JsonProperty("vitamin-e")]
        public double VitaminE { get; set; }

        [BsonElement("vitamin-e_value")][JsonProperty("vitamin-e_value")]
        public double VitaminEValue { get; set; }

        [BsonElement("vitamin-e_100g")][JsonProperty("vitamin-e_100g")]
        public double VitaminE100G { get; set; }

        [BsonElement("vitamin-e_serving")][JsonProperty("vitamin-e_serving")]
        public double VitaminEServing { get; set; }
    }
}

