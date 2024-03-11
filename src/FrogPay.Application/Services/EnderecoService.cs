using AutoMapper;
using FrogPay.Application.DTOs;
using FrogPay.Application.DTOs.Endereco;
using FrogPay.Application.Interfaces;
using FrogPay.Application.Shared;
using FrogPay.Application.Shared.Notifications;
using FrogPay.Domain.Entities;
using FrogPay.Domain.Interfaces;

namespace FrogPay.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IMapper _mapper;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationHandler _notificationHandler;
        private readonly IPessoaService _pessoaService;

        public EnderecoService(IMapper mapper, IEnderecoRepository enderecoRepository, IUnitOfWork unitOfWork, INotificationHandler notificationHandler, IPessoaService pessoaService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _notificationHandler = notificationHandler;
            _enderecoRepository = enderecoRepository;
            _pessoaService = pessoaService;
        }

        public async Task<PaginationResponse<EnderecoResponse>> GetByIdPessoaAsync(Guid idPessoa, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var enderecos = await _enderecoRepository.GetByIdPessoa(idPessoa, pageNumber, pageSize, cancellationToken);
            var enderecosDTO = _mapper.Map<List<EnderecoResponse>>(enderecos);

            return new PaginationResponse<EnderecoResponse>
            (
                PageNumber: pageNumber,
                PageSize: pageSize,
                Items: enderecosDTO
            );
        }
        public async Task<PaginationResponse<EnderecoResponse>> GetByNomePessoaAsync(string nomePessoa, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var enderecos = await _enderecoRepository.GetByNomePessoa(nomePessoa, pageNumber, pageSize, cancellationToken);
            var enderecosDTO = _mapper.Map<List<EnderecoResponse>>(enderecos);

            return new PaginationResponse<EnderecoResponse>
            (
                PageNumber: pageNumber,
                PageSize: pageSize,
                Items: enderecosDTO
            );
        }

        public async Task<EnderecoResponse?> CreateAsync(EnderecoRequest enderecoDTO, CancellationToken cancellationToken)
        {
            var endereco = _mapper.Map<Endereco>(enderecoDTO);

            var pessoa = _pessoaService.GetByIdAsync(endereco.PessoaId, cancellationToken);

            if (pessoa == null)
            {
                _notificationHandler.AddNotification(new Notification("Pessoa não encontrada.", NotificationLevel.Error));
                return null;
            }

            _enderecoRepository.Create(endereco);
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<EnderecoResponse>(endereco);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _enderecoRepository.Get(id, cancellationToken);

            if (entity == null)
            {
                _notificationHandler.AddNotification(new Notification("Endereço não encontrado.", NotificationLevel.Error));
                return;
            }

            _enderecoRepository.Disable(entity);
            await _unitOfWork.Commit(cancellationToken);
        }

        public async Task<PaginationResponse<EnderecoResponse>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var enderecos = await _enderecoRepository.GetAll(pageNumber, pageSize, cancellationToken);
            var enderecosDTO = _mapper.Map<List<EnderecoResponse>>(enderecos);

            return new PaginationResponse<EnderecoResponse>
            (
                PageNumber: pageNumber,
                PageSize: pageSize,
                Items: enderecosDTO
            );
        }

        public async Task<EnderecoResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var endereco = await _enderecoRepository.Get(id, cancellationToken);
            return _mapper.Map<EnderecoResponse>(endereco);
        }

        public async Task<EnderecoResponse?> UpdateAsync(Guid enderecoId, EnderecoRequest enderecoDTO, CancellationToken cancellationToken)
        {
            var entity = await _enderecoRepository.Get(enderecoId, cancellationToken);

            if (entity == null)
            {
                _notificationHandler.AddNotification(new Notification("Endereço não encontrado.", NotificationLevel.Error));
                return null;
            }

            var endereco = _mapper.Map<Endereco>(enderecoDTO);

            var pessoa = await _pessoaService.GetByIdAsync(endereco.PessoaId, cancellationToken);

            if (pessoa == null)
            {
                _notificationHandler.AddNotification(new Notification("Pessoa não encontrada.", NotificationLevel.Error));
                return null;
            }

            endereco.Id = enderecoId;
            endereco.CreatedDate = entity.CreatedDate;
            EntityUpdater.UpdateEntityFromAnother(entity, endereco);
            _enderecoRepository.Update(entity);
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<EnderecoResponse>(entity);
        }
    }

}
