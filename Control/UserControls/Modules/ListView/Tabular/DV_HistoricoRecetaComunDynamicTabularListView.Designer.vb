<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DV_HistoricoRecetaComunDynamicTabularListView
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
        Me.gvDetalle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gvPago = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gvDocumentoRecibo = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gvRelacion = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.gvRelaciones = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.MyDXGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyDXGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvPago, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvDocumentoRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvRelacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvRelaciones, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.MyDXGrid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvDetalle, Me.gvPago, Me.gvDocumentoRecibo, Me.gvRelacion, Me.gvRelaciones})
        '
        'MyDXGridView
        '
        Me.MyDXGridView.OptionsView.ColumnAutoWidth = False
        Me.MyDXGridView.OptionsView.ShowFooter = True
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
        'gvDetalle
        '
        Me.gvDetalle.GridControl = Me.MyDXGrid
        Me.gvDetalle.Name = "gvDetalle"
        '
        'gvPago
        '
        Me.gvPago.GridControl = Me.MyDXGrid
        Me.gvPago.Name = "gvPago"
        '
        'gvDocumentoRecibo
        '
        Me.gvDocumentoRecibo.GridControl = Me.MyDXGrid
        Me.gvDocumentoRecibo.Name = "gvDocumentoRecibo"
        '
        'gvRelacion
        '
        Me.gvRelacion.GridControl = Me.MyDXGrid
        Me.gvRelacion.Name = "gvRelacion"
        Me.gvRelacion.OptionsBehavior.Editable = False
        Me.gvRelacion.OptionsCustomization.AllowFilter = False
        Me.gvRelacion.OptionsCustomization.AllowGroup = False
        Me.gvRelacion.OptionsCustomization.AllowQuickHideColumns = False
        Me.gvRelacion.OptionsView.ColumnAutoWidth = False
        '
        'gvRelaciones
        '
        Me.gvRelaciones.GridControl = Me.MyDXGrid
        Me.gvRelaciones.Name = "gvRelaciones"
        Me.gvRelaciones.OptionsBehavior.Editable = False
        Me.gvRelaciones.OptionsCustomization.AllowFilter = False
        Me.gvRelaciones.OptionsCustomization.AllowGroup = False
        Me.gvRelaciones.OptionsCustomization.AllowSort = False
        Me.gvRelaciones.OptionsView.ColumnAutoWidth = False
        Me.gvRelaciones.OptionsView.ShowGroupPanel = False
        '
        'DV_HistoricoRecetaComunDynamicTabularListView
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Name = "DV_HistoricoRecetaComunDynamicTabularListView"
        CType(Me.MyDXGrid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyDXGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvPago, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvDocumentoRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvRelacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvRelaciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents gvPago As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvDetalle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvDocumentoRecibo As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvRelacion As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents gvRelaciones As DevExpress.XtraGrid.Views.Grid.GridView

End Class
