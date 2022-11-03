Imports System
Imports System.Collections.Generic
Imports System.Windows
Imports DevExpress.Xpf.Grid

Namespace DXGrid_Localization

    Public Partial Class Window1
        Inherits Window

        Public Sub New()
            Me.InitializeComponent()
            Me.grid.ItemsSource = TaskList.GetData()
        End Sub

        Shared Sub New()
            GridControlLocalizer.Active = New CustomDXGridLocalizer()
        End Sub
    End Class

    Public Class TaskList

        Public Shared Function GetData() As List(Of Task)
            Dim data As List(Of Task) = New List(Of Task)()
            data.Add(New Task() With {.TaskName = "Complete Project A", .StartDate = New DateTime(2009, 7, 1), .EndDate = New DateTime(2009, 7, 10)})
            data.Add(New Task() With {.TaskName = "Test Website", .StartDate = New DateTime(2009, 7, 10), .EndDate = New DateTime(2009, 7, 12)})
            data.Add(New Task() With {.TaskName = "Publish Docs", .StartDate = New DateTime(2009, 7, 4), .EndDate = New DateTime(2009, 7, 6)})
            Return data
        End Function
    End Class

    Public Class Task

        Public Property TaskName As String

        Public Property StartDate As Date

        Public Property EndDate As Date
    End Class

    Public Class CustomDXGridLocalizer
        Inherits GridControlLocalizer

        Protected Overrides Sub PopulateStringTable()
            MyBase.PopulateStringTable()
            ' Changes the caption of the menu item used to invoke the Total Summary Editor.
            AddString(GridControlStringId.MenuFooterCustomize, "Customize Totals")
            ' Changes the Total Summary Editor's default caption.
            AddString(GridControlStringId.TotalSummaryEditorFormCaption, "Totals Editor")
            ' Changes the default caption of the tab page that lists total summary items.
            AddString(GridControlStringId.SummaryEditorFormItemsTabCaption, "Summary Items")
        End Sub
    End Class
End Namespace
