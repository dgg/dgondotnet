using System;
using System.Data.Linq;
using System.Linq;

namespace DgonDotNet.Blog.Samples.SneakyORMs
{
	public partial class Parent
	{
		public static readonly Guid One = new Guid("{11111111-1111-1111-1111-111111111111}");
		public static readonly Guid Two = new Guid("{22222222-2222-2222-2222-222222222222}");

		public Parent(Guid id, string name, params Subject[] subjects)
		{
			Id = id;
			Name = name;
			_Subjects = new EntitySet<Subject>(attach_Subjects, detach_Subjects);
			Subjects.AddRange(subjects.Select(s => s.WithParent(id)));
		}
	}

	public partial class Subject
	{
		public Subject(long id, string description, params Child[] children)
		{
			Id = id;
			Description = description;
			_Children = new EntitySet<Child>(attach_Children, detach_Children);
			Children.AddRange(children.Select(c => c.WithSubject(id)));
			_OtherChildren = new EntitySet<OtherChild>(attach_OtherChildren, detach_OtherChildren);
		}

		public Subject WithParent(Guid parentId)
		{
			ParentId = parentId;
			return this;
		}

		public Subject WithOtherChildren(params OtherChild[] children)
		{
			OtherChildren.AddRange(children);
			return this;
		}

		public int? NumberOfOthers { get; private set; }

		public Subject WithOthersCount(int count)
		{
			NumberOfOthers = count;
			return this;
		}
	}

	public partial class Child
	{
		public Child(short id, string data)
		{
			Id = id;
			Data = data;
		}

		public Child WithSubject(long subjectId)
		{
			SubjectId = subjectId;
			return this;
		}
	}

	public partial class OtherChild
	{
		public OtherChild(short id, string data)
		{
			Id = id;
			Data = data;
		}

		public OtherChild WithSubject(long subjectId)
		{
			SubjectId = subjectId;
			return this;
		}
	}
}