using AutoMapper;
using FrogPay.Application.DTOs;
using FrogPay.Application.DTOs.DadosBancarios;
using FrogPay.Application.Interfaces;
using FrogPay.Application.Shared;
using FrogPay.Application.Shared.Notifications;
using FrogPay.Domain.Entities;
using FrogPay.Domain.Interfaces;

namespace FrogPay.Application.Services
{
    public class DadosBancariosService : IDadosBancariosService
    {
        private readonly IMapper _mapper;
        private readonly IDadosBancariosRepository _dadosBancariosRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationHandler _notificationHandler;
        private readonly IPessoaService _pessoaService;

        public DadosBancariosService(IMapper mapper, IDadosBancariosRepository dadosBancariosRepository, IUnitOfWork unitOfWork, INotificationHandler notificationHandler, IPessoaService pessoaService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _notificationHandler = notificationHandler;
            _dadosBancariosRepository = dadosBancariosRepository;
            _pessoaService = pessoaService;
        }
        public async Task<PaginationResponse<DadosBancariosResponse>> GetByIdPessoaAsync(Guid idPessoa, int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var dadosBancarios = await _dadosBancariosRepository.GetByIdPessoa(idPessoa, pageNumber, pageSize, cancellationToken);
            var dadosBancariosDTO = _mapper.Map<List<DadosBancariosResponse>>(dadosBancarios);

            return new PaginationResponse<DadosBancariosResponse>
            (
                PageNumber: pageNumber,
                PageSize: pageSize,
                Items: dadosBancariosDTO
            );
        }
        public async Task<DadosBancariosResponse?> CreateAsync(DadosBancariosRequest dadosBancariosDTO, CancellationToken cancellationToken)
        {
            var dadosBancarios = _mapper.Map<DadosBancarios>(dadosBancariosDTO);

            var pessoa = _pessoaService.GetByIdAsync(dadosBancarios.PessoaId, cancellationToken);

            if (pessoa == null)
            {
                _notificationHandler.AddNotification(new Notification("Pessoa não encontrada.", NotificationLevel.Error));
                return null;
            }

            _dadosBancariosRepository.Create(dadosBancarios);
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<DadosBancariosResponse>(dadosBancarios);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _dadosBancariosRepository.Get(id, cancellationToken);

            if (entity == null)
            {
                _notificationHandler.AddNotification(new Notification("Dados bancarios não encontrado.", NotificationLevel.Error));
                return;
            }

            _dadosBancariosRepository.Disable(entity);
            await _unitOfWork.Commit(cancellationToken);
        }

        public async Task<PaginationResponse<DadosBancariosResponse>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var dadosBancarios = await _dadosBancariosRepository.GetAll(pageNumber, pageSize, cancellationToken);
            var dadosBancariosDTO = _mapper.Map<List<DadosBancariosResponse>>(dadosBancarios);

            return new PaginationResponse<DadosBancariosResponse>
            (
                PageNumber: pageNumber,
                PageSize: pageSize,
                Items: dadosBancariosDTO
            );
        }

        public async Task<DadosBancariosResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var dadosBancarios = await _dadosBancariosRepository.Get(id, cancellationToken);
            return _mapper.Map<DadosBancariosResponse>(dadosBancarios);
        }

        public async Task<DadosBancariosResponse?> UpdateAsync(Guid dadosbancariosId, DadosBancariosRequest dadosbancariosDTO, CancellationToken cancellationToken)
        {
            var entity = await _dadosBancariosRepository.Get(dadosbancariosId, cancellationToken);

            if (entity == null)
            {
                _notificationHandler.AddNotification(new Notification("Dados bancarios não encontrado.", NotificationLevel.Error));
                return null;
            }

            var dadosbancarios = _mapper.Map<DadosBancarios>(dadosbancariosDTO);

            var pessoa = await _pessoaService.GetByIdAsync(dadosbancarios.PessoaId, cancellationToken);

            if (pessoa == null)
            {
                _notificationHandler.AddNotification(new Notification("Pessoa não encontrada.", NotificationLevel.Error));
                return null;
            }

            dadosbancarios.Id = dadosbancariosId;
            dadosbancarios.CreatedDate = entity.CreatedDate;
            EntityUpdater.UpdateEntityFromAnother(entity, dadosbancarios);
            _dadosBancariosRepository.Update(entity);
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<DadosBancariosResponse>(entity);
        }
    }
}
