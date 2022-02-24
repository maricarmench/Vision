Imports System.Collections.Generic
Imports System.Runtime.CompilerServices
Imports DevExpress.XtraEditors
Imports Studio.Net.Controls.New.Controls

Public Module RecetaExtensions

    <Extension()>
    Public Function GetEditValueWithTag(ByVal control As DXSpinEdit) As Object
        Dim toReturn As Object = control.EditValue
        If control.Tag IsNot Nothing Then
            toReturn = control.Tag
        End If
        If toReturn Is Nothing Then
            toReturn = String.Empty
        End If
        Return toReturn
    End Function

    <Extension()>
    Public Function GetEditValueWithTagOrZero(ByVal control As DXSpinEdit) As Decimal
        Dim toReturn As Decimal = Decimal.Zero
        If IsNumeric(control.GetEditValueWithTag()) Then
            toReturn = CDec(control.GetEditValueWithTag())
        End If
        Return toReturn
    End Function

End Module

