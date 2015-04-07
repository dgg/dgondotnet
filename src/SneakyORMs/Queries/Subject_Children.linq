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

Subjects
.Where(s => s.ParentId == Parent.One)
.Select(s => new{ S = s, C = s.Children }).Dump();

Subjects.Single(s => s.Id== 13).Dump();

Childs.Single(c => c.Id == 131).Dump();