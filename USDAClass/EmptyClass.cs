using System;
using System.IO; 
namespace USDAClass
{
    struct constants{
        public const int MAX = 53; 
    }
    public partial class ParserClass
    {
        public ParserClass(string data, StreamReader sr, StreamWriter sw)
        {
            string[] values = data.Split('^');
            values[0] = values[0].Trim('~');
            values[1] = values[1].Trim('~');
            values[49] = values[49].Trim('~');
            values[51] = values[51].Trim('~');
            NBD_No = values[0];
            Shrt_Desc = values[1];
               if (values[3].IsNumeric())
            {
                Calories = Convert.ToDouble(values[3]);
            }
            else 
            {
                Calories = 0;
            }

            if (values[4].IsNumeric())
            {
                Protein = Convert.ToDouble(values[4]);
            }
            else 
            {
                Protein = 0;
            }
            if (values[5].IsNumeric())
            {
                Fat = Convert.ToDouble(values[5]);
            }
            else 
            {
                Fat = 0;
            }
            if (values[7].IsNumeric())
            {
                Carbohydate = Convert.ToDouble(values[7]);
            }
            else {
                Carbohydate = 0;
            }
            if (values[8].IsNumeric())
            {
                Fiber = Convert.ToDouble(values[8]);
            }
            else 
            {
                Fiber = 0;
            }
            if (values[9].IsNumeric())
            {
                Sugar = Convert.ToDouble(values[9]);
            }
            else 
            {
                Sugar = 0;
            }
            if (values[10].IsNumeric())
            {
                Calcium = Convert.ToDouble(values[10]);
            }
            else 
            {
                Calcium = 0;
            }
            if (values[11].IsNumeric())
            {
                Iron = Convert.ToDouble(values[11]);
            }
            else
            {
                Iron = 0;
            }
            if (values[14].IsNumeric())
            {
                Potassium = Convert.ToDouble(values[14]);
            }
            else
            {
                Potassium = 0;
            }
            if (values[15].IsNumeric())
            {
                Sodium = Convert.ToDouble(values[15]);
            }
            else
            {
                Sodium = 0;
            }
            if (values[20].IsNumeric())
            {
                Vitamin_C = Convert.ToDouble(values[20]);
            }
            else
            {
                Vitamin_C = 0;
            }

            if (values[32].IsNumeric())
            {
                Vit_A_IU = Convert.ToDouble(values[32]);
            }
            else
            {
                Vit_A_IU = 0;
            }
            if (values[42].IsNumeric())
            {
                Vit_D_IU = Convert.ToDouble(values[42]);
            }
            else
            {
                Vit_D_IU = 0;
            }
            if (values[47].IsNumeric())
            {
                Cholestrol = Convert.ToDouble(values[47]);
            }
            else
            {
                Cholestrol = 0;
            }

            GmWt1 = values[48];
            GmWt_Desc1 = values[49];
            GmWt2 = values[50];
            GmWt_Desc2 = values[51];
            sw.WriteLine();
        }
      //  public void findIngredient(string `){
            
      //  } 
       
        public string NBD_No, Shrt_Desc, GmWt1, GmWt_Desc1, GmWt2, GmWt_Desc2;
        public double Calories, Protein, Fat, Carbohydate, Fiber,
        Sugar, Calcium, Iron, Potassium, Sodium, 
        Vitamin_C, Vit_A_IU, Vit_D_IU, Cholestrol;
    }
    public static class StringExtensions
    {
        public static bool IsNumeric(this string input)
        {
            double number;
            return double.TryParse(input, out number);
        }
    }
}
