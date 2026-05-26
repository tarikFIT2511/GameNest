namespace Market.Application.Modules.Sales.Coupons.Commands.Status.Disable;

public sealed class DisableCouponCommand : IRequest<Unit>
{
    public required int Id { get; set; }
}
