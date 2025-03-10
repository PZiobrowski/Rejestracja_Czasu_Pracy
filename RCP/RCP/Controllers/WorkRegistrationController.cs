using Microsoft.AspNetCore.Mvc;
using RCP.Managers;

namespace RCP.Controllers;

[ApiController]
[Route("[controller]")]
public class WorkRegistrationController : ControllerBase
{
    private readonly IWorktimeManager worktimeManager;

    public WorkRegistrationController(IWorktimeManager worktimeManager)
    {
        this.worktimeManager = worktimeManager;
    }

    /// <summary>
    /// Rozpoczêcie pracy
    /// </summary>
    [HttpPost("StartWork")]
    public IActionResult StartWork()
    {
        var userId = new Guid("AC42144C-3F50-4C51-916B-F0C240A53A89"); // W docelowej wersji aplikacji nale¿a³oby pobraæ identyfikator u¿ytkownika z kontekstu
        var message = worktimeManager.StartWork(userId);
        return Ok(message);
    }

    /// <summary>
    /// Zakoñczenie pracy
    /// </summary>
    [HttpPatch("StopWork")]
    public IActionResult StopWork()
    {
        var userId = new Guid("AC42144C-3F50-4C51-916B-F0C240A53A89"); // W docelowej wersji aplikacji nale¿a³oby pobraæ identyfikator u¿ytkownika z kontekstu
        var message = worktimeManager.StopWork(userId);
        return Ok(message);
    }

    /// <summary>
    /// Rozpoczêcie przerwy
    /// </summary>
    [HttpPost("StartBreak")]
    public IActionResult StartBreak()
    {
        var userId = new Guid("AC42144C-3F50-4C51-916B-F0C240A53A89"); // W docelowej wersji aplikacji nale¿a³oby pobraæ identyfikator u¿ytkownika z kontekstu
        var message = worktimeManager.StartBreak(userId);
        return Ok(message);
    }

    /// <summary>
    /// Zakoñczenie przerwy
    /// </summary>
    [HttpPatch("StopBreak")]
    public IActionResult StopBreak()
    {
        var userId = new Guid("AC42144C-3F50-4C51-916B-F0C240A53A89"); // W docelowej wersji aplikacji nale¿a³oby pobraæ identyfikator u¿ytkownika z kontekstu
        var message = worktimeManager.StopBreak(userId);
        return Ok(message);
    }
}
