using System;
using System.Linq;

using var db = new BloggingContext();

// Note: This sample requires the database to be created before running.
Console.WriteLine($"Database path: {db.DbPath}.");

db.Add(new Blog { Url = "http://blogs.msdn.com/adonet" });
db.SaveChanges();
Console.WriteLine("New blog added");

var blog = db.Blogs
    .OrderBy(b => b.BlogId)
    .First();
Console.WriteLine($"Found blog of: {blog.Url}");

blog.Url = "https://devblogs.microsoft.com/dotnet";
blog.Posts.Add(
    new Post { Title = "Hello World", Content = "I wrote an app using EF Core!" });
db.SaveChanges();
Console.WriteLine($"New post added of title: {db.Posts.ToArray().Last().Title} and with contents: {db.Posts.ToArray().Last().Content}");

Console.WriteLine($"Deleted the blog: {blog.Url}");
db.Remove(blog);
db.SaveChanges();