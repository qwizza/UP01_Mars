using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YPMarsLib
{
    public class ContractNumberGenerator
    {             
        private const string Prefix = "ДГ";        
        public string Generate(DateTime date, int lastNumberInYear)
        {
            int nextNumber = lastNumberInYear + 1;
            return $"{Prefix}-{date.Year:D4}-{nextNumber:D6}";
        }
    }
}
