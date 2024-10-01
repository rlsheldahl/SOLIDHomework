using SOLIDHomework.Core.Model;
using SOLIDHomework.Core.ModelBuilders.ModelBuilderInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLIDHomework.Core.ModelBuilders
{
    public class AccountModelBuilder : IAccountModelBuilder
    {
        private AccountModel _model;

        public AccountModelBuilder()
        {
            _model = new AccountModel();
        }
        public IAccountModelBuilder WithUsername(string userName) 
        {
            _model.Username = userName;
            return this;
        }

        public IAccountModelBuilder WithEmail(string email)
        {
            _model.Email = email;
            return this;
        }

        public AccountModel Build()
        {
            return _model;
        }
    }
}
