﻿using System.Windows.Input;

namespace Etalon
{
    partial class API
    {
        // Presentation
        // Idempotent
        IResponse Put(IRequest request)
        {
            // Presentation
            ISpecification[] specs = request.MapToSpecs();
            IBuilder builder = request.MapToBuilder();
            Service someService = null;
            Result result = someService.Update(specs, builder);

            return result.MapToResponse();
        }

        // Presentation
        // Idempotent
        IResponse Patch(IRequest request)
        {
            // Presentation
            ISpecification[] specs = request.MapToSpecs();
            IBuilder builder = request.MapToBuilder();
            Command command = request.MapToCommand();
            Service someService = null;

            Result result;
            switch (command)
            {
                case Command.Register:
                    result = someService.SomeMethod(specs, builder);
                    break;
                default:
                    result = new Result();
                    break;
            }

            return result.MapToResponse();
        }
    }

    partial class Service
    {
        // Domain
        public Result SomeMethod(ISpecification[] specs, IBuilder builder)
        {
            Repository repositoryEntity = null;
            IEntity entity = repositoryEntity.SearchEntity(specs);

            Repository repositoryValueObject = null;
            IValueObject valueObject = repositoryValueObject.SearchValueObject(specs);

            Result resultMethod1 = entity.SomeMethod(builder.SomeField());
            Result resultMethod2 = entity.SomeMethod(builder.SomeField());
            valueObject.SomeMethod(builder.SomeField());

            if (Result.Combine(resultMethod1, resultMethod2).Failure)
                return Result.Combine(resultMethod1, resultMethod2);

            IUnitOfWork unitOfWork = null;
            Result resultSave1;
            Result resultSave2;

            using (unitOfWork)
            {
                Repository entityRepository = null;
                resultSave1 = entityRepository.UpdateEntity(entity);

                Repository entityValueObject = null;
                resultSave2 = entityValueObject.UpdateValueObject(valueObject);
            }

            IIntegrationEvent integrationEvent = null;
            IBus bus = null;
            bus.SendEvent(integrationEvent);

            return Result.Combine(resultSave1, resultSave2);
        }

        public Result Update(ISpecification[] specs, IBuilder builder)
        {
            Repository repositoryEntity = null;
            IEntity entity = repositoryEntity.SearchEntity(specs);

            Repository repositoryValueObject = null;
            IValueObject valueObject = repositoryValueObject.SearchValueObject(specs);

            Result resultMethod1 = entity.SomeMethod(builder.SomeField());
            Result resultMethod2 = entity.SomeMethod(builder.SomeField());
            valueObject.SomeMethod(builder.SomeField());

            IUnitOfWork unitOfWork = null;
            Result resultSave1;
            Result resultSave2;

            using (unitOfWork)
            {
                Repository entityRepository = null;
                resultSave1 = entityRepository.UpdateEntity(entity);

                Repository entityValueObject = null;
                resultSave2 = entityValueObject.UpdateValueObject(valueObject);
            }

            IIntegrationEvent integrationEvent = null;
            IBus bus = null;
            bus.SendEvent(integrationEvent);

            return Result.Combine(resultSave1, resultSave2);
        }


    }
}
