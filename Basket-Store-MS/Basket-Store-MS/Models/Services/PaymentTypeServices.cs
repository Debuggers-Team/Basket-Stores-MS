using Basket_Store_MS.Data;
using Basket_Store_MS.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Services
{
    public class PaymentTypeServices : IPaymentType
    {
        private readonly BasketStoreDBContext _context;

        public PaymentTypeServices(BasketStoreDBContext context)
        {
            _context = context;
        }
        public async Task<PaymentType> Create(PaymentType paymentType)
        {
            _context.Entry(paymentType).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return paymentType;
        }

        public async Task<List<PaymentType>> GetPaymentTypes()
        {
            var payments = await _context.PaymentTypes.ToListAsync();

            return payments;
        }

        public async Task<PaymentType> GetPaymentType(int id)
        {
            var payments = await _context.PaymentTypes.FindAsync(id);

            return payments;
        }

        public async Task<PaymentType> UpdatePaymentType(int id, PaymentType paymentType)
        {
            _context.Entry(paymentType).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return paymentType;

        }

        public async Task DeletePaymentType(int id)
        {
            PaymentType paymentType = await GetPaymentType(id);

            _context.Entry(paymentType).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }
    }
}
