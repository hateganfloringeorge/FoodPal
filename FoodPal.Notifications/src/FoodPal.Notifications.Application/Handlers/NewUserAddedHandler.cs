using AutoMapper;
using FluentValidation;
using FoodPal.Notifications.Application.Extensions;
using FoodPal.Notifications.Data.Abstractions;
using FoodPal.Notifications.Domain;
using FoodPal.Notifications.Dto.Exceptions;
using FoodPal.Notifications.Processor.Commands;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FoodPal.Notifications.Application.Handlers
{
    public class NewUserAddedHandler : IRequestHandler<NewUserAddedCommand, bool>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IValidator<NewUserAddedCommand> _validator;

        public NewUserAddedHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<NewUserAddedCommand> validator)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._validator = validator;
        }

        public async Task<bool> Handle(NewUserAddedCommand request, CancellationToken cancellationToken)
        {
            var userModel = this._mapper.Map<User>(request);

            this._validator.ValidateAndThrowEx(request);

            // save to db
            this._unitOfWork.GetRepository<User>().Create(userModel);
            return await this._unitOfWork.SaveChangesAsnyc();
        }
    }
}