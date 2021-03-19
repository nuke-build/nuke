Task("A")
    .Does(() => System.Console.WriteLine());

Task("B")
    .IsDependentOn("A")
    .IsDependeeOf("A")
    .Does(() =>
    {
        System.Console.WriteLine();
    });

Task("C-1")
    .IsDependentOn("B")
    .WithCriteria(staticCondition)
    .WithCriteria(() => dynamicCondition)
    .ContinueOnError();

