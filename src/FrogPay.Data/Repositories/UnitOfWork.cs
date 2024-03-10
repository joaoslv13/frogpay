using FrogPay.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        public Task Commit(CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
