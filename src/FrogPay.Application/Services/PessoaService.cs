using AutoMapper;
using FrogPay.Application.DTOs;
using FrogPay.Application.DTOs.Pessoa;
using FrogPay.Application.Interfaces;
using FrogPay.Application.Shared;
using FrogPay.Application.Shared.Notifications;
using FrogPay.Domain.Entities;
using FrogPay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.Services
{
    internal class PessoaService : IPessoaService
    {
        private readonly IMapper _mapper;
        private readonly IPessoaRepository _pessoaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly INotificationHandler _notificationHandler;

        public PessoaService(IMapper mapper, IPessoaRepository pessoaRepository, IUnitOfWork unitOfWork, INotificationHandler notificationHandler)
        {
            _mapper = mapper;
            _pessoaRepository = pessoaRepository;
            _unitOfWork = unitOfWork;
            _notificationHandler = notificationHandler;
        }

        public async Task<PaginationResponse<PessoaResponse>> GetAllAsync(int pageNumber, int pageSize, CancellationToken cancellationToken)
        {
            var pessoas = await _pessoaRepository.GetAll(pageNumber, pageSize, cancellationToken);
            var pessoasDTO = _mapper.Map<List<PessoaResponse>>(pessoas);

            return new PaginationResponse<PessoaResponse>
            (
                PageNumber: pageNumber,
                PageSize: pageSize,
                Items: pessoasDTO
            );
        }

        public async Task<PessoaResponse> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var pessoa = await _pessoaRepository.Get(id, cancellationToken);
            return _mapper.Map<PessoaResponse>(pessoa);
        }

        public async Task<PessoaResponse?> CreateAsync(PessoaRequest pessoaDTO, CancellationToken cancellationToken)
        {
            if (await _pessoaRepository.HasExist(pessoaDTO.Cpf!))
            {
                _notificationHandler.AddNotification(new Notification("Documento duplicado.", NotificationLevel.Error));
                return null;
            }

            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);
            _pessoaRepository.Create(pessoa);
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<PessoaResponse>(pessoa);
        }

        public async Task<PessoaResponse?> UpdateAsync(Guid id, PessoaRequest pessoaDTO, CancellationToken cancellationToken)
        {
            var entity = await _pessoaRepository.Get(id, cancellationToken);

            if (entity == null)
            {
                _notificationHandler.AddNotification(new Notification("Pessoa não encontrada.", NotificationLevel.Error));
                return null;
            }

            var pessoa = _mapper.Map<Pessoa>(pessoaDTO);

            if (entity.Cpf != pessoa.Cpf)
            {
                _notificationHandler.AddNotification(new Notification("CPF não pode ser alterado.", NotificationLevel.Error));
                return null;
            }

            pessoa.Id = id;
            pessoa.CreatedDate = entity.CreatedDate;
            EntityUpdater.UpdateEntityFromAnother(entity, pessoa);
            _pessoaRepository.Update(entity);
            await _unitOfWork.Commit(cancellationToken);
            return _mapper.Map<PessoaResponse>(entity);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var entity = await _pessoaRepository.Get(id, cancellationToken);

            if (entity == null)
            {
                _notificationHandler.AddNotification(new Notification("Pessoa não encontrada.", NotificationLevel.Error));
                return;
            }

            _pessoaRepository.Disable(entity);
            await _unitOfWork.Commit(cancellationToken);

        }
    }
}
