using FluentValidation.Results;

namespace Catalog.Application.Commons.Bases
{
    public class BaseEntityResponse<T>
    {
        public bool IsSuccess { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; }
        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
