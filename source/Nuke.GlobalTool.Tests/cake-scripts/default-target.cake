var target = Argument("target", "Default");

Task("Default")
    .Does(() => System.Console.WriteLine());

RunTarget(target);