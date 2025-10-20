using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Printing;

namespace MukeshShop
{
    public class ReceiptItem
    {
        public string Name { get; set; }
        public decimal Qty { get; set; }
        // New property for the unit, placed after Qty
        public string Unit { get; set; }
        public decimal Rate { get; set; }
        public decimal Amount => Qty * Rate;
    }

    public class ReceiptPrinter
    {
        private readonly string shopName;
        private readonly string shopAddress;
        private readonly string mobile1;
        private readonly string mobile2;
        private readonly string gstNo;
        private readonly string billNo;
        private readonly DateTime saleDate;
        private readonly string customerName;
        private readonly string customerMobile;
        private readonly List<ReceiptItem> items;
        private readonly decimal total;
        private readonly decimal discount;
        private readonly decimal grandTotal;

        // Fonts
        private Font fontRegular = new Font("Segoe UI", 9);
        private Font fontBold = new Font("Segoe UI", 9, FontStyle.Bold);
        private Font fontHeader = new Font("Segoe UI", 11, FontStyle.Bold);

        public ReceiptPrinter(
            string shopName,
            string shopAddress,
            string mobile1,
            string mobile2,
            string gstNo,
            string billNo,
            DateTime saleDate,
            string customerName,
            string customerMobile,
            List<ReceiptItem> items,
            decimal total,
            decimal discount,
            decimal grandTotal)
        {
            this.shopName = shopName;
            this.shopAddress = shopAddress;
            this.mobile1 = mobile1;
            this.mobile2 = mobile2;
            this.gstNo = gstNo;
            this.billNo = billNo;
            this.saleDate = saleDate;
            this.customerName = customerName;
            this.customerMobile = customerMobile;
            this.items = items;
            this.total = total;
            this.discount = discount;
            this.grandTotal = grandTotal;
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
            int baseHeight = 350;
            int perItemHeight = 45;
            return baseHeight + (items.Count * perItemHeight);
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int pageWidth = e.PageBounds.Width;
            int y = 10;

            // Helper methods
            void DrawCentered(string text, Font font)
            {
                SizeF size = g.MeasureString(text, font);
                g.DrawString(text, font, Brushes.Black, (pageWidth - size.Width) / 2, y);
                y += (int)size.Height;
            }

            void DrawCenteredWrapped(string text, Font font, int maxWidth)
            {
                RectangleF layoutRect = new RectangleF(0, y, maxWidth, 0);
                StringFormat format = new StringFormat
                {
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Near
                };
                g.DrawString(text, font, Brushes.Black, layoutRect, format);
                SizeF size = g.MeasureString(text, font, maxWidth, format);
                y += (int)size.Height;
            }

            void DrawLeftRight(string left, string right, bool bold = false)
            {
                Font f = bold ? fontBold : fontRegular;
                g.DrawString(left, f, Brushes.Black, 10, y);
                SizeF size = g.MeasureString(right, f);
                g.DrawString(right, f, Brushes.Black, pageWidth - size.Width - 15, y);
                y += (int)size.Height;
            }

            // === Shop Header ===
            DrawCentered(shopName, fontHeader);
            DrawCenteredWrapped(shopAddress, fontRegular, pageWidth - 20);
            DrawCentered($"Mob.: {mobile1}, {mobile2}", fontRegular);
            DrawCentered($"GST No. : {gstNo}", fontRegular);

            y += 10;
            g.DrawLine(Pens.Black, 0, y, pageWidth, y);
            y += 10;

            // === Bill Info ===
            DrawLeftRight($"Bill No: {billNo}", $"Date: {saleDate:dd-MM-yyyy}", true);
            g.DrawString($"Customer: {customerName}", fontBold, Brushes.Black, 10, y);
            y += 20;
            g.DrawString($"Mobile: {customerMobile}", fontRegular, Brushes.Black, 10, y);
            y += 25;

            g.DrawLine(Pens.Black, 0, y, pageWidth, y);
            y += 5;

            // === Column Header ===
            int colItemX = 10;
            int colQtyX = 110; // Adjusted for new Unit column
            int colUnitX = 155; // New Unit column position
            int colRateX = 195; // Adjusted
            int colAmountX = 250; // Adjusted

            g.DrawString("Item", fontBold, Brushes.Black, colItemX, y);
            g.DrawString("Qty", fontBold, Brushes.Black, colQtyX, y);
            g.DrawString("Unit", fontBold, Brushes.Black, colUnitX, y); // New Column Header
            g.DrawString("Rate", fontBold, Brushes.Black, colRateX, y);
            g.DrawString("Amt", fontBold, Brushes.Black, colAmountX, y);
            y += 20;

            g.DrawLine(Pens.Black, 0, y, pageWidth, y);
            y += 10;

            // === Items ===
            int srNo = 1;
            decimal totalQty = 0;

            foreach (var item in items)
            {
                // First line → Item Name only
                g.DrawString($"{srNo}. {item.Name}", fontBold, Brushes.Black, colItemX, y);
                y += 18;

                // Second line → Qty, Unit, Rate, Amount aligned under headers
                g.DrawString(item.Qty.ToString(), fontRegular, Brushes.Black, colQtyX, y);
                g.DrawString(item.Unit, fontRegular, Brushes.Black, colUnitX, y); // New Unit value
                g.DrawString(item.Rate.ToString("N2"), fontRegular, Brushes.Black, colRateX, y);
                g.DrawString(item.Amount.ToString("N2"), fontRegular, Brushes.Black, colAmountX, y);

                y += 22;

                totalQty += item.Qty;
                srNo++;
            }

            y += 5;
            g.DrawLine(Pens.Black, 0, y, pageWidth, y);
            y += 10;

            // === Total Qty ===
            DrawLeftRight("Total Qty:", $"{totalQty}", true);
            y += 5;

            g.DrawLine(Pens.Black, 0, y, pageWidth, y);
            y += 10;

            // === Totals ===
            DrawLeftRight("Total:", $"₹{total:N2}", true);
            DrawLeftRight("Disc.:", $"₹{discount:N2}", true);
            DrawLeftRight("Grand Total:", $"₹{grandTotal:N2}", true);

            y += 10;
            g.DrawLine(Pens.Black, 0, y, pageWidth, y);
            y += 10;

            // === Footer ===
            DrawCentered("Thank You", fontBold);
        }
    }
}