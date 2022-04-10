using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Response
{
    public enum ResponseStatus
    {
        OK = 200,
        CREATED = 201,
        NO_CONTENT = 204,
        BAD_REQUEST = 400,
        UNAUTHORIZED = 401,
        NOT_FOUND = 404,
        REQUEST_TIMEOUT = 408,
        CONFLICT = 409,
        TIMEOUT,
        INVALID_OBJECT_STATE,
        SERVER_ERROR = 500,
        UNPROCESSABLE = 422,
        FORBIDDEN = 403,
    }
}
