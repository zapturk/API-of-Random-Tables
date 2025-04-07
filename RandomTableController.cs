using System.Net;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;

namespace RandomTableApi;

[ApiController]
[Route("api/RandomTable")]
public class RandomTableController: Controller {

    private RandomTableDAL dal = new RandomTableDAL();

    [HttpGet]
    [Route("Item")]
    [SwaggerResponse(HttpStatusCode.OK, typeof(Item))]
    public ActionResult<Item> GetItem()
    {
        Item item = dal.GetRandomName();

        return Ok(item);
    }
}