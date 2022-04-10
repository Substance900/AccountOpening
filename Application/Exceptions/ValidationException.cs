using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Exceptions
{

    //public class ValidationException : Exception
    //{
    //    public ValidationException()
    //        : base("One or more validation error(s) have occurred.")
    //    {
    //        Errors = new Dictionary<string, string[]>();
    //    }

    //    public ValidationException(IEnumerable<ValidationFailure> failures)
    //        : this()
    //    {
    //        var failureGroups = failures
    //            .GroupBy(e => e.PropertyName, e => e.ErrorMessage);

    //        foreach (var failureGroup in failureGroups)
    //        {
    //            var propertyName = failureGroup.Key;
    //            var propertyFailures = failureGroup.ToArray();

    //            Errors.Add(propertyName, propertyFailures);
    //        }
    //    }

    //    public IDictionary<string, string[]> Errors { get; }
    //    public bool Status { get; set; }
    //}
    public class ValidationException : ApplicationException
    {
        public List<string> ValdationErrors { get; set; }

        public ValidationException(ValidationResult validationResult)
        {
            ValdationErrors = new List<string>();

            foreach (var validationError in validationResult.Errors)
            {
                ValdationErrors.Add(validationError.ErrorMessage);
            }
        }
    }
}
