using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRPDemo
{
    public class PersonValidator
    {
        public static bool Validate(Person person)
        {
            if (string.IsNullOrWhiteSpace(person.FirstName))
            {
                StandartMessages.DisplayValidationError("first name");
                return false;
            }

            if (string.IsNullOrEmpty(person.LastName))
            {
                StandartMessages.DisplayValidationError("last name");
                return false;
            }

            return true;
        }
    }
}
