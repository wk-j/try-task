#! "netcoreapp2.1"
#r "../src/TryTask/obj/Debug/netstandard2.0/TryTask.dll"

using TryTask.Empty;

async MyTask Task1() {
    await Task.Delay(1);
}

async MyTask<int> Task2() {
    await Task.Delay(1);
    return 2;
}

public async ValueTask<string> Task3() {
    await Task.Delay(1);
    return "as";
}


// Console.WriteLine($"Task1 {Task1()}");
// Console.WriteLine($"Task2 {Task2()}");
Console.WriteLine($"Task3 {Task3().Result}");