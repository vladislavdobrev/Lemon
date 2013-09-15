using MelonStore.Api.Models.StoreModels;
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
    public class StoresController : ApiController
    {
        private DbStoreRepository repo;
        private MelonStoreContext context;

        public StoresController()
        {
            this.context = new MelonStoreContext();
            this.repo = new DbStoreRepository(context);
        }


        [ActionName("all")]
        public HttpResponseMessage GetAll(string sessionKey)
        {
            if (!String.IsNullOrEmpty(sessionKey))
            {
                throw new ArgumentException("Not allowed action for non - logged user!");
            }

            IQueryable<Store> dbStores = this.repo.All();
            ICollection<StoreApiModel> stores =
                (from currStore in dbStores
                 select new StoreApiModel()
                 {
                     Name = currStore.Name,
                     Id = currStore.Id
                 }).ToList();

            return this.Request.CreateResponse(HttpStatusCode.OK, stores);
        }
    }
}
