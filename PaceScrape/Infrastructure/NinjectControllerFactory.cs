using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using PaceScrape.Domain.Concrete;
using PaceScrape.Domain.Abstract;
using System.Web.Mvc;
using System.Web.Routing;

namespace PaceScrape.Infrastructure
{

    public class NinjectControllerFactory : DefaultControllerFactory
    {
        private IKernel ninjectKernel;

        public NinjectControllerFactory()
        {
            ninjectKernel = new StandardKernel();
            AddBindings();
        }

        protected override IController GetControllerInstance(RequestContext
            requestContext, Type controllerType)
        {
            return controllerType == null ? null : (IController)ninjectKernel.Get(controllerType);
        }

        private void AddBindings()
        {
            ninjectKernel.Bind<IPaceRepository>().To<PaceRepository>();

        }
    }
}