using Cocona;
using Cocona.Builder;
using Microsoft.Extensions.DependencyInjection;
using N6CoconaLab.Services;
using System.Xml.Linq;

//CoconaApp.Run((string? name, bool hey) =>
//    Console.WriteLine($"{(hey ? "嘿" : "哈囉")} {(name ?? "來賓")}。"));

var builder = CoconaApp.CreateBuilder();

builder.Services.AddScoped<RandomService>();

var app = builder.Build();

//app.AddCommand((string? name, bool hey) =>
//  Console.WriteLine($"{(hey ? "嘿" : "哈囉")} {(name ?? "來賓")}。"));

app.AddCommand((
  [Option("first", Description = "這是前名稱。")] string firstname,
  [Option("last", Description = "這是後名稱。")] string? lastname) =>
  Console.WriteLine($"哈囉 {firstname} {lastname}。"));

app.AddCommand("greeting", (string? name, bool hey) =>
    Console.WriteLine($"{(hey ? "嘿" : "哈囉")} {(name ?? "來賓")}。"));

//app.AddCommand("math", (RandomService svc) =>
//    Console.WriteLine($"產生亂數 => {svc.GetRandomGuid()}"));

app.Run();
