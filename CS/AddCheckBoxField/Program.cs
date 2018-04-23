using DevExpress.Pdf;
using System.Drawing;

namespace AddCheckBoxField {
    class Program {
        static void Main(string[] args) {
            using (PdfDocumentProcessor processor = new PdfDocumentProcessor()) {

                // Create an empty document. 
                processor.CreateEmptyDocument("..\\..\\Result.pdf");

                // Create graphics and draw a check box field.
                using (PdfGraphics graphics = processor.CreateGraphics()) {
                    DrawCheckBoxField(graphics);

                    // Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics);
                }
            }
        }

        static void DrawCheckBoxField(PdfGraphics graphics) {

            // Create a check box field specifying its name and location.
            PdfGraphicsAcroFormCheckBoxField checkBox = new PdfGraphicsAcroFormCheckBoxField("check box", new RectangleF(20, 20, 30, 30));

            // Specify check box appearance, checked state, and button style.
            checkBox.Appearance.BackgroundColor = Color.Azure;
            checkBox.Appearance.BorderAppearance = new PdfGraphicsAcroFormBorderAppearance() { Color = Color.Red };
            checkBox.IsChecked = true;
            checkBox.ButtonStyle = PdfAcroFormButtonStyle.Star;

            // Add the field to the document.
            graphics.AddFormField(checkBox);
        }
    }
}
