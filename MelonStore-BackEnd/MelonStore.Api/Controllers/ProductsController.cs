using MelonStore.Api.EnumConverters;
using MelonStore.Api.Models.ProductModels;
using MelonStore.Api.Models.ProductStoreModels;
using MelonStore.Data;
using MelonStore.Models;
using MelonStore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MelonStore.Api.Controllers
{
    public class ProductsController : ApiController
    {
        private DbProductRepository repo;
        private MelonStoreContext context;

        public ProductsController()
        {
            this.context = new MelonStoreContext();
            this.repo = new DbProductRepository(context);
        }

        [ActionName("all")]
        public HttpResponseMessage GetAll(string sessionKey)
        {
            if (!String.IsNullOrEmpty(sessionKey))
            {
                throw new ArgumentException("Not allowed action for non - logged user!");
            }
            IQueryable<Product> dbProducts = this.repo.All();
            ICollection<ProductApiModel> products =
                (from currProduct in dbProducts
                 select new ProductApiModel()
                 {
                     Name = currProduct.Name,
                     ImagePath = currProduct.Image.Url,
                 }).ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, products);
        }

        [ActionName("postFiltered")]
        public HttpResponseMessage PostFiltered(FiltrationModel filter,string sessionKey)
        {
            if (!String.IsNullOrEmpty(sessionKey))
            {
                throw new ArgumentException("Not allowed action for non - logged user!");
            }

            List<Gender> gen = Converter.GetGender(filter.Genders);
            List<Category> cat = Converter.GetCategory(filter.Categories);

            ICollection<Product> dbFiltered = this.repo.Get(gen, cat);

            return this.Request.CreateResponse(HttpStatusCode.OK, dbFiltered);
        }
    }
}
