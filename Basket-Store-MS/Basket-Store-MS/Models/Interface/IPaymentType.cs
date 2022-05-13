using Basket_Store_MS.Models.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket_Store_MS.Models.Interface
{
    public interface IPaymentType
    {
        //Create new PaymentType
        Task<PaymentTypeDto> Create(PaymentTypeDto paymentType);

        //Get All PaymentType
        Task<List<PaymentTypeDto>> GetPaymentTypes();

        //Get PaymentType by Id
        Task<PaymentTypeDto> GetPaymentType(int id);

        //Update PaymentType
        Task<PaymentTypeDto> UpdatePaymentType(int id, PaymentTypeDto paymentType);

        //Delete PaymentType by Id
        Task DeletePaymentType(int id);
    }
}
