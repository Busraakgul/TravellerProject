using Microsoft.AspNetCore.Mvc;
using iTextSharp.text;
using iTextSharp.text.pdf;
namespace TravellerProject.Controllers
{

    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult StaticPdfReport()
        //{
        //    string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "file1.pdf");
        //    var stream = new FileStream(path,FileMode.Create);

        //    Document document = new Document(PageSize.A4);
        //    PdfWriter.GetInstance(document,stream);

        //    document.Open();

        //    Paragraph paragraph = new Paragraph("Traveller Path's Reservation Pdf Report");

        //    document.Add(paragraph);
        //    document.Close();
        //    return File("/pdfreports/file1.pdf", "application/pdf", "file1.pdf");
        //}

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/", "ReservationReport.pdf");
            using (var stream = new FileStream(path, FileMode.Create))
            {
                Document document = new Document(PageSize.A4);
                PdfWriter.GetInstance(document, stream);
                document.Open();

                // Add company name and report title
                var companyName = "Traveller Path";
                var reportTitle = "Reservation PDF Report";
                var currentDate = DateTime.Now.ToString("MMMM dd, yyyy");

                // Add Title and Date
                document.Add(new Paragraph(companyName, FontFactory.GetFont("Arial", 20, Font.BOLD)));
                document.Add(new Paragraph(reportTitle, FontFactory.GetFont("Arial", 16, Font.BOLD)));
                document.Add(new Paragraph($"Date: {currentDate}", FontFactory.GetFont("Arial", 12)));
                document.Add(new Chunk("\n")); // Add some space

                // Add a table to organize report data
                PdfPTable table = new PdfPTable(4); // Adjust the number of columns as necessary
                table.AddCell("City");
                table.AddCell("Accommodation Duration");
                table.AddCell("Price");
                table.AddCell("Capacity");

                // Example data - replace with actual data retrieval logic
                // This should be populated with real reservation data
                table.AddCell("Istanbul");
                table.AddCell("3 Nights");
                table.AddCell("$300");
                table.AddCell("2");

                table.AddCell("Ankara");
                table.AddCell("2 Nights");
                table.AddCell("$200");
                table.AddCell("4");

                document.Add(table);
                document.Close();
            }

            return File("/pdfreports/ReservationReport.pdf", "application/pdf", "ReservationReport.pdf");
        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/pdfreports/" + "file2.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);

            document.Open();
            PdfPTable pdfPTable = new PdfPTable(3);

            pdfPTable.AddCell("Guest Name");
            pdfPTable.AddCell("Guest Surname");
            pdfPTable.AddCell("Guest Identity Number");

            pdfPTable.AddCell("Adrien");
            pdfPTable.AddCell("Alan");
            pdfPTable.AddCell("112345678912");


            pdfPTable.AddCell("Johanssan");
            pdfPTable.AddCell("Jey");
            pdfPTable.AddCell("166345678912");


            pdfPTable.AddCell("Tray");
            pdfPTable.AddCell("Branson");
            pdfPTable.AddCell("11234448912");

            document.Add(pdfPTable);

            document.Close();
            return File("/pdfreports/file2.pdf", "application/pdf", "file2.pdf");
        }


    }
}
