using ErrorOr;

namespace Aquaculture.Domain.Common.Errors;

public static partial class Errors
{
    public static class User
    {
        public static Error DuplicateEmail => Error.Conflict(
            code: "User.DuplicateEmail",
            description: "Email already exist!");
        public static Error NotFoundUser => Error.NotFound(
            code: "User.NotFoundUser",
            description: "User not found!");
    }
}
