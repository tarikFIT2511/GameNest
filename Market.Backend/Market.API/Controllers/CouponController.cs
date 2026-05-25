using Market.Application.Modules.Sales.Coupons.Commands.Create;
using Market.Application.Modules.Sales.Coupons.Commands.Delete;
using Market.Application.Modules.Sales.Coupons.Commands.Status.Disable;
using Market.Application.Modules.Sales.Coupons.Commands.Status.Enable;
using Market.Application.Modules.Sales.Coupons.Commands.Update;

namespace Market.API.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class CouponController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> CreateCoupon(CreateCouponCommand command, CancellationToken ct)
    {
        int id = await sender.Send(command, ct);

        return Ok(id);
    }

    [HttpPut("{id:int}")]
    public async Task UpdateCoupon(int id, UpdateCouponCommand command, CancellationToken ct)
    {
        command.Id = id;
        await sender.Send(command, ct);
    }

    [HttpDelete("{id:int}")]
    public async Task Delete(int id, CancellationToken ct)
    {
        await sender.Send(new DeleteCouponCommand { Id = id }, ct);
    }

    //[HttpGet("{id:int}")]
    //public async Task<GetCouponByIdQueryDto> GetById(int id, CancellationToken ct)
    //{
    //    var user = await sender.Send(new GetCouponByIdQuery { Id = id }, ct);
    //    return user; // if NotFoundException -> 404 via middleware
    //}

    //[HttpGet("/CouuponsList")]
    //public async Task<PageResult<ListCouponsQueryDto>> List([FromQuery] ListCouponsQuery query, CancellationToken ct)
    //{
    //    var result = await sender.Send(query, ct);
    //    return result;
    //}

    [HttpPut("{id:int}/disable")]
    public async Task Disable(int id, CancellationToken ct)
    {
        await sender.Send(new DisableCouponCommand { Id = id }, ct);
    }

    [HttpPut("{id:int}/enable")]
    public async Task Enable(int id, CancellationToken ct)
    {
        await sender.Send(new EnableCouponCommand { Id = id }, ct);
    }
}