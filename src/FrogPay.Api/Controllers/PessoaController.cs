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
        private readonly IPessoaService _pessoaService;

        public PessoaController(IPessoaService pessoaService)
        {
            _pessoaService = pessoaService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<PessoaResponse>>> GetAll([FromQuery] PaginationRequest pagination, CancellationToken cancellationToken)
        {
            var response = await _pessoaService.GetAllAsync(pagination.PageNumber, pagination.PageSize, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PessoaResponse>> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = await _pessoaService.GetByIdAsync(id, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<PessoaResponse>> Create([FromBody] PessoaRequest pessoaRequest, CancellationToken cancellationToken)
        {
            var pessoa = await _pessoaService.CreateAsync(pessoaRequest, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = pessoa?.Id }, pessoa);
        }

        [HttpPut("{pessoaId}")]
        public async Task<ActionResult<PessoaResponse>> Update([FromRoute] Guid pessoaId, [FromBody] PessoaRequest pessoaRequest, CancellationToken cancellationToken)
        {
            var clinica = await _pessoaService.UpdateAsync(pessoaId, pessoaRequest, cancellationToken);
            return Ok(clinica);
        }

        [HttpDelete("{pessoaId}")]
        public async Task<ActionResult<PessoaResponse>> Delete([FromRoute] Guid pessoaId, CancellationToken cancellationToken)
        {
            await _pessoaService.DeleteAsync(pessoaId, cancellationToken);
            return Ok();
        }
    }
}
