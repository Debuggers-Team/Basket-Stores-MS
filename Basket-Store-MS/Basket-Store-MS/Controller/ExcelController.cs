using Basket_Store_MS.Models;
using Basket_Store_MS.Models.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Basket_Store_MS.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IProuduct _prouduct;

        public ExcelController(IProuduct prouduct)
        {
            _prouduct = prouduct;
        }

        [HttpGet]
        public async Task<ActionResult> GenerateExcel()
        {
            string FilePathName = Path.Combine(Directory.GetCurrentDirectory(), "Upload\\files", "DailyReport" + DateTime.Now.Ticks.ToString() + ".xls");

            List<ExcelSheet> lstProductData = await _prouduct.GetExcelSheetsData();

            string htmlstring = "<table style='width:800px;border:solid;border: 1px solid #000000;'> <thead> <tr>";
            htmlstring += "<th style ='width:10%;text-align:left;border: 1px solid black;'>SlNo</th>";
            htmlstring += "<th style ='width:30%;text-align:left;border: 1px solid black;'>Product Name</th>";
            htmlstring += "<th style ='width:30%;text-align:left;border: 1px solid black;'>InStock</th>";
            htmlstring += "<th style ='width:30%;text-align:left;border: 1px solid black;'>Discount</th>";
            htmlstring += "</tr></thead> <tbody>";

            foreach (ExcelSheet ex in lstProductData)
            {
                htmlstring += "<tr><td style ='width:10%;text-align:left;'>"+ ex.No +"</td>";
                htmlstring += "<td style ='width:30%;text-align:left;'>" + ex.ProductName + "</td>";
                htmlstring += "<td style ='width:30%;text-align:left;'>" + ex.InStock+ "</td>";
                htmlstring += "<td style ='width:30%;text-align:left;'>" + ex.Discount + "</td></tr>";
            }
            htmlstring += "</tbody></table>";

            System.IO.File.AppendAllText(FilePathName, htmlstring);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(FilePathName,out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(FilePathName);
            return File(bytes, contentType, Path.GetFileName(FilePathName));

        }

    }
}
