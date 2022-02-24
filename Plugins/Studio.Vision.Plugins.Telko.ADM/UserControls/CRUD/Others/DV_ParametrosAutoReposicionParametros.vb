Imports Studio.Net.Controls.New
Imports Studio.Phone.BLL
Imports Studio.Phone.Controls.New
Imports Studio.Phone.DAL.EntityClasses

Public Class DV_ParametrosAutoReposicionParametros
    Inherits Studio.Net.Controls.[New].UserControls.DataViewBase

    Public Sub New()
        MyBase.New()
    End Sub

    Private Sub InitializeComponent()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl
        '
        Me.LayoutControl.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(618, 141, 450, 400)
        Me.LayoutControl.OptionsView.HighlightFocusedItem = True
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = False
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.AppearanceGroup.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControlGroup.AppearanceGroup.Options.UseBackColor = True
        '
        'DV_ParametrosAutoReposicionParametros
        '
        Me.Name = "DV_ParametrosAutoReposicionParametros"
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
End Class
