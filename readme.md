# jsonite

Jsonite is a lightweight JSON serializer and deserializer for .NET

```C#
var obj = (JsonObject)Json.Deserialize(@"{""name"": ""John"", ""age"": 26}")
```

Jsonite provides the following features:

- The implementation *should be* [ECMA-404](http://www.ecma-international.org/publications/files/ECMA-ST/ECMA-404.pdf) and [RFC 4627](https://tools.ietf.org/html/rfc4627) compliant. If you find any issues please log an issue!
- Single file serializer/deserializer that can be embedded directly into a project.
- Default implementation serializing/deserializing from/to `JsonObject` / `JsonArray`
- Method `Json.Validate` to validate a json object
- Precise error with line/column when deserializing an invalid json text.
- Very fast and very low GC memory pressure when deserializing/serializing compare to other JSON libraries.
- Simple pluggable API to allow to deserialize/serialize from/to other kinds of .NET objects (through the `JsonReflector` class)
- Default implementation does not use Reflection or Expression to serialize/deserialize to .NET `JsonObject`/`JsonArray`.

Jsonite is easily embeddable for quickly decoding/encoding JSON without relying on an external Json library.

## Usage and Compilation

As this library is intended to be embedded and compiled directly from your project, we don't provide a nuget package.

Instead, you can for example use this repository as a git sub-module of your project and reference directly the file [`Jsonite.cs`](https://github.com/xoofx/jsonite/blob/master/src/Jsonite/Jsonite.cs)

The code is compatible with `PCL .NET 4.5+`, `CoreCLR`, `CoreRT` and `UWP10`.

## Limitations

Jsonite does not provide a deserializer/serializer from/to an arbitrary object graph. Prefers using a more complete solution like Json.NET.

## License
This software is released under the [BSD-Clause 2 license](http://opensource.org/licenses/BSD-2-Clause). 

## Author

Alexandre Mutel aka [xoofx](http://xoofx.com).

## Benchmarks

Machine details:

```
BenchmarkDotNet v0.13.12, Windows 10 (10.0.19045.3930/22H2/2022Update)
12th Gen Intel Core i9-12900H, 1 CPU, 20 logical and 14 physical cores
  [Host]     : .NET Framework 4.8.1 (4.8.9181.0), X86 LegacyJIT
  DefaultJob : .NET Framework 4.8.1 (4.8.9181.0), X86 LegacyJIT
```

| Method                              | Mean      | Error     | StdDev    | Gen0      | Gen1     | Gen2     | Allocated |
|------------------------------------ |----------:|----------:|----------:|----------:|---------:|---------:|----------:|
| Textamina.Jsonite                   |  3.642 ms | 0.0364 ms | 0.0341 ms |  332.0313 | 222.6563 |        - |   1.89 MB |
| Newtonsoft.Json                     |  7.013 ms | 0.0401 ms | 0.0355 ms |  578.1250 | 445.3125 |        - |   3.38 MB |
| 'System.Text.Json (FastJsonParser)' |  5.735 ms | 0.0550 ms | 0.0515 ms |  382.8125 | 382.8125 | 382.8125 |   1.58 MB |
| ServiceStack.Text                   | 11.322 ms | 0.1243 ms | 0.1163 ms | 1250.0000 | 984.3750 | 500.0000 |   6.62 MB |
| fastJSON                            |  2.748 ms | 0.0534 ms | 0.0731 ms |  570.3125 | 453.1250 | 238.2813 |   2.99 MB |
| Jil                                 |  3.766 ms | 0.0379 ms | 0.0355 ms |  714.8438 | 691.4063 |        - |   4.28 MB |
| JavaScriptSerializer                |  9.346 ms | 0.0587 ms | 0.0520 ms |  875.0000 | 734.3750 |        - |   5.13 MB |
