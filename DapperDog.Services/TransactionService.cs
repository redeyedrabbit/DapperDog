using DapperDog.Data;
using DapperDog.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperDog.Services
{
    public class TransactionService
    {
        private readonly Guid _userId;

        public TransactionService(Guid userId)
        {
            _userId = userId;
        }

        public TransactionDetail GetTransactionDetailsById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var transaction = ctx.Transactions.Single(m => m.TransactionId == id);
                return new TransactionDetail
                {
                    TransactionId = transaction.TransactionId,
                    CustomerId = transaction.CustomerId,
                    ProductId = transaction.ProductId,                    
                    DateOfTransaction = transaction.DateOfTransaction

                };
            }
        }

        public bool CreateTransaction(TransactionCreate model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var newTransaction = new Transaction()
                {
                    CustomerId = model.CustomerId,
                    ProductId = model.ProductId,
                    DateOfTransaction = DateTimeOffset.Now
                };

                ctx.Transactions.Add(newTransaction);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<TransactionListItem> GetTransactionList()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx.Transactions.Select(m => new TransactionListItem
                {
                    TransactionId = m.TransactionId,
                    CustomerId = m.CustomerId,
                    ProductId = m.ProductId,                    
                    DateOfTransaction = m.DateOfTransaction
                });

                return query.ToArray();
            }

        }

        public bool UpdateTransaction(TransactionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var transaction = ctx.Transactions.Single(m => m.TransactionId == model.TransactionId);
                transaction.CustomerId = model.CustomerId;
                transaction.ProductId = model.ProductId;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteTransaction(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                if (!ctx.Transactions.Any(m => m.TransactionId == transactionId))
                    return false;

                var model =
                    ctx
                    .Transactions
                    .Single(m => m.TransactionId == transactionId);

                ctx.Transactions.Remove(model);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
