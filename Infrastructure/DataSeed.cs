using System.Linq;
using AppCore.Models;
using System;
namespace Infrastructure
{
    public class DataSeeds
    {
        public static void Initialize(ElectronicsStoreContext context)
        {
            context.Database.EnsureCreated();

        }
    }
}