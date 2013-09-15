using MelonStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MelonStore.Api.EnumConverters
{
    public static class Converter
    {
        public static List<Category> GetCategory(string[] categories)
        {

            List<Category> result = new List<Category>();
            for (int i = 0; i < categories.Length; i++)
			{
                categories[i] = categories[i][0].ToString().ToUpper() + categories[i].Substring(1, categories[i].Length - 1);

                if (categories[i] == Category.Jeans.ToString())
                {
                   result.Add(Category.Jeans);
                }

                if (categories[i] == Category.Shirts.ToString())
                {
                    result.Add(Category.Shirts);
                }

                if (categories[i] == Category.Shoes.ToString())
                {
                    result.Add(Category.Shoes);
                }

                if (categories[i] == Category.Shorts.ToString())
                {
                    result.Add(Category.Shorts);
                }

                if (categories[i] == Category.TShirts.ToString())
                {
                    result.Add(Category.TShirts);
                }

            }
            return result;
        }

        public static List<Gender> GetGender(string[] genders)
        {
            List<Gender> result = new List<Gender>();

            for (int i = 0; i < genders.Length; i++)
            {
                genders[i] = genders[i][0].ToString().ToUpper() + genders[i].Substring(1, genders[i].Length - 1);

                if (genders[i] == Gender.Female.ToString())
                {
                    result.Add(Gender.Female);
                }

                if (genders[i] == Gender.Male.ToString())
                {
                    result.Add(Gender.Male);
                }

            }
            return result;
        }
    }
}