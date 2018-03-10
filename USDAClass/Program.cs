using System;
using System.IO; 
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Bson.Serialization;

namespace USDAClass
{
    class Program
    {
        static void Main(string[] args)
        {
            //makes a class mapping for the recipe class
            //so it can be serialized as bson object
            BsonClassMap.RegisterClassMap<Ingredient>(cm =>
            {
                cm.AutoMap();
            });

            MongoClient _client = MongoClientFactory.GetInstance();
            StreamReader sr = new StreamReader("ABBREV.txt");
            StreamWriter sw = new StreamWriter("USDAOutput.txt");
            List<ParserClass> Ingredients = new List<ParserClass>();
            List<Ingredient> convertedIngredients = new List<Ingredient>();

            string data = sr.ReadLine();
            while (data != null)
            {
                ParserClass test = new ParserClass(data, sr, sw);
                Ingredients.Add(test);
                data = sr.ReadLine();
            }

            foreach(var ingredient in Ingredients){
                Ingredient ci = new Ingredient();
                ci.NBD_No = ingredient.NBD_No;
                ci.Shrt_Desc = ingredient.Shrt_Desc;
                ci.GmWt1 = ingredient.GmWt1;
                ci.GmWt_Desc1 = ingredient.GmWt_Desc1;
                ci.GmWt2 = ingredient.GmWt2;
                ci.GmWt_Desc2 = ingredient.GmWt_Desc2;
                ci.Calories = ingredient.Calories;
                ci.Protein = ingredient.Protein;
                ci.Fat = ingredient.Fat;
                ci.Carbohydate = ingredient.Carbohydate;
                ci.Fiber = ingredient.Fiber;
                ci.Sugar = ingredient.Sugar;
                ci.Calcium = ingredient.Calcium;
                ci.Iron = ingredient.Iron;
                ci.Potassium = ingredient.Potassium;
                ci.Sodium = ingredient.Sodium;
                ci.Vitamin_C = ingredient.Vitamin_C;
                ci.Vit_A_IU = ingredient.Vit_A_IU;
                ci.Vit_D_IU = ingredient.Vit_D_IU;
                ci.Cholestrol = ingredient.Cholestrol;
                convertedIngredients.Add(ci);
            }

            var db = _client.GetDatabase("food-data");
            var collection = db.GetCollection<Ingredient>("ingredients");

            collection.InsertMany(convertedIngredients);

            //string name = "";
            //do
            //{
            //    Console.WriteLine("Enter an ingredient name:");
            //    name = Console.ReadLine();
            //    name = name.ToUpper();
            //    for (int i = 0; i < Ingredients.Count; i++)
            //    {
            //        if (Ingredients[i].Shrt_Desc.Contains(name))
            //            Console.WriteLine(Ingredients[i].Shrt_Desc);
            //    }
            //} while (name != "q");
        }
    }
}
