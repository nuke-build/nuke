
private void Convert()
{
    DotNetCoreBuild("./source", new DotNetCoreBuildSettings {
        Configuration = configuration,
        ArgumentCustomization = args => args.Append($"/p:Version={nugetVersion}")
    });

    DotNetCoreTest(testProjectFile.FullPath, new DotNetCoreTestSettings {
        Configuration = configuration,
        NoBuild = true
    });

    DotNetCorePack(octopusClientFolder, new DotNetCorePackSettings {
        ArgumentCustomization = args => {
            args.Append($"/p:Version={nugetVersion}");
            args.Append($"/p:NuspecFile=file.nuspec");
            return args;
        },
        Configuration = configuration,
        OutputDirectory = artifactsDir,
        NoBuild = true,
        IncludeSymbols = false,
        Verbosity = DotNetCoreVerbosity.Normal,
    });

	Sign(files, new SignToolSignSettings {
        ToolPath = MakeAbsolute(File("./certificates/signtool.exe")),
        TimeStampUri = new Uri("http://rfc3161timestamp.globalsign.com/advanced"),
        TimeStampDigestAlgorithm = SignToolDigestAlgorithm.Sha256,
        CertPath = signingCertificatePath,
        Password = signingCertificatePassword
    });
}