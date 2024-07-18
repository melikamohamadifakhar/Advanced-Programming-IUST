using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P8.Server.DB;
using P8.Shared;

namespace P8.Server.Controllers
{
    [ApiController]
    [Route("api/[Controller]")] // api/Clothe
    public class ClotheController : ControllerBase
    {
        public static List<Clothe> Clothes = new List<Clothe>{
            new Clothe{Name="Shirt", Id=1, Price=100_000, Color="Black"},
            new Clothe{Name="Hat", Id=2, Price=200_000, Color="Green"},
            new Clothe{Name="Skirt", Id=3, Price=300_000, Color="Red"}
        };
        [HttpGet("GetAllClothes")]
        // [Route("clothes")] // api/Clothe/clothes
        public List<Clothe> GetAllClothes(){
            return ClotheController.Clothes;
        }
        [HttpGet("GetClotheById/{id}")]
        // [Route("GetClotheById")]
        public Clothe GetClotheById(int id) => ClotheController.Clothes.Where(clothe => clothe.Id == id).FirstOrDefault();
        [HttpPost("AddNewClothe")]
        public Clothe AddNewClothe(Clothe clothe){
            var newId = ClotheController.Clothes.Last().Id + 1;
            var newClothe = new Clothe{Price = clothe.Price, Name = clothe.Name,Id = newId, Color = clothe.Color};
            ClotheController.Clothes.Add(newClothe);
            return newClothe;
        }
        [HttpDelete]
        [Route("RemoveClothe")]
        public List<Clothe> RemoveClothe(int[] ids){
            Clothes = Clothes.Where(cloth => (!ids.Contains(cloth.Id))).ToList();
            return Clothes;
        }
        [HttpPut("UpdateClotheName")]
        // [HttpPut("UpdateClotheName/{id}/{new_name}")]
        public Clothe UpdateClotheName(int id, string new_name){
            var Clothe = Clothes.Where(arg => arg.Id==id).FirstOrDefault();
            Clothe.Name = new_name;
            return Clothe;
        }
        [HttpPut]
        [Route("UpdateClothe")]
        public Clothe UpdateClothe(Clothe NewClothe){
            // var Clothe = Clothes.Where(arg => arg.Id==NewClothe.Id).FirstOrDefault();
            var idx = Clothes.IndexOf(NewClothe);
            Clothes[idx]  = NewClothe;
            return Clothes[idx];
        }
        private readonly ClotheProvider _provider;
        public ClotheController(ClotheProvider provider){
            this._provider = provider;
        }
        [HttpPost("addNewClotheToDb")]
        public async Task<Clothe> addNewClotheToDb(Clothe newClothe){
            await this._provider.AddClothe(newClothe);
            return newClothe;
        }
        [HttpGet]
        [Route("getAllClothesFromDb")]
        public List<Clothe> getAllClothesAsync()
        => this._provider.getAllClothes();
        
        [HttpGet("getClotheByCategory/{Category}")]
        public List<Clothe> GetClothesByCategory(string Category)
            => this._provider.GetClothesByCategory(Category);
        [HttpDelete]


        [Route("RemoveClotheFromDB")]
        public async Task<Clothe> RemoveClothesFromDb(int[] Ids)
            {
                await this._provider.RemoveClothes(Ids);
                return this._provider.getAllClothes().ToList().FirstOrDefault();
            }


        [HttpPut]
        [Route("UpdateClotheFromDB")]
        public async Task<Clothe> UpdateClothes(Clothe clothe)
        {
            await this._provider.UpdateClothe(clothe);
            return this._provider.getAllClothes().ToList().FirstOrDefault();
        }
    }

}