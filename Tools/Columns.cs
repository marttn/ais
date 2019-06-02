using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ais.Tools
{
    public static class DataGridColumns
    {
        static DataGridColumns()
        {
            FrameworkElement.DataContextProperty.AddOwner(typeof(DataGridTextColumn));
        }

        private static readonly DependencyProperty DataGridColumnSettingsProperty = DependencyProperty.RegisterAttached(
            "DataGridColumnSettings",
            typeof(DataGridColumnSettings),
            typeof(DataGridColumn));
        private static void SetDataGridColumnSettings(DataGridColumn column, DataGridColumnSettings settings) { column.SetValue(DataGridColumnSettingsProperty, settings); }
        private static DataGridColumnSettings GetDataGridColumnSettings(DataGridColumn column) { return column.GetValue(DataGridColumnSettingsProperty) as DataGridColumnSettings; }

        public static readonly DependencyProperty DisplayColumnsProperty = DependencyProperty.RegisterAttached(
            "DisplayColumns",
            typeof(IList),
            typeof(DataGridColumns),
            new PropertyMetadata(null, DisplayColumnsPropertyChanged));

        public static void SetDisplayColumns(DataGrid dataGrid, IList columns) { dataGrid.SetValue(DisplayColumnsProperty, columns); }
        public static IList GetDisplayColumns(DataGrid dataGrid) { return dataGrid.GetValue(DisplayColumnsProperty) as IList; }
        private static void DisplayColumnsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = d as DataGrid;
            var columns = e.NewValue as IList;
            var template = GetColumnSettingsTemplate(target);

            CreateColumns(target, columns, template);
        }

        public static readonly DependencyProperty ColumnSettingsTemplateProperty = DependencyProperty.RegisterAttached(
            "ColumnSetupTemplate",
            typeof(DataTemplate),
            typeof(DataGridColumns),
            new PropertyMetadata(null, ColumnSettingsTemplateChanged));
        public static void SetColumnSettingsTemplate(DataGrid dataGrid, DataTemplate columnSetupTemplate) { dataGrid.SetValue(ColumnSettingsTemplateProperty, columnSetupTemplate); }
        public static DataTemplate GetColumnSettingsTemplate(DataGrid dataGrid) { return dataGrid.GetValue(ColumnSettingsTemplateProperty) as DataTemplate; }
        private static void ColumnSettingsTemplateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = d as DataGrid;
            var columns = GetDisplayColumns(target);
            var template = e.NewValue as DataTemplate;

            CreateColumns(target, columns, template);
        }

        private static void CreateColumns(DataGrid dataGrid, IList columnViewModels, DataTemplate columnSettings)
        {
            if (dataGrid == null)
                return;
            dataGrid.Columns.Clear();

            if (columnViewModels == null)
                return;

            foreach (var column in columnViewModels)
            {
                var newColumn = new DataGridTextColumn();
                newColumn.SetValue(FrameworkElement.DataContextProperty, column);
                if (columnSettings != null)
                {
                    var settings = columnSettings.LoadContent() as DataGridColumnSettings;
                    if (settings != null)
                    {
                        settings.Setup(newColumn, column);
                        SetDataGridColumnSettings(newColumn, settings);
                    }
                }
                dataGrid.Columns.Add(newColumn);
            }
        }
    }

    public class DataGridColumnSettings : FrameworkElement
    {
        public static readonly DependencyProperty ColumnBindingPathProperty = DependencyProperty.Register(
            "ColumnBindingPath",
            typeof(string),
            typeof(DataGridColumnSettings),
            new PropertyMetadata(null, ColumnBindingPathChanged));
        public string ColumnBindingPath
        {
            get { return GetValue(ColumnBindingPathProperty) as string; }
            set { SetValue(ColumnBindingPathProperty, value); }
        }
        private static void ColumnBindingPathChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var target = d as DataGridColumnSettings;
            if (target == null)
                return;
            target.column.Binding = new Binding(e.NewValue as string);
        }

        public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
            "Header",
            typeof(object),
            typeof(DataGridColumnSettings));
        public object Header
        {
            get { return GetValue(HeaderProperty); }
            set { SetValue(HeaderProperty, value); }
        }

        private DataGridTextColumn column;
        private object viewModel;

        public void Setup(DataGridTextColumn column, object columnViewModel)
        {
            this.column = column;
            viewModel = columnViewModel;
            this.DataContext = columnViewModel;

            if (Header is FrameworkElement)
            {
                (Header as FrameworkElement).DataContext = columnViewModel;
                column.Header = Header;
            }
            else
                BindingOperations.SetBinding(column, DataGridColumn.HeaderProperty, new Binding("Header") { Source = this });
            column.Binding = new Binding(ColumnBindingPath);
        }
    }
}
