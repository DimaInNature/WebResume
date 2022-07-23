namespace WR.Consumers.Web.Presentation.Components;

public class PortfolioViewComponent : ViewComponent
{
    private readonly IConfiguration _configuration;

    private readonly IPetProjectAppService _petProjectAppService;

    public PortfolioViewComponent(
        IConfiguration configuration,
        IPetProjectAppService petProjectAppService) =>
        (_configuration, _petProjectAppService) = (configuration, petProjectAppService);

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model = await _petProjectAppService
            .GetAllAsync(ownerName: _configuration[key: "User:Nickname"]); ;

        return View(model.OrderByDescending(x => x.StarsCount));
    }
}