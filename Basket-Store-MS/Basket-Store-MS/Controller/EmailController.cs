using Basket_Store_MS.Models;
using Basket_Store_MS.Models.DTO;
using Basket_Store_MS.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Basket_Store_MS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailService mailService;
        private readonly ICart _cart;
        public EmailController(IMailService mailService, ICart cart)
        {
            this.mailService = mailService;
            _cart = cart;
        }
        [HttpPost("Send/{id}")]
        public async Task<IActionResult> Send(int id)
        {
            BillDto bill = await _cart.GetBill(id);

            string billDetails = $"Hi  {bill.UserName}  Your product : {bill.Products}  Total Quantity is : {bill.TotalQuantity}  Total cost is : {bill.TotalCost}";

            MailRequest request = new MailRequest
            {
                ToEmail = "mynamemohammad93@gmail.com",
                Subject = "Bill Details",
                Body = billDetails
            };
            try
            {
                await mailService.SendEmailAsync(request);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
