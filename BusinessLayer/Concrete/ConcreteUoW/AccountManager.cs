using BusinessLayer.Abstract.AbstractUoW;
using DataAccessLayer.Abstract;
using DataAccessLayer.UnitOfWork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete.ConcreteUoW
{
    public class AccountManager : IAccountService
    {
        private readonly IAccountDal _accountDal;
        private readonly IUoWDal _uddal;
        private readonly ITransactionLogDal _transactionLogDal;

        //public AccountManager(IAccountDal accountDal, IUoWDal uddal)
        //{
        //    _accountDal = accountDal;
        //    _uddal = uddal;
        //}

        public AccountManager(IAccountDal accountDal, IUoWDal uddal, ITransactionLogDal transactionLogDal)
        {
            _accountDal = accountDal;
            _uddal = uddal;
            _transactionLogDal = transactionLogDal ?? throw new ArgumentNullException(nameof(transactionLogDal), "ITransactionLogDal cannot be null.");
        }


        public Account TGetByID(int id)
        {
            return _accountDal.GetByID(id);
        }

        public void TInsert(Account t)
        {
            _accountDal.Insert(t);
            _uddal.Save();
        }

        public void TMultiUpdate(List<Account> t)
        {
            _accountDal.MultiUpdate(t);
            _uddal.Save();
        }

        public void TUpdate(Account t)
        {
            _accountDal.Update(t);
            _uddal.Save();
        }


        public void ProcessTransaction(List<Account> accounts, List<TransactionLog> transactionLogs)
        {
            try
            {
                _accountDal.MultiUpdate(accounts);
                foreach (var log in transactionLogs)
                {
                    _transactionLogDal.Insert(log);
                }
                _uddal.Save();
            }
            catch
            {
                throw;
            }
        }

    }
}
