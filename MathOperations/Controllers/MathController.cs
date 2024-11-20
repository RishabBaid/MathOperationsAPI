using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MathOperations.Services;

namespace MathOperations.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MathController : ControllerBase
    {
        private readonly IMathService _mathService;
        public MathController(IMathService mathService)
        {
            _mathService = mathService;
        }
        [HttpPost("add")]
        public IActionResult Add([FromQuery] int num1, [FromQuery] int num2)
        {
            var result = _mathService.Add(num1, num2);
            return Ok(new { Result = result });
        }

        [HttpPost("multiply")]
        public IActionResult Multiply([FromBody] NumbersInput input)
        {
            var result = _mathService.Multiply(input.num1, input.num2);
            return Ok(new { Result = result });
        }

        [HttpPost("subtract")]
        public IActionResult Subtract([FromHeader(Name = "Num1")] int num1, [FromHeader(Name = "Num2")] int num2)
        {
            var result = _mathService.Subtract(num1, num2);
            return Ok(new { Result = result });
        }

        [HttpPost("divide/{num1}/{num2}")]
        public IActionResult Divide(int num1, int num2)
        {
            try
            {
                var result = _mathService.Divide(num1, num2);
                return Ok(new { Result = result });
            }
            catch (DivideByZeroException ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
    public class NumbersInput
    {
        public int num1 { get; set; }
        public int num2 { get; set; }
    }
}
