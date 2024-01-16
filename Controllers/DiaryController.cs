using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DiaryAPI.Models;
using DiaryAPI.Data;

namespace DiaryAPI.Controllers
{
  [Route("api/[controller]/[action]")]
  [ApiController]
  public class DiaryController : ControllerBase
  {
    private readonly ApiContext _context;
    public DiaryController(ApiContext context)
    {
      _context = context;
    }

    //Create/Edit
    [HttpPost]
    public JsonResult CreateEdit(Diary entry)
    {
      entry.DateTime = DateTime.Now;
      if (entry.Id == 0)
      {
        _context.Diaries.Add(entry);
      }
      else
      {
        var entryInDb = _context.Diaries.Find(entry.Id);
        if (entryInDb == null)
          return new JsonResult(NotFound());

        entryInDb = entry;

      }

      _context.SaveChanges();

      return new JsonResult(Ok(entry));
    }
    //Get
    [HttpGet]
    public JsonResult Get(int id)
    {
      var result = _context.Diaries.Find(id);
      if (result == null)
        return new JsonResult(NotFound());

      return new JsonResult(Ok(result));
    }
    //Delete
    [HttpDelete]
    public JsonResult Delete(int id)
    {
      var result = _context.Diaries.Find(id);

      if (result == null)
        return new JsonResult(NotFound());

      _context.Diaries.Remove(result);
      _context.SaveChanges();
      return new JsonResult(NoContent());
    }
    //Get All
    [HttpGet()]
    public JsonResult GetAll()
    {
      var result = _context.Diaries.ToList();

      return new JsonResult(Ok(result));
    }
  }
}