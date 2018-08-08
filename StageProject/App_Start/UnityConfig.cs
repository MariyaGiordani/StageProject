using StageProject.Business;
using StageProject.DataBaseAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace StageProject.App_Start
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<ISqlDatabaseModel, SqlDatabaseModel>();
            container.RegisterType<ITelefoneBusiness, TelefoneBusiness>();
            container.RegisterType<IClienteBusiness, ClienteBusiness>();
            container.RegisterType<IEnderecoBusiness, EnderecoBusiness>();
            container.RegisterType<ICharacterBusiness, CharacterBusiness>();
            container.RegisterType<IFilmBusiness, FilmBusiness>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}