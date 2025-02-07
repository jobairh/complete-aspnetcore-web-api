﻿using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using My_Books.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My_Books.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                if (!context.Books.Any())
                {
                    context.Books.AddRange(new Book()
                    {
                        Title = "1st Book Title",
                        Description = "1st Book Description",
                        ISRead = true,
                        DateRead = DateTime.Now.AddDays(-10),
                        Rate = 4,
                        Genre = "Biography",
                        Author = "First Author",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now
                    },
                    new Book()
                    {
                        Title = "2nd Book Title",
                        Description = "2nd Book Description",
                        ISRead = false,
                        Genre = "Biography",
                        Author = "First Author",
                        CoverUrl = "https....",
                        DateAdded = DateTime.Now

                    });

                    context.SaveChanges();
                }
            }
        }
    }
}
