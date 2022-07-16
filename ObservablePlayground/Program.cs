using ObservablePlayground;

var envCommnadArr = Environment.GetCommandLineArgs();
if (envCommnadArr != null && envCommnadArr.Length != 1)
{
    string command = envCommnadArr[1];
    Console.WriteLine($"Hello, you passed an command {command}!");
}

new App().Start();