using System;
using System.Collections.Generic;
using System.Text;

namespace GenericRepository.DataAccess.FilterProcess
{
    public class FilterUtility
    {
        public enum FilterOptions
        {
            StartWith =1,
            EndsWith,
            Contains,
            DoesNotContain,
            IsEmpty,
            IsNotEmpty,
            IsGreaterThan,
            IsGreaterThanOrEqualTo,
            IsLessThan,
            IsLessThanOrEqualTo,
            IsEqualTo,
            IsNotEqualTo
        }
    }
}
