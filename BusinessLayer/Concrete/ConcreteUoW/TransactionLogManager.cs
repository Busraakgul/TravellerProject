using BusinessLayer.Abstract.AbstractUoW;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;

namespace BusinessLayer.Concrete.ConcreteUoW
{
    public class TransactionLogManager : ITransactionLogService
    {
        private readonly ITransactionLogDal _transactionLogDal;

        public TransactionLogManager(ITransactionLogDal transactionLogDal)
        {
            _transactionLogDal = transactionLogDal;
        }

        public List<TransactionLog> TGetLogsByAccountId(int accountId)
        {
            return _transactionLogDal.GetLogsByAccountId(accountId);
        }

    }
}
