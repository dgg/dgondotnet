<Query Kind="Statements">
  <Connection>
    <ID>30b8ed72-a291-4431-8730-617a5e4bda45</ID>
    <Persist>true</Persist>
    <Driver>LinqToSql</Driver>
    <Server>.\SQLEXPRESS</Server>
    <CustomAssemblyPath>C:\Projects\DgonDotNet\trunk\src\SneakyORMs\bin\Debug\SneakyORMs.dll</CustomAssemblyPath>
    <CustomTypeName>DgonDotNet.Blog.Samples.SneakyORMs.Linq2Sql.SneakyContext</CustomTypeName>
    <Database>SneakyORMs</Database>
  </Connection>
</Query>

Parents.InsertAllOnSubmit(new[]
{
	new Parent(
		new Guid("{11111111-1111-1111-1111-111111111111}"),
			"Parent 1",
			new Subject(11, "1.1",
				new Child(111, "data_1.1.1"),
				new Child(112, "data_1.1.2"),
				new Child(113, "data_1.1.3"))
				.WithOtherChildren(
					new OtherChild(111, "other_1.1.1"),
					new OtherChild(112, "other_1.1.2")
				),
			new Subject(12, "1.2",
				new Child(121, "data_1.2.1"),
				new Child(122, "data_1.2.2"))
				.WithOtherChildren(
					new OtherChild(121, "other_1.2.1")
				),
			new Subject(13, "1.3",
				new Child(131, "data_1.3.1")),
			new Subject(14, "1.4")),
	new Parent(
		new Guid("{22222222-2222-2222-2222-222222222222}"),
		"Parent 2",
		new Subject(21, "2.1",
			new Child(211, "data_2.1.1"),
			new Child(212, "data_2.1.2"),
			new Child(213, "data_2.1.3")),
		new Subject(22, "2.2",
			new Child(221, "data_2.2.1"),
			new Child(222, "data_2.2.2")),
		new Subject(23, "2.3",
			new Child(231, "data_2.3.1")),
		new Subject(24, "2.4"))
});
SubmitChanges();
