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
        public async Task<ActionResult<List<BalanceDto>>> GetBalanceByAccountIdAsync([FromRoute]int accountId)
        {
            return Ok(await _service.GetBalanceByAccountIdAsync(accountId));
        }
    }
}
