using Cocona;
using Cocona.Builder;
using Microsoft.Extensions.DependencyInjection;
using N6CoconaLab;
using N6CoconaLab.Services;
using System.Xml.Linq;

//CoconaApp.Run((string? name, bool hey) =>
//    Console.WriteLine($"{(hey ? "嘿" : "哈囉")} {(name ?? "來賓")}。"));

var builder = CoconaApp.CreateBuilder();

builder.Services.AddScoped<RandomService>();

var app = builder.Build();

// 主要指令。※只能有一個。
//app.AddCommand((string? name, bool hey) =>
//  Console.WriteLine($"{(hey ? "嘿" : "哈囉")} {(name ?? "來賓")}。"));

// 主要指令。※只能有一個。
app.AddCommand((
  [Option("first", Description = "這是前名稱。")] string firstname,
  [Option("last", Description = "這是後名稱。")] string? lastname) =>
  Console.WriteLine($"哈囉 {firstname} {lastname}。"));

// Command 指令。Minimal API style。
app.AddCommand("rand", (RandomService svc) => Console.WriteLine($"產生亂數 => {svc.GetRandomGuid()}"))
   .WithDescription("產生亂數字串吧。");

// Command 指令。Class-based style。
app.AddCommands<GreetingCommand>();

// Command 指令。Minimal API style。
app.AddCommand("SayHi", (
    [Option('n', Description = "指定名稱")] string ? name, 
    [Option('h', Description = "說嘿")] bool hey, 
    RandomService svc) => Console.WriteLine($"{(hey ? "嘿" : "哈囉")} {name ?? "來賓"}。 順便生成亂數 {svc.GetRandomGuid()}"))
   .WithDescription("打招呼。用 Minimal API style 實作");

app.Run();
