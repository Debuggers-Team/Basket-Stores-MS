using Basket_Store_MS.Models;
using Basket_Store_MS.Models.DTO;
using Basket_Store_MS.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Text;
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

            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[3] {
                    new DataColumn("Product Name" ,typeof(string)),
                    new DataColumn("Quantity", typeof(string)),
                    new DataColumn("Price",typeof(string)) });

            int count = 0;
            int q = 0;
            foreach (var item in bill.Products)
            {
                q = bill.Quantity[count];
                dt.Rows.Add(item.Name,q,item.Price * q);
                count++;
            }

            //string billDetails = $"Hi  {bill.UserName} <br> <br> Your product is  {bill.Products} \r Items Quantity is : {bill.TotalQuantity} \n  Total cost is : {bill.TotalCost}";

            StringBuilder sb = new StringBuilder();
            //Table start.
            sb.Append($"<p style='font-size:22px ;color:black;font-family:Arial'> Hi {bill.UserName} </p>");
            sb.Append($"<p style='font-size:22px ;color:black;font-family:Arial'> Thank you for using Basket Store </p> <br>");
            sb.Append("<table cellpadding='5' cellspacing='0' style='border: 1px solid #000000;font-size: 9pt;font-family:Arial ;color:black'>");

            //Adding HeaderRow.
            sb.Append("<tr>");
            foreach (DataColumn column in dt.Columns)
            {
                sb.Append("<th style='background-color: #FFD24C;border: 1px solid #000000'>" + column.ColumnName + "</th>");
            }
            sb.Append("</tr>");


            //Adding DataRow.
            foreach (DataRow row in dt.Rows)
            {
                sb.Append("<tr>");
                foreach (DataColumn column in dt.Columns)
                {
                    sb.Append("<td style='width:150px;border: 1px solid #000000'>" + row[column.ColumnName].ToString() + "</td>");
                }
                sb.Append("</tr>");
            }

            sb.Append("<tr>");
            sb.Append("<td style='width:150px;border: 1px solid #000000'>" + "Total" + "</td>");
            sb.Append("<td style='width:150px;border: 1px solid #000000'>" + bill.TotalQuantity + "</td>");
            sb.Append("<td style='width:150px;border: 1px solid #000000'>" + bill.TotalCost + "</td>");
            sb.Append("</tr>");

            //Table end.
            sb.Append("</table>");

            if(bill.TotalCost >= 100)
            {
                sb.Append($"<p style='font-size:22px ;color:black;font-family:Arial'> Total amount more than 100$ you get 10% off to your amount </p>");
                sb.Append($"<p style='font-size:22px ;color:black;font-family:Arial'> Your amount is <del style='color:red'>{bill.TotalCost}</del> now will be {bill.TotalCostDicount} </p>");
                sb.Append($"<p style='font-size:22px ;color:black;font-family:Arial'>See you again");

            }

            String singleString = sb.ToString();

            MailRequest request = new MailRequest
            {
                ToEmail = "mynamemohammad93@gmail.com",
                Subject = "Bill Details",
                Body = singleString
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
