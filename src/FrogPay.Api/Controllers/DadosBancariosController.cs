using FrogPay.Application.DTOs;
using FrogPay.Application.DTOs.DadosBancarios;
using FrogPay.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrogPay.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DadosBancariosController : ControllerBase
    {
        private readonly IDadosBancariosService _dadosBancariosService;

        public DadosBancariosController(IDadosBancariosService dadosBancariosService)
        {
            _dadosBancariosService = dadosBancariosService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<DadosBancariosResponse>>> GetAll([FromQuery] PaginationRequest pagination, CancellationToken cancellationToken)
        {
            var response = await _dadosBancariosService.GetAllAsync(pagination.PageNumber, pagination.PageSize, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DadosBancariosResponse>> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = await _dadosBancariosService.GetByIdAsync(id, cancellationToken);
            return Ok(response);
        }

        [HttpGet("GetByPessoa/{idPessoa}")]
        public async Task<ActionResult<PaginationResponse<DadosBancariosResponse>>> GetByIdPessoa([FromRoute] Guid idPessoa, [FromQuery] PaginationRequest pagination, CancellationToken cancellationToken)
        {
            var response = await _dadosBancariosService.GetByIdPessoaAsync(idPessoa, pagination.PageNumber, pagination.PageSize, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<DadosBancariosResponse>> Create([FromBody] DadosBancariosRequest dadosBancariosRequest, CancellationToken cancellationToken)
        {
            var dadosBancarios = await _dadosBancariosService.CreateAsync(dadosBancariosRequest, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = dadosBancarios?.Id }, dadosBancarios);
        }

        [HttpPut("{dadosBancariosId}")]
        public async Task<ActionResult<DadosBancariosResponse>> Update([FromRoute] Guid dadosBancariosId, [FromBody] DadosBancariosRequest dadosBancariosRequest, CancellationToken cancellationToken)
        {
            var clinica = await _dadosBancariosService.UpdateAsync(dadosBancariosId, dadosBancariosRequest, cancellationToken);
            return Ok(clinica);
        }

        [HttpDelete("{dadosBancariosId}")]
        public async Task<ActionResult<DadosBancariosResponse>> Delete([FromRoute] Guid dadosBancariosId, CancellationToken cancellationToken)
        {
            await _dadosBancariosService.DeleteAsync(dadosBancariosId, cancellationToken);
            return Ok();
        }
    }
}
