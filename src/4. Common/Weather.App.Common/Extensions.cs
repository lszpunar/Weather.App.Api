﻿using Microsoft.Extensions.Configuration;

namespace Weather.App.Common
{
    public static class Extensions
    {
        public static TModel GetOptions<TModel>(this IConfiguration configuration, string sectionName)
            where TModel : new()
        {
            var model = new TModel();
            configuration.GetSection(sectionName).Bind(model);
            return model;
        }
    }
}