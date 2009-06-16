﻿namespace FluentNHibernate.MappingModel.Collections
{
    public class IndexMapping : MappingBase, IIndexMapping, IHasColumnMappings
    {
        private readonly AttributeStore<IndexMapping> attributes;
        private readonly IDefaultableList<ColumnMapping> columns = new DefaultableList<ColumnMapping>();

        public IndexMapping()
        {
            attributes = new AttributeStore<IndexMapping>();
        }

        public override void AcceptVisitor(IMappingModelVisitor visitor)
        {
            visitor.ProcessIndex(this);

            foreach (var column in columns)
                visitor.Visit(column);
        }

        public AttributeStore<IndexMapping> Attributes
        {
            get { return attributes; }
        }

        public TypeReference Type
        {
            get { return attributes.Get(x => x.Type); }
            set { attributes.Set(x => x.Type, value); }
        }

        public IDefaultableEnumerable<ColumnMapping> Columns
        {
            get { return columns; }
        }

        public void AddColumn(ColumnMapping mapping)
        {
            columns.Add(mapping);
        }

        public void AddDefaultColumn(ColumnMapping mapping)
        {
            columns.AddDefault(mapping);
        }

        public void ClearColumns()
        {
            columns.Clear();
        }
    }
}
