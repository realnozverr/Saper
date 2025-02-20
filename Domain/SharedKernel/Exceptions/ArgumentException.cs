using System.Diagnostics.CodeAnalysis;

namespace Domain.SharedKernel.Exceptions
{
    [ExcludeFromCodeCoverage]
    public class ArgumentException(string message) : Exception(message);
}
