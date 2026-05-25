namespace Market.Application.Modules.Sales.Coupons.Commands.Status.Enable;

public sealed class EnableCouponCommand : IRequest<Unit>
{
    public required int Id { get; set; }
}
