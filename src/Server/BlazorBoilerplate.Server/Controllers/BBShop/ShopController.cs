using BlazorBoilerplate.Infrastructure.AuthorizationDefinitions;
using BlazorBoilerplate.Infrastructure.Storage.DataModels;
using BlazorBoilerplate.Shared.Models;
using BlazorBoilerplate.Storage;
using Breeze.AspNetCore;
using Breeze.Persistence;
using Breeze.Persistence.EFCore;
using IdentityServer4.AccessTokenValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorBoilerplate.Server.Controllers
{
    [Route("api/shop/[action]")]
    [Authorize(AuthenticationSchemes = AuthSchemes)]
    [BreezeQueryFilter]
    public class ShopController : Controller
    {
        private const string AuthSchemes =
        "Identity.Application" + "," + IdentityServerAuthenticationDefaults.AuthenticationScheme; //Cookie + Token authentication

        private readonly ApplicationPersistenceManager persistenceManager;
        public ShopController(ApplicationPersistenceManager persistenceManager)
        {
            this.persistenceManager = persistenceManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public string Metadata()
        {
            return persistenceManager.Metadata();
        }


        [HttpGet]
        [AllowAnonymous]
        public IQueryable<Categories> Categories()
        {
            return persistenceManager.GetEntities<Categories>()
                .Include(i => i.CreatedBy)
                .Include(i => i.ModifiedBy)
                .OrderByDescending(i => i.CreatedOn);
        }

        [HttpGet]
        [AllowAnonymous]
        public IQueryable<Product> Products(int id)
        {
            return persistenceManager.GetEntities<Product>()
                                     .Include(i => i.CreatedBy)
                                     .Include(i => i.ModifiedBy)
                                     .Where(t=> id > 0 ? t.Id == id : true)
                                     .OrderByDescending(i => i.Title);
        }

        [AllowAnonymous]
        [HttpPost]
        public SaveResult SaveChanges([FromBody] JObject saveBundle)
        {
            try
            {
                return persistenceManager.SaveChanges(saveBundle);
            }
            catch (EntityErrorsException)
            {
                throw;
            }
            catch (Exception ex)
            {
                var errors = new List<EFEntityError>
                {
                    new EFEntityError(null, null, ex.GetBaseException().Message, null)
                };

                throw new EntityErrorsException(errors);
            }
        }
    }
}
