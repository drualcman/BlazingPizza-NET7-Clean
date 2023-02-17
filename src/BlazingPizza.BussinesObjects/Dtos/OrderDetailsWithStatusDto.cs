namespace BlazingPizza.BussinesObjects.Dtos;
public class OrderDetailsWithStatusDto : OrderWithStatusDto
{
    public OrderDetailsWithStatusDto(Order order) : base(order)
    {
    }
}
