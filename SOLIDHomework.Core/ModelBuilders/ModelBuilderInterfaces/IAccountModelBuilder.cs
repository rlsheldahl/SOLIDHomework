using SOLIDHomework.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.ModelBuilders.ModelBuilderInterfaces
{
    public interface IAccountModelBuilder
    {
        IAccountModelBuilder WithUsername(string username);
        IAccountModelBuilder WithEmail(string email);
        AccountModel Build();
    }
}
