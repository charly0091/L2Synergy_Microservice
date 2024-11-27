using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L2Synergy.Shared.Results
{
    public interface IResult
    {
        bool IsSuccess { get; }
        string? Message { get; }
        int? StatusCode { get; }
        IEnumerable<string>? Errors { get; }
    }

    public interface IResult<T>
    {
        bool IsSuccess { get; }
        string? Message { get; }
        int? StatusCode { get; }
        IEnumerable<string>? Errors { get; }
        T? Value { get; }
        IEnumerable<T>? Values { get; }
    }
}
