using Microsoft.AspNetCore.Mvc;
using RCP.Database;
using RCP.Managers;

namespace RCP.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkRegistrationController : ControllerBase
{
    private readonly IWorktimeManager worktimeManager;
    private readonly RcpDbContext context;

    public WorkRegistrationController(IWorktimeManager worktimeManager, RcpDbContext context)
    {
        this.worktimeManager = worktimeManager;
        this.context = context;
    }

    /// <summary>
    /// Rozpoczęcie pracy
    /// </summary>
    [HttpPost("StartWork")]
    public IActionResult StartWork()
    {
        var user = context.GetUser(); // W docelowej wersji aplikacji należałoby pobrać identyfikator użytkownika z kontekstu
        if (user == null)
            return Unauthorized();

        var message = worktimeManager.StartWork(user.Id);
        return Ok(message);
    }

    /// <summary>
    /// Zakończenie pracy
    /// </summary>
    [HttpPatch("StopWork")]
    public IActionResult StopWork()
    {
        var user = context.GetUser(); // W docelowej wersji aplikacji należałoby pobrać identyfikator użytkownika z kontekstu
        if (user == null)
            return Unauthorized();

        var message = worktimeManager.StopWork(user.Id);
        return Ok(message);
    }

    /// <summary>
    /// Rozpoczęcie przerwy
    /// </summary>
    [HttpPost("StartBreak")]
    public IActionResult StartBreak()
    {
        var user = context.GetUser(); // W docelowej wersji aplikacji należałoby pobrać identyfikator użytkownika z kontekstu
        if (user == null)
            return Unauthorized();

        var message = worktimeManager.StartBreak(user.Id);
        return Ok(message);
    }

    /// <summary>
    /// Zakończenie przerwy
    /// </summary>
    [HttpPatch("StopBreak")]
    public IActionResult StopBreak()
    {
        var user = context.GetUser(); // W docelowej wersji aplikacji należałoby pobrać identyfikator użytkownika z kontekstu
        if (user == null)
            return Unauthorized();

        var message = worktimeManager.StopBreak(user.Id);
        return Ok(message);
    }
}
