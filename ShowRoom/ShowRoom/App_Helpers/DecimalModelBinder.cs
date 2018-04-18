﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShowRoom.App_Helpers
{
    public class DecimalModelBinder : IModelBinder
    {
        public object BindModel(
            ControllerContext controllerContext,
            ModelBindingContext bindingContext)
        {
            ValueProviderResult valueResult =
                bindingContext.ValueProvider
                    .GetValue(bindingContext.ModelName);
            ModelState modelState =
                new ModelState { Value = valueResult };
            object actualValue = null;
            try
            {
                actualValue = Convert.ToDecimal(
                    string.IsNullOrEmpty(valueResult.AttemptedValue) ? "0" : valueResult.AttemptedValue,
                    CultureInfo.CurrentCulture);
            }
            catch (FormatException e)
            {
                modelState.Errors.Add(e);
            }

            bindingContext.ModelState.Add(
                bindingContext.ModelName, modelState);
            return actualValue;
        }
    }
}