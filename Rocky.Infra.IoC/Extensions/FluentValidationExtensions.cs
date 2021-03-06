﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Rocky.Application.Validators.ApplicationType;
using Rocky.Application.Validators.ApplicationUser;
using Rocky.Application.Validators.Category;
using Rocky.Application.Validators.InquiryHeader;
using Rocky.Application.Validators.Product;
using Rocky.Application.Validators.ShoppingCart;
using Rocky.Application.ViewModels;
using Rocky.Application.ViewModels.Dtos.ApplicationType;
using Rocky.Application.ViewModels.Dtos.Category;
using Rocky.Application.ViewModels.Dtos.InquiryHeader;
using Rocky.Application.ViewModels.Dtos.Product;
using Rocky.Domain.Entities;

namespace Rocky.Infra.IoC.Extensions
{
    public static class FluentValidationExtensions
    {
        public static IServiceCollection RegisterValidation(this IServiceCollection services, IMvcBuilder builder)
        {
            builder.AddFluentValidation();

            services.AddTransient<IValidator<CategoryAddDto>, CategoryAddDtoValidator>();
            services.AddTransient<IValidator<CategoryEditDto>, CategoryEditDtoValidator>();
            services.AddTransient<IValidator<ApplicationTypeAddDto>, ApplicationTypeAddDtoValidator>();
            services.AddTransient<IValidator<ApplicationTypeEditDto>, ApplicationTypeEditDtoValidator>();
            services.AddTransient<IValidator<ProductUpsertDto>, ProductUpsertDtoValidator>();
            services.AddTransient<IValidator<InquiryHeaderAddDto>, InquiryHeaderAddDtoValidator>();
            services.AddTransient<IValidator<InquiryHeaderEditDto>, InquiryHeaderEditDtoValidator>();
            services.AddTransient<IValidator<ApplicationUser>, ApplicationUserValidator>();
            services.AddTransient<IValidator<DetailsVm>, DetailVmValidator>();

            return services;
        }
    }
}
