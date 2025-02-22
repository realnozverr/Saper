using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Domain.SharedKernel
{
    public class DomainEvent : INotification
    {
        public Guid EventId { get; private set; } = Guid.NewGuid();
    }
}
