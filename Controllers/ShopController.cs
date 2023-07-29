using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShopController : ControllerBase
    {

        private static List<Shop> seller = new List<Shop>()
            {
                new Shop {ShopId = 1,ShopName = "Korzinka",ShopOwner= "Ilon Musk",CreatedAt="Ice Age"},
                new Shop {ShopId = 2,ShopName = "Macro", ShopOwner="Hoji Akala",CreatedAt="Dinozaurs Age"}
            };
        [HttpGet]
        public async Task<ActionResult<List<Shop>>> Get()
        {
            
            return Ok(seller);

        }

        [HttpGet("{ShopId}")]
        public async Task<ActionResult<Shop>> Get(int ShopId)
        {
            var sell = seller.Find(h => h.ShopId == ShopId);
            if (sell == null)
                return BadRequest("Chota sell topilmadi.");
            return Ok(sell);

        }
        [HttpPost]
        public async Task<ActionResult<List<Shop>>> AddShop(Shop shop)
        {
            seller.Add(shop);
            return Ok(seller);
        }

        [HttpPut]
        public async Task<ActionResult<List<Shop>>> UpdateShop(Shop request)
        {
            var sell = seller.Find(h => h.ShopId == request.ShopId);
            if (sell == null)
                return BadRequest("Chota selltopilmadi");

            sell.ShopName = request.ShopName;
            sell.ShopOwner = request.ShopOwner;
            sell.CreatedAt = request.CreatedAt;
            return Ok(seller);
        }


        [HttpDelete("{ShopId}")]
        public async Task<ActionResult<List<Shop>>> Delete(int ShopId)
        {
            var sell = seller.Find(h => h.ShopId == ShopId);
            if (sell == null)
                return BadRequest("Chota sell topilmadi.");

            seller.Remove(sell);
            return Ok(sell);

        }
    }
}
