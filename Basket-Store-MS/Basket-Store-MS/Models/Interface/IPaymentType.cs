using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Interface
{
    public interface IPaymentType
    {
        //Create new PaymentType
        Task<PaymentType> Create(PaymentType paymentType);

        //Get All PaymentType
        Task<List<PaymentType>> GetPaymentTypes();

        //Get PaymentType by Id
        Task<PaymentType> GetPaymentType(int id);

        //Update PaymentType
        Task<PaymentType> UpdatePaymentType(int id, PaymentType paymentType);

        //Delete PaymentType by Id
        Task DeletePaymentType(int id);
    }
}
