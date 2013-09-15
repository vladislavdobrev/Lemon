using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.WebApi.Bridges
{
    public static class Searilizator
    {
        public static T_TransferTo Searilize<T_TransferTo, T_TransferFrom>(T_TransferFrom model)
            where T_TransferTo : class, new()
        {
            T_TransferTo newModel = new T_TransferTo();

            foreach (var prop in newModel.GetType().GetProperties())
            {
                if (model.GetType().GetProperty(prop.Name) != null)
                {
                    prop.SetValue(newModel, model.GetType().GetProperty(prop.Name).GetValue(model));
                }
            }
            return newModel;
        }
    }
}