using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using P8.Server.Controllers;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;
using P8.Shared;

namespace P8.Server.DB
{
    public class ClotheProvider
    {
        private readonly ClotheDbContext _context;
        private readonly ILogger _logger;
        public ClotheProvider(ClotheDbContext _context, ILoggerFactory loggerFactory){
            this._context = _context;
            this._logger = loggerFactory.CreateLogger("ClotheProvider");
        }
        public async Task AddClothe(Clothe clothe){
            var lastClothe = this._context.Clothes.ToArray().LastOrDefault();
            var lastId = this._context.Clothes.Select(arg => arg.Id).Max();
            var newId=0;
            if (!(lastClothe is null))
                newId = lastId +1;
            clothe.Id = newId;
            await _context.Clothes.AddAsync(clothe);
            await _context.SaveChangesAsync();
        }
        
        public List<Clothe> getAllClothes()=>
            this._context.Clothes.ToList();

        public List<Clothe> GetClothesByCategory(string Category)
            => this._context.Clothes.Where(arg => arg.Category == Category).ToList();
        
        public async Task RemoveClothes(int[] Ids){
            List<Clothe> TheClothes = this._context.Clothes.ToList();
            IEnumerable<Clothe> NewList = TheClothes.Where(arg => Ids.Contains(arg.Id));
            foreach(var i in NewList){
                this._context.Clothes.Remove(i);
            }
            await this._context.SaveChangesAsync();
        }

        public async Task UpdateClothe(Clothe clothe)
        {
            this._context.Clothes.Update(clothe);
            await this._context.SaveChangesAsync();
        }
}
}