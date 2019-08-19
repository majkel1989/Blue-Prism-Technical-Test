using System.Collections.Generic;
using System.Linq;

namespace BluePrismTechnicalTest.DTO
{
    public abstract class ValidationResult
    {
        public virtual bool IsValid {
            get
            {
                if(!ErrorMessages.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public IEnumerable<string> ErrorMessages { get; set; }
    }
}