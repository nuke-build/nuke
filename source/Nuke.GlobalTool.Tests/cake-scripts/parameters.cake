using Path = System.IO.Path;

var target = Argument("target", "Default");
var boolean = Argument<bool>("boolean", false);
var configuration = Argument("configuration", "Release");
var parameterRename = Argument("where", "");
var certificatePassword = Argument("certificatePassword", "");
var awsAccessKeyId = Argument("aws_access_key_id", EnvironmentVariable("AWS_ACCESS_KEY") ?? "XXXX");

GitVersion gitVersionInfo;
string nugetVersion;
