var localPackagesDir = "../LocalPackages";
var sourceFolder = "./source/";
var publishDir = "./publish";
var signToolPath = MakeAbsolute(File("./certificates/signtool.exe"));

private string Convert(FilePath file)
{
    file = (FilePath) file;
    CopyFile($"{projectFile}/{projectFile}.nuspec", "nuspec");
}

private void NoConvert()
{
    var nodes = doc.SelectNodes("Project/PropertyGroup/RuntimeIdentifiers");
    var node = doc.SelectSingleNode("Project/PropertyGroup/RuntimeIdentifiers");
}