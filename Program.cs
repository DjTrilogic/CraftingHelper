// See https://aka.ms/new-console-template for more information

using CraftingHelper.Modifier;
using CraftingHelper.Config;

var modifiers = Modifier.FromJson(File.ReadAllText("mods.json"));
var config = Config.FromJson(File.ReadAllText("config.json"));

Console.WriteLine($"Parsed {modifiers.Length} modifiers.");
Console.WriteLine($"Parsed configuration with {config.ConfigConfig.Count()} steps.");

var craft = new FakeCraft(config);
craft.Execute();