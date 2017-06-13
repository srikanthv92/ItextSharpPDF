using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO.Compression;

namespace MyFirstPDF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Document doc = new Document(iTextSharp.text.PageSize.LETTER, 10, 10, 42, 35);
            PdfWriter wr = PdfWriter.GetInstance(doc, new FileStream("MyPDF.pdf", FileMode.Create));
            doc.Open();
                iTextSharp.text.Font content = iTextSharp.text.FontFactory.GetFont("webdings",20, iTextSharp.text.Font.NORMAL);
                Paragraph para = new Paragraph("Booking Summary \n", content);
                para.SpacingAfter = 10;
                doc.Add(para);
            
                PdfPTable table = new PdfPTable(1);
                table.HorizontalAlignment = Element.ALIGN_LEFT;
                PdfPCell cell = new PdfPCell(new Paragraph("Booking Information", new iTextSharp.text.Font(iTextSharp.text.Font.NORMAL, 20f,iTextSharp.text.Font.NORMAL)));
                cell.HorizontalAlignment = Element.ALIGN_LEFT;
                cell.Colspan = 3;
                cell.PaddingTop = -2f;
                cell.PaddingLeft = 5f;
                cell.PaddingBottom =5f ;
                cell.HorizontalAlignment = 0;
                table.AddCell(cell);
                doc.Add(table);


            PdfPCell pcell = new PdfPCell();
            iTextSharp.text.Font contentfont = iTextSharp.text.FontFactory.GetFont("webdings", 10, iTextSharp.text.Font.NORMAL);
            Paragraph para1 = new Paragraph("   Approved ", contentfont);
            para1.Alignment = Element.ALIGN_MIDDLE;
            para1.PaddingTop = -10f;
            pcell.AddElement(para1);
            pcell.PaddingBottom = 7f;
            pcell.PaddingLeft = 5f;

                PdfPTable table1 = new PdfPTable(2);
                table1.DefaultCell.Border = 0;
                table1.HorizontalAlignment = Element.ALIGN_LEFT;
                iTextSharp.text.Font font = iTextSharp.text.FontFactory.GetFont("webdings", 15, iTextSharp.text.Font.NORMAL);
                table1.AddCell(new Paragraph("#ENSL0031248 \n", font)); 
                table1.SetWidths(new float[] { 0.6f, 0.1f });
                table1.AddCell(pcell/*new Paragraph("Approved", contentfont)*/);
                cell.Border = iTextSharp.text.Rectangle.BOTTOM_BORDER;
            
                table1.SpacingBefore = 5f;
                //table1.PaddingTop = 50f;
                doc.Add(table1);
                Paragraph p = new Paragraph("Projects \n");
                p.SpacingAfter = 10;
                p.SpacingBefore = 20;
                doc.Add(p);

            PdfPCell pdfcell = new PdfPCell();
            Paragraph para2 = new Paragraph(" Default Boardshare DD UKecommerce website development - RevDance DDUK Site Goldmine Integration KAT DEV P1 Revive Ecommerce Site Salesforce ");
            //para2.Alignment = Element.ALIGN_CENTER;
            //para1.PaddingTop = -10f;
            pdfcell.AddElement(para2);

                PdfPTable table2 = new PdfPTable(3);
                table2.DefaultCell.Border = 0;
                table2.HorizontalAlignment = Element.ALIGN_LEFT;
                table2.AddCell(pdfcell);
                iTextSharp.text.Font fcontent = iTextSharp.text.FontFactory.GetFont("webdings", 15, iTextSharp.text.Font.NORMAL);
                table2.AddCell(new Paragraph("ORD", fcontent));
                table2.AddCell(new Paragraph("ATL", fcontent));
                table2.AddCell("");
                table2.AddCell(new Paragraph("Chicago, IL-O'Hare(ORD)\nSunday, 21 May 2017 12:00 AM"));
                table2.AddCell(new Paragraph("Atlanta, GA(ATL)\nTuesday, 23 May 2017 12:00 AM"));
                table2.PaddingTop = 50f;
                doc.Add(table2);
            
            doc.Close();

      
        }
    }
}
