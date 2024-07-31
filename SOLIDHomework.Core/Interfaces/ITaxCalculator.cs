using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.Interfaces
{
    public interface ITaxCalculator
    {
        decimal ApplyTax(decimal amount);
    }
}
