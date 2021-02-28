using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodPal.Notifications.Dto.Exceptions
{
    public class ValidationsException : Exception
    {
        public ValidationsException(List<string> errors)
        {
            Errors = errors;
        }

        public List<string> Errors { get; }
    }
}