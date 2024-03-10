using AutoMapper;
using FrogPay.Application.DTOs;
using FrogPay.Application.DTOs.Loja;
using FrogPay.Application.Interfaces;
using FrogPay.Application.Shared;
using FrogPay.Application.Shared.Notifications;
using FrogPay.Domain.Entities;
using FrogPay.Domain.Interfaces;

namespace FrogPay.Application.Services
{
    internal class LojaService : ILojaService
    {
        private readonly IMapper _mapper;
        private readonly ILojaRepository _lojaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationHandler _notificationHandler;
        private readonly IPessoaService _pessoaService;

        public LojaService(IMapper mapper, ILojaRepository lojaRepository, IUnitOfWork unitOfWork, INotificationHandler notificationHandler, IPessoaService pessoaService)
        {
            _mapper = mapper;
            _lojaRepository = lojaRepository;
            _unitOfWork = unitOfWork;
            _notificationHandler = notificationHandler;
            _pessoaService = pessoaService;
        }

        public async Task<LojaResponse?> CreateAsync(LojaRequest lojaDTO, CancellationToken cancellationToken)
        {
            if (await _lojaRepository.HasExist(lojaDTO.Cnpj!))
            {
                _notificationHandler.AddNotification(new Notification("Documento duplicado.", NotificationLevel.Error));
                return null;
            }

            var loja = _mapper.Map<Loja>(lojaDTO);

            var pessoa = _pessoaService.GetByIdAsync(loja.PessoaId, cancellationToken);

            if (pessoa == null)
            {
                _notificationHandler.AddNotification(new Notification("Loja não encontrada.", NotificationLevel.Error));
                return null;
            }

            _lojaRepository.Create(loja);
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<LojaResponse>(loja);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _lojaRepository.Get(id, cancellationToken);

            if (entity == null)
            {
                _notificationHandler.AddNotification(new Notification("Loja não encontrada.", NotificationLevel.Error));
                return;
            }

            _lojaRepository.Disable(entity);
            await _unitOfWork.Commit(cancellationToken);
        }

        public async Task<PaginationResponse<LojaResponse>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var lojas = await _lojaRepository.GetAll(pageNumber, pageSize, cancellationToken);
            var lojasDTO = _mapper.Map<List<LojaResponse>>(lojas);

            return new PaginationResponse<LojaResponse>
            (
                PageNumber: pageNumber,
                PageSize: pageSize,
                Items: lojasDTO
            );
        }

        public async Task<LojaResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var loja = await _lojaRepository.Get(id, cancellationToken);
            return _mapper.Map<LojaResponse>(loja);
        }

        public async Task<LojaResponse?> UpdateAsync(Guid id, LojaRequest lojaDTO, CancellationToken cancellationToken)
        {
            var entity = await _lojaRepository.Get(id, cancellationToken);

            if (entity == null)
            {
                _notificationHandler.AddNotification(new Notification("Loja não encontrada.", NotificationLevel.Error));
                return null;
            }

            var loja = _mapper.Map<Loja>(lojaDTO);

            var pessoa = _pessoaService.GetByIdAsync(loja.PessoaId, cancellationToken);

            if (pessoa == null)
            {
                _notificationHandler.AddNotification(new Notification("Pessoa não encontrada.", NotificationLevel.Error));
                return null;
            }

            if (entity.Cnpj != loja.Cnpj)
            {
                _notificationHandler.AddNotification(new Notification("Cnpj não pode ser alterado.", NotificationLevel.Error));
                return null;
            }

            
            loja.Id = id;
            loja.CreatedDate = entity.CreatedDate;
            EntityUpdater.UpdateEntityFromAnother(entity, loja);
            _lojaRepository.Update(entity);
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<LojaResponse>(entity);
        }
    }
}
