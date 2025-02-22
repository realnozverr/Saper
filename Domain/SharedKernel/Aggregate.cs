using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Domain.SharedKernel
{
    public abstract class Aggregate : IAggregate
    {
        public readonly List<DomainEvent> _domainEvents = [];
        public IReadOnlyList<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();
        public void ClearDomainEvents() => _domainEvents.Clear();
        protected void AddDomainEvent(DomainEvent domainEvent) => _domainEvents.Add(domainEvent);
    }
}
