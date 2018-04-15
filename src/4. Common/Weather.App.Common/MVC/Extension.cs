﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Weather.App.Common.MVC
{
    namespace DShop.Common.Mvc
    {
        public static class Extensions
        {
            public static IMvcBuilder AddDefaultJsonOptions(this IMvcBuilder builder)
            {
                return builder.AddJsonOptions(opts =>
                {
                    opts.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    opts.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    opts.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                    opts.SerializerSettings.PreserveReferencesHandling = PreserveReferencesHandling.None;
                    opts.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                    opts.SerializerSettings.Formatting = Formatting.Indented;
                    opts.SerializerSettings.Converters.Add(new StringEnumConverter());
                });
            }

            public static IApplicationBuilder UseErrorHandler(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<ErrorHandlerMiddleware>();
            }
        }
    }
}