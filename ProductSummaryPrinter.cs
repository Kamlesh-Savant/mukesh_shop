using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;

namespace MukeshShop
{
    public class ProductSummaryItem
    {
        public string ProductName { get; set; }
        public decimal TotalQty { get; set; }
    }

    public class ProductSummaryPrinter
    {
        private readonly string reportTitle;
        private readonly DateTime fromDate;
        private readonly DateTime toDate;
        private readonly List<ProductSummaryItem> items;

        private Font fontRegular = new Font("Segoe UI", 9);
        private Font fontBold = new Font("Segoe UI", 9, FontStyle.Bold);
        private Font fontHeader = new Font("Segoe UI", 11, FontStyle.Bold);

        public ProductSummaryPrinter(string reportTitle, DateTime fromDate, DateTime toDate, List<ProductSummaryItem> items)
        {
            this.reportTitle = reportTitle;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.items = items;
        }

        public void Print()
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintPage;
            pd.DefaultPageSettings.PaperSize = new PaperSize("Custom", 300, CalculatePaperHeight());
            pd.Print();
        }

        private int CalculatePaperHeight()
        {
            int baseHeight = 250;
            int perItemHeight = 30;
            return baseHeight + (items.Count * perItemHeight);
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int pageWidth = e.PageBounds.Width;
            int y = 10;

            // === Helper Methods ===
            void DrawCentered(string text, Font font)
            {
                SizeF size = g.MeasureString(text, font);
                g.DrawString(text, font, Brushes.Black, (pageWidth - size.Width) / 2, y);
                y += (int)size.Height;
            }

            void DrawLeftRight(string left, string right, bool bold = false)
            {
                Font f = bold ? fontBold : fontRegular;
                g.DrawString(left, f, Brushes.Black, 10, y);
                SizeF size = g.MeasureString(right, f);
                g.DrawString(right, f, Brushes.Black, pageWidth - size.Width - 33, y);
                y += (int)size.Height;
            }

            // === Header ===
            DrawCentered(reportTitle, fontHeader);
            DrawCentered($"From: {fromDate:dd-MMM-yyyy}  To: {toDate:dd-MMM-yyyy}", fontRegular);

            y += 10;
            g.DrawLine(Pens.Black, 0, y, pageWidth, y);
            y += 10;

            // === Column Headers ===
            int colNameX = 10;
            int colQtyX = 250;

            g.DrawString("Product Name", fontBold, Brushes.Black, colNameX, y);
            g.DrawString("Qty", fontBold, Brushes.Black, colQtyX, y);
            y += 20;

            g.DrawLine(Pens.Black, 0, y, pageWidth, y);
            y += 10;

            // === Items ===
            decimal totalQty = 0;
            int srNo = 1;

            foreach (var item in items)
            {
                // Product name
                g.DrawString($"{srNo}. {item.ProductName}", fontRegular, Brushes.Black, colNameX, y);
                g.DrawString(item.TotalQty.ToString(), fontRegular, Brushes.Black, colQtyX+5, y);
                y += 20;

                totalQty += item.TotalQty;
                srNo++;
            }

            y += 5;
            g.DrawLine(Pens.Black, 0, y, pageWidth, y);
            y += 10;

            // === Totals ===
            DrawLeftRight("Total Quantity:", totalQty.ToString(), true);

            y += 10;
            g.DrawLine(Pens.Black, 0, y, pageWidth, y);
            y += 10;

            DrawCentered("End of Report", fontBold);
        }
    }
}
