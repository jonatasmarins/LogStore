using System.Collections.Generic;
using FluentValidation.Results;

namespace LogStore.Domain.Shared
{
    public interface IResult
    {
        bool Success { get; }
        IReadOnlyList<string> Errors { get; }
        void AddMessage(IList<ValidationFailure> failures);
        void AddMessage(string failure);
        IList<string> GetMessages();
    }

    public interface IResultResponse : IResult
    {

    }

    public interface IResultResponse<T> : IResult
    {
        T Value { get; set; }
    }
}