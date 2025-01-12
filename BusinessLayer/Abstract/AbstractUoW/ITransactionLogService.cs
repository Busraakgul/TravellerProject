using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Abstract.AbstractUoW
{
    public interface ITransactionLogService
    {
        List<TransactionLog> TGetLogsByAccountId(int accountId);
    }
}
