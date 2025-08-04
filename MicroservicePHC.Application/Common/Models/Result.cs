namespace MicroservicePHC.Application.Common.Models
{
    public class Result<T>
    {

        internal Result(bool succeded, IEnumerable<string> errors, T resultValue = default!)
        {
            Succeded = succeded;
            Errors = errors.ToArray();
            ResultValue = resultValue;
        }

        public bool Succeded { get; init; }

        public string[] Errors { get; init; }

        public T ResultValue { get; init; }

        public static Result<T> Success(T resultValue)
        {
            return new Result<T>(true, Array.Empty<string>(), resultValue);
        }

        public static Result<T> Failure(IEnumerable<string> errors)
        {
            return new Result<T>(false, errors);
        }

        public static Result<T> Failure(string error)
        {
            return new Result<T>(false, new List<string>()
            {
                error
            });
        }

    }
}
