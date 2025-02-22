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

        private Status(){}

        private Status(int id, string name)
        {

        }


    }
}
