using FrogPay.Application.DTOs;
using FrogPay.Application.DTOs.Pessoa;
using FrogPay.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace FrogPay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaService _pessooaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessooaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<List<PessoaResponse>>> GetAll([FromQuery] PaginationRequest pagination, CancellationToken cancellationToken)
        {
            var response = await _pessooaService.GetAllAsync(pagination.PageNumber,pagination.PageSize, cancellationToken);
            return Ok(response);
        }
    }
}
