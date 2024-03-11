using FrogPay.Application.DTOs;
using FrogPay.Application.DTOs.Endereco;
using FrogPay.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FrogPay.Api.Controllers
{
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        [HttpGet]
        public async Task<ActionResult<PaginationResponse<EnderecoResponse>>> GetAll([FromQuery] PaginationRequest pagination, CancellationToken cancellationToken)
        {
            var response = await _enderecoService.GetAllAsync(pagination.PageNumber, pagination.PageSize, cancellationToken);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoResponse>> Get([FromRoute] Guid id, CancellationToken cancellationToken)
        {
            var response = await _enderecoService.GetByIdAsync(id, cancellationToken);
            return Ok(response);
        }

        [HttpGet("GetByPessoa/{idPessoa}")]
        public async Task<ActionResult<PaginationResponse<EnderecoResponse>>> GetByIdPessoa([FromRoute] Guid idPessoa, [FromQuery] PaginationRequest pagination, CancellationToken cancellationToken)
        {
            var response = await _enderecoService.GetByIdPessoaAsync(idPessoa, pagination.PageNumber, pagination.PageSize, cancellationToken);
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<EnderecoResponse>> Create([FromBody] EnderecoRequest enderecoRequest, CancellationToken cancellationToken)
        {
            var endereco = await _enderecoService.CreateAsync(enderecoRequest, cancellationToken);
            return CreatedAtAction(nameof(Get), new { id = endereco?.Id }, endereco);
        }

        [HttpPut("{enderecoId}")]
        public async Task<ActionResult<EnderecoResponse>> Update([FromRoute] Guid enderecoId, [FromBody] EnderecoRequest enderecoRequest, CancellationToken cancellationToken)
        {
            var clinica = await _enderecoService.UpdateAsync(enderecoId, enderecoRequest, cancellationToken);
            return Ok(clinica);
        }

        [HttpDelete("{enderecoId}")]
        public async Task<ActionResult<EnderecoResponse>> Delete([FromRoute] Guid enderecoId, CancellationToken cancellationToken)
        {
            await _enderecoService.DeleteAsync(enderecoId, cancellationToken);
            return Ok();
        }
    }
}
