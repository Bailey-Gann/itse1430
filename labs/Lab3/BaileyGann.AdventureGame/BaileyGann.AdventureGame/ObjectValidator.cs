/*
 * Lab 4
 * Bailey Gann
 * 4/21/2022
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaileyGann.AdventureGame
{
    public static class ObjectValidator
    {
        public static bool TryValidateObject ( IValidatableObject value, out IEnumerable<ValidationResult> results )
        {
            var context = new ValidationContext(value);
            var errors = new List<ValidationResult>();

            if (Validator.TryValidateObject(value, context, errors, true))
            {
                results = new ValidationResult[0];
                return true;
            };

            results = errors;
            return false;
        }
    }
}
