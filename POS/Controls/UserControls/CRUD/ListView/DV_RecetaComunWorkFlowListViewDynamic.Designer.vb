<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_RecetaComunWorkFlowListViewDynamic
    Inherits Studio.Net.Controls.[New].UserControls.DynamicTabularListView


    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        CType(Me.MyDXGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyDXGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MyDXGrid
        '
        Me.MyDXGrid.EmbeddedNavigator.Buttons.Append.Visible = False
        Me.MyDXGrid.EmbeddedNavigator.Buttons.CancelEdit.Visible = False
        Me.MyDXGrid.EmbeddedNavigator.Buttons.Edit.Visible = False
        Me.MyDXGrid.EmbeddedNavigator.Buttons.EndEdit.Visible = False
        Me.MyDXGrid.EmbeddedNavigator.Buttons.NextPage.Visible = False
        Me.MyDXGrid.EmbeddedNavigator.Buttons.PrevPage.Visible = False
        Me.MyDXGrid.EmbeddedNavigator.Buttons.Remove.Visible = False
        Me.MyDXGrid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MyDXGrid.EmbeddedNavigator.TextStringFormat = "Registro {0} of {1}"
        '
        'MyDXGridView
        '
        Me.MyDXGridView.OptionsView.ColumnAutoWidth = False
        '
        'LayoutControl
        '
        Me.LayoutControl.OptionsView.HighlightFocusedItem = True
        Me.LayoutControl.OptionsView.UseDefaultDragAndDropRendering = False
        '
        'LayoutControlGroup
        '
        Me.LayoutControlGroup.AppearanceGroup.BackColor = System.Drawing.Color.Transparent
        Me.LayoutControlGroup.AppearanceGroup.Options.UseBackColor = True
        '
        'RecetaComunWorkFlowListViewDynamic
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "RecetaComunWorkFlowListViewDynamic"
        CType(Me.MyDXGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyDXGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

End Class
