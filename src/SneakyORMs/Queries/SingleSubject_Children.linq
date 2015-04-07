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
opt.LoadWith<Subject>(s => s.Children);
LoadOptions = opt;

var subject = Subjects.Single(s => s.Id== 23);
subject.Dump();
subject.Children.Dump();

Childs.Single(c => c.Id == 231).Dump();
Childs.Single(c => c.Id == 231).Dump();