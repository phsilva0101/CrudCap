using CrudCap.Domain.Enums;

namespace CrudCap.Services.Interfaces
{
    public interface IDomainValidationService
    {
        ReturnHttp Return { get; }
        string[] Messages { get; }
        bool HasNotifications { get; }

        void AddMessage(string msg);
        void AddMessages(IList<string> msgs);
        void AsNotFound();

    }
}
