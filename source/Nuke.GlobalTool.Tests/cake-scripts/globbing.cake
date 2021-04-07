private void Convert()
{
    var files = GetFiles($"{publishDir}/**/A*.exe",
                         $"{publishDir}/**/B*.dll",
                         $"{publishDir}/**/C.exe");
}