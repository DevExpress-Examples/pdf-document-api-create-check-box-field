Imports DevExpress.Pdf
Imports System.Drawing

Namespace AddCheckBoxField

    Friend Class Program

        Shared Sub Main(ByVal args As String())
            Using processor As PdfDocumentProcessor = New PdfDocumentProcessor()
                ' Create an empty document. 
                processor.CreateEmptyDocument("..\..\Result.pdf")
                ' Create graphics and draw a check box field.
                Using graphics As PdfGraphics = processor.CreateGraphics()
                    DrawCheckBoxField(graphics)
                    ' Render a page with graphics.
                    processor.RenderNewPage(PdfPaperSize.Letter, graphics)
                End Using
            End Using
        End Sub

        Private Shared Sub DrawCheckBoxField(ByVal graphics As PdfGraphics)
            ' Create a check box field specifying its name and location.
            Dim checkBox As PdfGraphicsAcroFormCheckBoxField = New PdfGraphicsAcroFormCheckBoxField("check box", New RectangleF(20, 20, 30, 30))
            ' Specify check box appearance, checked state, and button style.
            checkBox.Appearance.BackgroundColor = Color.Azure
            checkBox.Appearance.BorderAppearance = New PdfGraphicsAcroFormBorderAppearance() With {.Color = Color.Red}
            checkBox.IsChecked = True
            checkBox.ButtonStyle = PdfAcroFormButtonStyle.Star
            ' Add the field to the document.
            graphics.AddFormField(checkBox)
        End Sub
    End Class
End Namespace
