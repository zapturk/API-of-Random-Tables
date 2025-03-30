using Microsoft.AspNetCore.Mvc;

namespace RandomTableApi;

[ApiController]
[Route("api/RandomTable")]
public class RandomTableController: Controller {

    private RandomTableDAL dal = new RandomTableDAL();

    [HttpGet]
    [Route("MaleName")]
    public ActionResult<List<Item>> GetMaleName()
    {
        return dal.GetMaleName();
    }

}