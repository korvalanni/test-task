using DeckService.Setup;
using Microsoft.AspNetCore.Mvc;

namespace DeckService.Controllers;

[ApiController]
[Route($"{ApiInformation.RouteVersion}/[controller]")]
public class ApiBaseController : ControllerBase
{
}