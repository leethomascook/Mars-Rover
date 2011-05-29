using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using StructureMap;

namespace Akqa.MarsRover.Web.Classes
{
    public class StructureMapControllerFactory : DefaultControllerFactory
    {

        protected override IController GetControllerInstance(RequestContext requestContext, Type controllerType)
        {

            IController result = null;
            try
            {
                if (controllerType == null) return base.GetControllerInstance(requestContext, controllerType);
                result = ObjectFactory.GetInstance(controllerType) as Controller;

            }
            catch (StructureMapException)
            {
                System.Diagnostics.Debug.WriteLine(ObjectFactory.WhatDoIHave());
                throw;
            }

            return result;
        }

    }
}