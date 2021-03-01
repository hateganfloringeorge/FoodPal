using AutoMapper;
using FluentValidation;
using FoodPal.Notifications.Application.Commands;
using FoodPal.Notifications.Application.Extensions;
using FoodPal.Notifications.Data.Abstractions;
using FoodPal.Notifications.Domain;
using FoodPal.Notifications.Service;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPal.Notifications.Application.Handlers
{
    public class NotificationViewedHandler : IRequestHandler<NotificationViewedCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<NotificationViewedCommand> _validator;
        private readonly INotificationService _notificationService;

        public NotificationViewedHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<NotificationViewedCommand> validator, INotificationService notificationService)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._validator = validator;
            this._notificationService = notificationService;
        }

        public async Task<bool> Handle(NotificationViewedCommand request, CancellationToken cancellationToken)
        {
            var notificationModel = await this._unitOfWork.GetRepository<Notification>().FindByIdAsync(request.Id);
         
            this._validator.ValidateAndThrowEx(request);

            
            if (notificationModel is null)
            {
                throw new System.Exception($"Could not find notification with the id : {request.Id}.");
            }

            notificationModel.Status = Common.Enums.NotificationStatusEnum.Viewed;
            this._unitOfWork.GetRepository<Notification>().Update(notificationModel);
            return await this._unitOfWork.SaveChangesAsnyc(); ;
        }
    }
}