using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace ClienteHCS_2
{
    /// <summary>
    /// BindingList que soporta ordenación al hacer clic en las cabeceras del DataGridView.
    /// El grid usa IBindingList.ApplySort cuando el usuario ordena por columna.
    /// </summary>
    public class SortableBindingList<T> : BindingList<T>
    {
        private PropertyDescriptor _sortProperty;
        private ListSortDirection _sortDirection = ListSortDirection.Ascending;

        public SortableBindingList() { }

        public SortableBindingList(IList<T> list)
            : base(list ?? new List<T>())
        {
        }

        protected override bool SupportsSortingCore => true;
        protected override bool IsSortedCore => _sortProperty != null;
        protected override PropertyDescriptor SortPropertyCore => _sortProperty;
        protected override ListSortDirection SortDirectionCore => _sortDirection;

        protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
        {
            if (prop == null) return;

            _sortProperty = prop;
            _sortDirection = direction;

            List<T> items;
            try
            {
                items = direction == ListSortDirection.Ascending
                    ? this.OrderBy(x => prop.GetValue(x) ?? "").ToList()
                    : this.OrderByDescending(x => prop.GetValue(x) ?? "").ToList();
            }
            catch
            {
                return;
            }

            RaiseListChangedEvents = false;
            try
            {
                Clear();
                foreach (var item in items)
                    Add(item);
            }
            finally
            {
                RaiseListChangedEvents = true;
                OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
            }
        }

        protected override void RemoveSortCore()
        {
            _sortProperty = null;
            _sortDirection = ListSortDirection.Ascending;
        }
    }
}
