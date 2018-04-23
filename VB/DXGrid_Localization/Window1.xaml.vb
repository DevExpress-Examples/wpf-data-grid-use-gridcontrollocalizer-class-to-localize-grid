Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Grid

Namespace DXGrid_Localization
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
			grid.DataSource = TaskList.GetData()
		End Sub
		Shared Sub New()
			GridControlLocalizer.Active = New CustomDXGridLocalizer()
		End Sub

	End Class
	Public Class TaskList
		Public Shared Function GetData() As List(Of Task)
			Dim data As New List(Of Task)()
			data.Add(New Task() With {.TaskName = "Complete Project A", .StartDate = New DateTime(2009, 7, 1), .EndDate = New DateTime(2009, 7, 10)})
			data.Add(New Task() With {.TaskName = "Test Website", .StartDate = New DateTime(2009, 7, 10), .EndDate = New DateTime(2009, 7, 12)})
			data.Add(New Task() With {.TaskName = "Publish Docs", .StartDate = New DateTime(2009, 7, 4), .EndDate = New DateTime(2009, 7, 6)})
			Return data
		End Function
	End Class

	Public Class Task
		Private privateTaskName As String
		Public Property TaskName() As String
			Get
				Return privateTaskName
			End Get
			Set(ByVal value As String)
				privateTaskName = value
			End Set
		End Property
		Private privateStartDate As DateTime
		Public Property StartDate() As DateTime
			Get
				Return privateStartDate
			End Get
			Set(ByVal value As DateTime)
				privateStartDate = value
			End Set
		End Property
		Private privateEndDate As DateTime
		Public Property EndDate() As DateTime
			Get
				Return privateEndDate
			End Get
			Set(ByVal value As DateTime)
				privateEndDate = value
			End Set
		End Property
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
