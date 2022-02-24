Imports Studio.Net.Printing
Imports Studio.Net.Printing.StarPSTPrinter

Public Class OrdenTrabajoRecetaComun_Ticket_CutEpson
    Inherits OrdenTrabajoRecetaComun_Ticket

    Protected Overrides Sub CutPaper(prn As ITicketPrinter, partialCut As Boolean)

        Dim commands As New EpsonTMU950Printer.EpsonTMU950Commands
        Dim command As String

        If partialCut Then
            command = commands.CutPaperPartial
        Else
            command = commands.CutPaper
        End If
        prn.Write(command)

    End Sub

End Class
