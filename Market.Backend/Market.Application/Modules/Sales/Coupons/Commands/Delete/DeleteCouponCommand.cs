namespace Market.Application.Modules.Sales.Coupons.Commands.Delete;

public class DeleteCouponCommand : IRequest<Unit>
{
    public required int Id { get; set; }
}
