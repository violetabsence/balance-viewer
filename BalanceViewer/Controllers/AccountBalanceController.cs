using BalanceViewer.Converters;
using BalanceViewer.Dtos;
using BalanceViewer.Entities;
using BalanceViewer.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace BalanceViewer.Controllers
{
    [ApiController]
    [Route("api/account")]
    public class AccountBalanceController : Controller
    { 
        private IAccountBalanceService _service;

        public AccountBalanceController(IAccountBalanceService service)
        {
            _service = service;
        }

        [HttpGet("{accountId}")]
        public async Task<ActionResult<List<BalanceDto>>> GetBalanceByAccountIdAsync([FromRoute] int accountId)
        {
            var balances = await _service.GetBalanceByAccountIdAsync(accountId);
            return Ok(balances);
        }

        [HttpPut("balances")]
        public async Task<ActionResult> FillBalance([FromBody] List<BalanceDto> dtos)
        {
            try
            {
                await _service.FillBalancesAsync(dtos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("payments")]
        public async Task<IActionResult> FillPaymentsAcync([FromBody] List<PaymentDto> dtos)
        {
            try
            {
                await _service.FillPaymentsAsync(dtos);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("recalculate/{accountId}")]
        public async Task<IActionResult> RecalculateBalanceAsync([FromRoute] int accountId)
        {
            try
            {
                await _service.RecalculateBalanceAsync(accountId);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
