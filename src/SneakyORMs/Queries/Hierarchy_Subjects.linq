<Query Kind="Statements">
  <Connection>
    <ID>30b8ed72-a291-4431-8730-617a5e4bda45</ID>
    <Persist>true</Persist>
    <Driver>LinqToSql</Driver>
    <Server>.\SQLEXPRESS</Server>
    <CustomAssemblyPath>C:\Projects\DgonDotNet\trunk\src\SneakyORMs\bin\Debug\SneakyORMs.dll</CustomAssemblyPath>
    <CustomTypeName>DgonDotNet.Blog.Samples.SneakyORMs.SneakyContext</CustomTypeName>
    <Database>SneakyORMs</Database>
  </Connection>
</Query>

DataLoadOptions opt = new DataLoadOptions();
opt.LoadWith<Subject>(s => s.Parent);
opt.LoadWith<Subject>(s => s.Children);
//LoadOptions = opt;


var subjects = Subjects
	.Where(s => s.ParentId == Parent.One)
	.Select(s => new
	{
		S = s,
		O = s.OtherChildren.Count,
	})
	.Skip(1).Take(3)
	.OrderBy(s => s.S.Description)
	.Select(a => a.S.WithOthersCount(a.O));

//projectedSubjects.Dump();

foreach (var subject in subjects)
{
	subject.Dump();
	subject.Parent.Dump();
	foreach(var child in subject.Children) child.Dump();
	//projection.Dump();	
}