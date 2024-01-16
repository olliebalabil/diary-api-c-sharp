namespace DiaryAPI.Models
{
  public class Diary
  {
    public int Id {get;set;}
    public string Title { get; set; }
    public string Content {get;set;}
    public string Type { get; set; }
    public DateTime DateTime { get; set; }

  }
}