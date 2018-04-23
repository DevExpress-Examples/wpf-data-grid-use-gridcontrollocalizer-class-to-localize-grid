using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using DevExpress.Xpf.Grid;

namespace DXGrid_Localization {

    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            grid.ItemsSource = TaskList.GetData();
        }
        static Window1() {
            GridControlLocalizer.Active = new CustomDXGridLocalizer();
        }
        
    }
    public class TaskList {
        public static List<Task> GetData() {
            List<Task> data = new List<Task>();
            data.Add(new Task() { TaskName = "Complete Project A", StartDate = new DateTime(2009, 7, 1), EndDate = new DateTime(2009, 7, 10) });
            data.Add(new Task() { TaskName = "Test Website", StartDate = new DateTime(2009, 7, 10), EndDate = new DateTime(2009, 7, 12) });
            data.Add(new Task() { TaskName = "Publish Docs", StartDate = new DateTime(2009, 7, 4), EndDate = new DateTime(2009, 7, 6) });
            return data;
        }
    }

    public class Task {
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CustomDXGridLocalizer : GridControlLocalizer {
        protected override void PopulateStringTable() {
            base.PopulateStringTable();
            // Changes the caption of the menu item used to invoke the Total Summary Editor.
            AddString(GridControlStringId.MenuFooterCustomize, "Customize Totals");
            // Changes the Total Summary Editor's default caption.
            AddString(GridControlStringId.TotalSummaryEditorFormCaption, "Totals Editor");
            // Changes the default caption of the tab page that lists total summary items.
            AddString(GridControlStringId.SummaryEditorFormItemsTabCaption, "Summary Items");
        }
    }
}
