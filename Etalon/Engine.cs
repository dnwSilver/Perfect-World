using System;

namespace Etalon
{
    public class Factory
    {
        public IEntity CreateEntity(IBuilder b)
        {
            ISpecification spec = null;
            spec.IsSatisfiedBy();
            return null;
        }


        public IEntity RecoveryEntity(IBuilder b)
        {
            ISpecification spec = null;
            spec.IsSatisfiedBy();
            return null;
        }

        public IValueObject CreateValueObject(IBuilder b)
        {
            ISpecification spec = null;
            spec.IsSatisfiedBy();
            return null;
        }
        public IValueObject RecoveryValueObject(IBuilder b)
        {
            ISpecification spec = null;
            spec.IsSatisfiedBy();
            return null;
        }

    }

    public interface ISpecification
    {
        bool IsSatisfiedBy();
        IDataTransferObjectIn MapToDTOIn();
    }

    public interface IUnitOfWork : IDisposable
    {
        void Create();
    }
    public interface IIntegrationEvent
    {

    }

    public interface IBus
    {
        void SendEvent(IIntegrationEvent @event);
    }

    public interface IRequest
    {
        IBuilder[] MapToBuilder();
        ISpecification[] MapToSpecs();
    }

    public interface IDataTransferObjectIn { }
    public interface IDataTransferObjectOut
    {
        IBuilder MapToBuilder();
        Result MapToResult();
    }
    public interface IDataSource
    {
        IDataTransferObjectOut Search(IDataTransferObjectIn input);
        IDataTransferObjectOut Create(IDataTransferObjectIn dataTransferObjectIn);
    }

    public interface IBuilder
    {

    }

    public interface IEntity
    {
        IDataTransferObjectIn MapToDTOIn();
    }

    public interface IValueObject
    {
        IDataTransferObjectIn MapToDTOIn();
    }

    public interface IAggregate
    {
        void SetEntity(IEntity e);
        void SetValueObject(IValueObject e);

        IResponse MapToResponse();
    }

    public interface IResponse { }

    public struct Result
    {
        internal static Result Combine(Result resultSave1, Result resultSave2)
        {
            throw new NotImplementedException();
        }

        internal IResponse MapToResponse()
        {
            throw new NotImplementedException();
        }
    }
}
