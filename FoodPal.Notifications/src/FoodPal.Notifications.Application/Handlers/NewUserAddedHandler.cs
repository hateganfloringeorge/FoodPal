﻿using AutoMapper;
using FluentValidation;
using FoodPal.Notifications.Application.Extensions;
using FoodPal.Notifications.Data.Abstractions;
using FoodPal.Notifications.Domain;
using FoodPal.Notifications.Processor.Commands;
using MediatR;
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

            if ( await this._unitOfWork.GetRepository<User>().FindByIdAsync(userModel.Id) is null)
            {
                throw new System.Exception($"Could not find user with id: { userModel.Id }.");
            }

            // save to db
            this._unitOfWork.GetRepository<User>().Update(userModel);
            return await this._unitOfWork.SaveChangesAsnyc();
        }
    }
}