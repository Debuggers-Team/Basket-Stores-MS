using Basket_Store_MS.Data;
using Basket_Store_MS.Models.DTO;
using Basket_Store_MS.Models.Interface;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<PaymentTypeDto> Create(PaymentTypeDto paymentTypedto)
        {
            PaymentType paymentType1 = new PaymentType()
            {
                Id = paymentTypedto.Id,
                PaymentTypes = paymentTypedto.PaymentTypes
            };
            _context.Entry(paymentType1).State = EntityState.Added;

            await _context.SaveChangesAsync();
            return paymentTypedto;
        }

        public async Task<List<PaymentTypeDto>> GetPaymentTypes()
        {
            return await _context.PaymentTypes.Select(p => new PaymentTypeDto
            {
                Id = p.Id,
                PaymentTypes = p.PaymentTypes
            }).ToListAsync();

        }

        public async Task<PaymentTypeDto> GetPaymentType(int id)
        {
            return await _context.PaymentTypes.Select(p => new PaymentTypeDto
            {
                Id = p.Id,
                PaymentTypes = p.PaymentTypes
            }).FirstOrDefaultAsync(p => p.Id == id);

        }

    public async Task<PaymentTypeDto> UpdatePaymentType(int id, PaymentTypeDto paymentType)
        {

            PaymentType paymentType1 = new PaymentType()
            {
                Id = paymentType.Id,
                PaymentTypes = paymentType.PaymentTypes
            };
            _context.Entry(paymentType1).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return paymentType;

        }

        public async Task DeletePaymentType(int id)
        {
            PaymentType paymentType = await _context.PaymentTypes.FindAsync(id);

            _context.Entry(paymentType).State = EntityState.Deleted;

            await _context.SaveChangesAsync();
        }
    }
}
