namespace BlazingPizza.BussinesObjects.Entities;
public class BaseOrder
{
    public int Id { get; set; }
    public DateTime CreatedTime { get; set; }
    public string UserId { get; set; }
}
