using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.AbstractUoW
{
    public interface IAccountService: IGenericUoWService<Account>
    {
        void ProcessTransaction(List<Account> accounts, List<TransactionLog> transactionLogs);
    }
}
