using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Concrete
{
    public class TransactionLogRepository : ITransactionLogDal
    {
        private readonly Context _context;

        public TransactionLogRepository(Context context)
        {
            _context = context;
        }

        public List<TransactionLog> GetLogsByAccountId(int accountId)
        {
            return _context.TransactionLogs
                           .Where(log => log.AccountID == accountId)
                           .OrderByDescending(log => log.Date)
                           .ToList();
        }

        public void Insert(TransactionLog transactionLog)
        {
            _context.TransactionLogs.Add(transactionLog);
            _context.SaveChanges();
        }

        public List<TransactionLog> GetAll()
        {
            return _context.TransactionLogs
                           .OrderByDescending(log => log.Date)
                           .ToList();
        }

    }
}
