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

        private Font hindiFont = new Font("Mangal", 10);
        private Font hindiBold = new Font("Mangal", 10, FontStyle.Bold);

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
            int perItemHeight = 40;
            return baseHeight + (items.Count * perItemHeight);
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Graphics g = e.Graphics;
            int pageWidth = e.PageBounds.Width;
            int y = 10;

            void DrawCentered(string text, Font font)
            {
                SizeF size = g.MeasureString(text, font);
                g.DrawString(text, font, Brushes.Black, (pageWidth - size.Width) / 2, y);
                y += (int)size.Height;
            }

            void DrawLeftRight(string left, string right)
            {
                g.DrawString(left, hindiFont, Brushes.Black, 10, y);
                SizeF size = g.MeasureString(right, hindiFont);
                g.DrawString(right, hindiFont, Brushes.Black, pageWidth - size.Width - 10, y);
                y += (int)size.Height;
            }

            DrawCentered(shopName, hindiBold);
            DrawCentered(shopAddress, hindiFont);
            DrawCentered($"मो.: {mobile1}, {mobile2}", hindiFont);
            DrawCentered($"जीएसटी नंबर : {gstNo}", hindiFont);

            g.DrawString("________________________________________", hindiFont, Brushes.Black, 0, y);
            y += 20;

            DrawLeftRight($"बिल नं: {billNo}", $"दिनांक: {saleDate:dd-MM-yyyy}");
            g.DrawString($"ग्राहक: {customerName}", hindiBold, Brushes.Black, 10, y);
            y += 20;
            g.DrawString($"मोबाइल: {customerMobile}", hindiFont, Brushes.Black, 10, y);
            y += 20;

            g.DrawString("________________________________________", hindiFont, Brushes.Black, 0, y);
            y += 20;

            g.DrawString("Item          Qty              Rate                Amount", hindiFont, Brushes.Black, 10, y);
            y += 20;
            g.DrawString("________________________________________", hindiFont, Brushes.Black, 0, y);
            y += 20;

            int srNo = 1;
            foreach (var item in items)
            {
                g.DrawString($"{srNo}. {item.Name}", hindiFont, Brushes.Black, 10, y);
                y += 20;

                string valuesLine = string.Format("{0,12}           {1,10:N2}                 {2,10:N2}", item.Qty, item.Rate, item.Amount);
                g.DrawString("      "+valuesLine, hindiFont, Brushes.Black, 10, y);
                y += 20;
                srNo++;
            }

            g.DrawString("________________________________________", hindiFont, Brushes.Black, 0, y);
            y += 20;
            DrawLeftRight("टोटल:", $"₹{total:N2}");
            DrawLeftRight("डिस्काउंट:", $"₹{discount:N2}");
            DrawLeftRight("फाइनल टोटल:", $"₹{grandTotal:N2}");

            g.DrawString("________________________________________", hindiFont, Brushes.Black, 0, y);
            y += 20;

            DrawCentered("धन्यवाद!", hindiBold);
        }
    }
}
