using Template.Trunk.Server.Application.Common.Domain;

namespace Template.Trunk.Server.Application.Common.Errors
{
    public static class ErrorCommon
    {
        public static ErrorMessage UnAuthorised_RequiredError => new ErrorMessage()
        {
            Code = "401",
            Message = "Unauthorized - You are not authorized to access this resource."
        };
        
        public static ErrorMessage UnAuthorised_InvalidError => new ErrorMessage()
        {
            Code = "401",
            Message = "Unauthorized - Invalid or expired token."
        };

        public static ErrorMessage ForbidenError => new ErrorMessage()
        {
            Code = "403",
            Message = "Forbidden - You do not have permission to access this resource."
        };
        
        public static ErrorMessage InternalServerError => new ErrorMessage
        {
            Code = "500",
            Message = "Internal Server Error - An unexpected error occurred."
        };
    }
}
