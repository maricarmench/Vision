Imports SD.LLBLGen.Pro.ORMSupportClasses
Imports Studio.Net.Helper
Imports System.Data.Common
Imports System.Collections.Generic
Imports Studio.Phone.POS.DAL.EntityClasses
Imports Studio.Net.BLL
Imports System.Reflection
Imports System.Text
Imports Studio.Vision.POS.BLL.Triggers

Public Class StudioDataAdapter
    Inherits Studio.Phone.POS.BLL.StudioDataAdapter

    Protected Overrides Sub OnAddTriggers()
        MyBase.OnAddTriggers()
        m_Triggers.Add((New DV_RecetaEntity).LLBLGenProEntityName, New Triggers.DV_RecetaTrigger())
    End Sub

End Class

