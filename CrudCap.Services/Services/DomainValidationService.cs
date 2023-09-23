using CrudCap.Domain.Enums;
using CrudCap.Services.Interfaces;

namespace CrudCap.Services.Services
{
    public class DomainValidationService : IDomainValidationService
    {
        public ReturnHttp Return { get; private set; }

        private List<string> _messages;
        public string[] Messages => _messages.ToArray();

        public bool HasNotifications => Return != ReturnHttp.Ok;

        public DomainValidationService()
        {
            Return = ReturnHttp.Ok;
            _messages = new List<string>();
        }

        public void AddMessage(string msg)
        {
            Return = ReturnHttp.BadRequest;
            _messages.Add(msg);
        }

        public void AddMessages(IList<string> msgs)
        {
            Return = ReturnHttp.BadRequest;
            _messages.AddRange(msgs);
        }

        public void AsNotFound()
        {
            Return = ReturnHttp.NotFound;
        }
    }
}
