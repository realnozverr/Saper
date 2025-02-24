using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace Domain.GameAggreagate
{
    public class Status : Entity<int>
    {
        public static readonly Status Completed = new Status(1, nameof(Completed).ToLowerInvariant());
        public static readonly Status Lose = new Status(2, nameof(Lose).ToLowerInvariant());
        public static readonly Status Incomplete = new Status(3, nameof(Incomplete).ToLowerInvariant());

        private Status(){}

        private Status(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; } = null!;
    }
}
