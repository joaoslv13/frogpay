using FrogPay.Application.DTOs;
using FrogPay.Application.DTOs.Loja;
using FrogPay.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrogPay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LojaController : ControllerBase
    {
        private readonly ILojaService _lojaService;

        public LojaController(ILojaService lojaservice)
        {
            _lojaService = lojaservice;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<LojaResponse>>> GetAll([FromQuery] PaginationRequest pagination, CancellationToken cancellationToken)
        {
            var response = await _lojaService.GetAllAsync(pagination.PageNumber, pagination.PageSize, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LojaResponse>> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = await _lojaService.GetByIdAsync(id, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<LojaResponse>> Create([FromBody] LojaRequest lojaRequest, CancellationToken cancellationToken)
        {
            var loja = await _lojaService.CreateAsync(lojaRequest, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = loja?.Id }, loja);
        }

        [HttpPut("{lojaId}")]
        public async Task<ActionResult<LojaResponse>> Update([FromRoute] Guid lojaId, [FromBody] LojaRequest lojaRequest, CancellationToken cancellationToken)
        {
            var clinica = await _lojaService.UpdateAsync(lojaId, lojaRequest, cancellationToken);
            return Ok(clinica);
        }

        [HttpDelete("{lojaId}")]
        public async Task<ActionResult<LojaResponse>> Delete([FromRoute] Guid lojaId, CancellationToken cancellationToken)
        {
            await _lojaService.DeleteAsync(lojaId, cancellationToken);
            return Ok();
        }
    }
}
