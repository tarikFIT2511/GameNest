namespace Market.Application.Modules.Sales.Coupons.Queries.GetById;

public class GetCouponByIdQuery : IRequest<GetCouponByIdQueryDto>
{
    public int Id { get; set; }
}