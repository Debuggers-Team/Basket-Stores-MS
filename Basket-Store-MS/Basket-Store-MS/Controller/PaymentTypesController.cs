using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Basket_Store_MS.Data;
using Basket_Store_MS.Models;
using Basket_Store_MS.Models.Interface;
using Basket_Store_MS.Models.DTO;

namespace Basket_Store_MS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypesController : ControllerBase
    {
        private readonly IPaymentType _payment;

        public PaymentTypesController(IPaymentType payment)
        {
            _payment = payment;
        }

        // GET: api/PaymentTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentType>>> GetPaymentTypes()
        {
            var paymentType = await _payment.GetPaymentTypes();

            return Ok(paymentType);
        }

        // GET: api/PaymentTypes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentType>> GetPaymentType(int id)
        {
            var paymentType = await _payment.GetPaymentType(id);

            if (paymentType == null)
            {
                return NotFound();
            }

            return Ok(paymentType);
        }

        // PUT: api/PaymentTypes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentType(int id, PaymentTypeDto paymentType)
        {
            if (id != paymentType.Id)
            {
                return BadRequest();
            }

            PaymentTypeDto modifiedPaymentType = await _payment.UpdatePaymentType(id,paymentType);

            return Ok(modifiedPaymentType);
        }

        // POST: api/PaymentTypes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymentTypeDto>> PostPaymentType(PaymentTypeDto paymentType)
        {
            var newPaymentType = await _payment.Create(paymentType);

            return Ok(newPaymentType);
        }

        // DELETE: api/PaymentTypes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentType(int id)
        {
             await _payment.DeletePaymentType(id);

            return NoContent();
        }
    }
}
