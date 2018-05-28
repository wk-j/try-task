#! "netcoreapp2.1"
#r "../src/TryTask/obj/Debug/netstandard2.0/TryTask.dll"

Option<int> devide(int top, int bottom) {
    if (bottom == 0) {
        return None<int>.Value;
    }
    return Some.Of(top / bottom);
}

async Option<int> start() {
    var v1 = await devide(120, 2);
    var v2 = await devide(v1, 0);
    var v3 = await devide(v2, 2);
    return v3;
}

var rs = start().GetAwaiter().GetResult();

