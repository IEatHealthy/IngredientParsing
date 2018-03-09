using System;

namespace USDAClass
{
    public class Ingredient
    {
        //Note, all properties are guaranteed to be
        //initialized before submitting to the database
        public string NBD_No { get; set; }
        public string Shrt_Desc { get; set; }
        public string GmWt1 { get; set; }
        public string GmWt_Desc1 { get; set; }
        public string GmWt2 { get; set;  }
        public string GmWt_Desc2 { get; set; }
        public double Calories { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
        public double Carbohydate { get; set; }
        public double Fiber { get; set; }
        public double Sugar { get; set; }
        public double Calcium { get; set; }
        public double Iron { get; set; }
        public double Potassium { get; set; }
        public double Sodium { get; set; }
        public double Vitamin_C { get; set; }
        public double Vit_A_IU { get; set; }
        public double Vit_D_IU { get; set; }
        public double Cholestrol { get; set; }

        public void print(){
            Console.WriteLine("Ingredient No.: " + NBD_No);
            Console.WriteLine("Description: " + Shrt_Desc);
        }
    }
}
