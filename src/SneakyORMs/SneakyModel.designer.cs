﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DgonDotNet.Blog.Samples.SneakyORMs
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	public partial class SneakyContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertParent(Parent instance);
    partial void UpdateParent(Parent instance);
    partial void DeleteParent(Parent instance);
    partial void InsertSubject(Subject instance);
    partial void UpdateSubject(Subject instance);
    partial void DeleteSubject(Subject instance);
    partial void InsertChild(Child instance);
    partial void UpdateChild(Child instance);
    partial void DeleteChild(Child instance);
    partial void InsertOtherChild(OtherChild instance);
    partial void UpdateOtherChild(OtherChild instance);
    partial void DeleteOtherChild(OtherChild instance);
    #endregion
		
		public SneakyContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SneakyContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SneakyContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public SneakyContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Parent> Parents
		{
			get
			{
				return this.GetTable<Parent>();
			}
		}
		
		public System.Data.Linq.Table<Subject> Subjects
		{
			get
			{
				return this.GetTable<Subject>();
			}
		}
		
		public System.Data.Linq.Table<Child> Childs
		{
			get
			{
				return this.GetTable<Child>();
			}
		}
		
		public System.Data.Linq.Table<OtherChild> OtherChilds
		{
			get
			{
				return this.GetTable<OtherChild>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Parents")]
	public partial class Parent : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private System.Guid _Id;
		
		private string _Name;
		
		private EntitySet<Subject> _Subjects;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(System.Guid value);
    partial void OnIdChanged();
    partial void OnNameChanging(string value);
    partial void OnNameChanged();
    #endregion
		
		public Parent()
		{
			this._Subjects = new EntitySet<Subject>(new Action<Subject>(this.attach_Subjects), new Action<Subject>(this.detach_Subjects));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="UniqueIdentifier", IsPrimaryKey=true)]
		public System.Guid Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Name", DbType="NVarchar(128)", CanBeNull=false)]
		public string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				if ((this._Name != value))
				{
					this.OnNameChanging(value);
					this.SendPropertyChanging();
					this._Name = value;
					this.SendPropertyChanged("Name");
					this.OnNameChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Parent_Subject", Storage="_Subjects", ThisKey="Id", OtherKey="ParentId")]
		public EntitySet<Subject> Subjects
		{
			get
			{
				return this._Subjects;
			}
			set
			{
				this._Subjects.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Subjects(Subject entity)
		{
			this.SendPropertyChanging();
			entity.Parent = this;
		}
		
		private void detach_Subjects(Subject entity)
		{
			this.SendPropertyChanging();
			entity.Parent = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Subjects")]
	public partial class Subject : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private long _Id;
		
		private string _Description;
		
		private System.Guid _ParentId;
		
		private EntitySet<Child> _Children;
		
		private EntitySet<OtherChild> _OtherChildren;
		
		private EntityRef<Parent> _Parent;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(long value);
    partial void OnIdChanged();
    partial void OnDescriptionChanging(string value);
    partial void OnDescriptionChanged();
    partial void OnParentIdChanging(System.Guid value);
    partial void OnParentIdChanged();
    #endregion
		
		public Subject()
		{
			this._Children = new EntitySet<Child>(new Action<Child>(this.attach_Children), new Action<Child>(this.detach_Children));
			this._OtherChildren = new EntitySet<OtherChild>(new Action<OtherChild>(this.attach_OtherChildren), new Action<OtherChild>(this.detach_OtherChildren));
			this._Parent = default(EntityRef<Parent>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="BigInt", IsPrimaryKey=true)]
		public long Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Description", DbType="NVarchar(256)")]
		public string Description
		{
			get
			{
				return this._Description;
			}
			set
			{
				if ((this._Description != value))
				{
					this.OnDescriptionChanging(value);
					this.SendPropertyChanging();
					this._Description = value;
					this.SendPropertyChanged("Description");
					this.OnDescriptionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ParentId", DbType="UniqueIdentifier")]
		public System.Guid ParentId
		{
			get
			{
				return this._ParentId;
			}
			set
			{
				if ((this._ParentId != value))
				{
					if (this._Parent.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnParentIdChanging(value);
					this.SendPropertyChanging();
					this._ParentId = value;
					this.SendPropertyChanged("ParentId");
					this.OnParentIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Subject_Child", Storage="_Children", ThisKey="Id", OtherKey="SubjectId")]
		public EntitySet<Child> Children
		{
			get
			{
				return this._Children;
			}
			set
			{
				this._Children.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Subject_AnotherChild", Storage="_OtherChildren", ThisKey="Id", OtherKey="SubjectId")]
		public EntitySet<OtherChild> OtherChildren
		{
			get
			{
				return this._OtherChildren;
			}
			set
			{
				this._OtherChildren.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Parent_Subject", Storage="_Parent", ThisKey="ParentId", OtherKey="Id", IsForeignKey=true)]
		public Parent Parent
		{
			get
			{
				return this._Parent.Entity;
			}
			set
			{
				Parent previousValue = this._Parent.Entity;
				if (((previousValue != value) 
							|| (this._Parent.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Parent.Entity = null;
						previousValue.Subjects.Remove(this);
					}
					this._Parent.Entity = value;
					if ((value != null))
					{
						value.Subjects.Add(this);
						this._ParentId = value.Id;
					}
					else
					{
						this._ParentId = default(System.Guid);
					}
					this.SendPropertyChanged("Parent");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Children(Child entity)
		{
			this.SendPropertyChanging();
			entity.Subject = this;
		}
		
		private void detach_Children(Child entity)
		{
			this.SendPropertyChanging();
			entity.Subject = null;
		}
		
		private void attach_OtherChildren(OtherChild entity)
		{
			this.SendPropertyChanging();
			entity.Subject = this;
		}
		
		private void detach_OtherChildren(OtherChild entity)
		{
			this.SendPropertyChanging();
			entity.Subject = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="Children")]
	public partial class Child : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private short _Id;
		
		private string _Data;
		
		private long _SubjectId;
		
		private EntityRef<Subject> _Subject;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(short value);
    partial void OnIdChanged();
    partial void OnDataChanging(string value);
    partial void OnDataChanged();
    partial void OnSubjectIdChanging(long value);
    partial void OnSubjectIdChanged();
    #endregion
		
		public Child()
		{
			this._Subject = default(EntityRef<Subject>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="SmallInt", IsPrimaryKey=true)]
		public short Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Data", DbType="NVarchar(128)")]
		public string Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if ((this._Data != value))
				{
					this.OnDataChanging(value);
					this.SendPropertyChanging();
					this._Data = value;
					this.SendPropertyChanged("Data");
					this.OnDataChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubjectId", DbType="BigInt")]
		public long SubjectId
		{
			get
			{
				return this._SubjectId;
			}
			set
			{
				if ((this._SubjectId != value))
				{
					if (this._Subject.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSubjectIdChanging(value);
					this.SendPropertyChanging();
					this._SubjectId = value;
					this.SendPropertyChanged("SubjectId");
					this.OnSubjectIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Subject_Child", Storage="_Subject", ThisKey="SubjectId", OtherKey="Id", IsForeignKey=true)]
		public Subject Subject
		{
			get
			{
				return this._Subject.Entity;
			}
			set
			{
				Subject previousValue = this._Subject.Entity;
				if (((previousValue != value) 
							|| (this._Subject.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Subject.Entity = null;
						previousValue.Children.Remove(this);
					}
					this._Subject.Entity = value;
					if ((value != null))
					{
						value.Children.Add(this);
						this._SubjectId = value.Id;
					}
					else
					{
						this._SubjectId = default(long);
					}
					this.SendPropertyChanged("Subject");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="OtherChildren")]
	public partial class OtherChild : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private short _Id;
		
		private string _Data;
		
		private long _SubjectId;
		
		private EntityRef<Subject> _Subject;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnIdChanging(short value);
    partial void OnIdChanged();
    partial void OnDataChanging(string value);
    partial void OnDataChanged();
    partial void OnSubjectIdChanging(long value);
    partial void OnSubjectIdChanged();
    #endregion
		
		public OtherChild()
		{
			this._Subject = default(EntityRef<Subject>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id", DbType="SmallInt", IsPrimaryKey=true)]
		public short Id
		{
			get
			{
				return this._Id;
			}
			set
			{
				if ((this._Id != value))
				{
					this.OnIdChanging(value);
					this.SendPropertyChanging();
					this._Id = value;
					this.SendPropertyChanged("Id");
					this.OnIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Data", DbType="NVarchar(128)")]
		public string Data
		{
			get
			{
				return this._Data;
			}
			set
			{
				if ((this._Data != value))
				{
					this.OnDataChanging(value);
					this.SendPropertyChanging();
					this._Data = value;
					this.SendPropertyChanged("Data");
					this.OnDataChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_SubjectId", DbType="BigInt")]
		public long SubjectId
		{
			get
			{
				return this._SubjectId;
			}
			set
			{
				if ((this._SubjectId != value))
				{
					if (this._Subject.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnSubjectIdChanging(value);
					this.SendPropertyChanging();
					this._SubjectId = value;
					this.SendPropertyChanged("SubjectId");
					this.OnSubjectIdChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Subject_AnotherChild", Storage="_Subject", ThisKey="SubjectId", OtherKey="Id", IsForeignKey=true)]
		public Subject Subject
		{
			get
			{
				return this._Subject.Entity;
			}
			set
			{
				Subject previousValue = this._Subject.Entity;
				if (((previousValue != value) 
							|| (this._Subject.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Subject.Entity = null;
						previousValue.OtherChildren.Remove(this);
					}
					this._Subject.Entity = value;
					if ((value != null))
					{
						value.OtherChildren.Add(this);
						this._SubjectId = value.Id;
					}
					else
					{
						this._SubjectId = default(long);
					}
					this.SendPropertyChanged("Subject");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
}
#pragma warning restore 1591
