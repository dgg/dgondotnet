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

Parents.Select(p => new { P = p, S = p.Subjects }).Dump();

Parents.Where(p => p.Id == Parent.One).Dump();

Subjects.Where(s => s.Id == 11).Dump();