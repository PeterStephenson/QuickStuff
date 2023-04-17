using Microsoft.AspNetCore.Mvc;

namespace QuickStuff;

[ApiController]
public class HelloWorldController : ControllerBase
{
    private readonly IDatabaseHelloWorldReader _helloWorldReader;

    public HelloWorldController(IDatabaseHelloWorldReader helloWorldReader)
    {
        _helloWorldReader = helloWorldReader;
    }

    [HttpGet("/helloWorld")]
    public ActionResult<string> HelloWorld()
    {
        return  _helloWorldReader.ReadHelloWorldTextFromDatabase();
    }
}