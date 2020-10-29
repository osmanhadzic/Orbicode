using Orbicode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Orbicode.Data
{
   
        public static class DbInitializer
        {
            public static void Initialize(RestoranContext context)
            {
                context.Database.EnsureCreated();

                if (context.restorans.Any())
                {
                    return;
                }

            var resoran = new Restoran[]
            {
                new Restoran{id=1,naziv="Limenka",adresa="Tuzla",brojTelefona="777772"},
            };

            foreach(Restoran r in resoran)
            {
                context.restorans.Add(r);

            }
            context.SaveChanges();

        }

        }
    }

