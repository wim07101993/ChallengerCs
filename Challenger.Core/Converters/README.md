# Converter Challenge

The converter challenge exists of implementation of data conversion methods.

## Challenge methods

### `string Get*Base*String(byte[] bytes)`

Converts a `byte[]` (`bytes`) to a `string` that represents the bytes in the
specified format (`Base`: Binary, Octal, Decimal or Hex).

[Wikipedia bytes](https://en.wikipedia.org/wiki/Byte)

[Wikipedia counting binary](https://en.wikipedia.org/wiki/Binary_number#Counting_in_binary)

[Wikipedia binary conversions](https://en.wikipedia.org/wiki/Binary_number#Conversion_to_and_from_other_numeral_systems)

[Wikipedia octal](https://en.wikipedia.org/wiki/Octal)

[Wikipedia octal conversion](https://en.wikipedia.org/wiki/Octal#Conversion_between_bases)

[Wikipedia hexadecimal](https://en.wikipedia.org/wiki/Hexadecimal)

[Wikipedia hexadecimal conversion](https://en.wikipedia.org/wiki/Hexadecimal#Conversion)

#### Example

``` C#
GetBinaryString(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 })
    .Should()
    .Be("011010000 01100101 01101100 01101100 01101111 00100000 01110111 01101111 01110010 01101100 01100100");
```

``` C#
GetOctalString(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 })
    .Should()
    .Be("150 145 154 154 157 040 167 157 162 154 144");
```

``` C#
GetDecimalString(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 })
    .Should()
    .Be("104 101 108 108 111 032 119 111 114 108 100 114");
```

``` C#
GetHexString(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 })
    .Should()
    .Be("68 65 6C 6C 6F 20 77 6F 72 6C 64");
```

### `byte[] Parse*Base*String(string s)`

Parses a string which represents bytes in the specified format  (`Base`:
Binary, Octal, Decimal or Hex).

#### Example

``` C#
GetBinaryString("11010000 1100101 1101100 1101100 1101111 100000 1110111 1101111 1110010 1101100 1100100")
    .Should()
    .BeEquivalentTo(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 });
```

``` C#
GetOctalString("150 145 154 154 157 040 167 157 162 154 144")
    .Should(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 })
    .BeEquivalentTo();
```

``` C#
GetDecimalString("104 101 108 108 111 32 119 111 114 108 100 114")
    .Should()
    .BeEquivalentTo(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 });
```

``` C#
GetHexString("68 65 6C 6C 6F 20 77 6F 72 6C 64")
    .Should()
    .BeEquivalentTo(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 });
```

### `string Get*Encoding*tring(byte[] bytes)`

Converts a `byte[]` (`bytes`) to a `string` that represents the bytes in the 
specified encoding (ASCII, UTF8 or UTF32).

[Wikipedia ASCII](https://en.wikipedia.org/wiki/ASCII)
[ASCII table](http://www.asciitable.com/)

[Wikipedia UTF8](https://en.wikipedia.org/wiki/UTF-8)
[UTF8 table](https://www.utf8-chartable.de/)

[Wikipedia UTF32](https://en.wikipedia.org/wiki/UTF-32)
[UTF32 table](https://www.fileformat.info/info/charset/UTF-32/list.htm)

#### Example

``` C#
GetUtf8String(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 })
    .Should()
    .Be("Hello world");
```

### `byte[] Get*Encodin*Bytes(string s)`

Parses a string encoded in the given encoding (`Encoding`: ASCII, UTF8
 or UTF32).
 
#### Example

``` C#
GetAsciiString("Hello world")
    .Should()
    .Be(new byte[] { 0x68, 0x65, 0x6c, 0x6c, 0x6f, 0x20, 0x77, 0x6f, 0x72, 0x6c, 0x64 });
```

### `string Get*NumericType*(byte[] bytes)`

Converts a `byte[]` (`bytes`) to the given numeric type (`ushort`, `short`,
`uint`, `int`, `ulong`, `long`, `float`, `double` or `decimal`).

Integer Number types in `C#`:

| Data Type | Bit size | Min value                  | Max value                  |
|-----------|----------|----------------------------|----------------------------|
| `ushort`  | 16       | 0                          | 65,353                     |
| `short`   | 16       | -32,768                    | 32,767                     |
| `uint`    | 32       | 0                          | 4,294,967,295              |
| `int`     | 32       | -2,147,483,648             | 2,147,483,647              |
| `ulong`   | 64       | 0                          | 18,446,744,073,709,551,615 |
| `long`    | 64       | -9,223,372,036,854,775,808 | 9,223,372,036,854,775,807  |

(`byte` and `sbyte` are not listed here since they are not used in the converter).

| Data Type | Bit size | Approximate range | Precision     |
|-----------|----------|-------------------|---------------|
| `float`   | 32       | ±1.5 x 10−45      | ~6-9 digits   |
| `double`  | 64       | ±5.0 × 10−324     | ~15-17 digits |
| `decimal` | 128      | ±1.0 x 10-28      | 28-29 digits  |

[Wikipedia int](https://en.wikipedia.org/wiki/Integer_(computer_science))

[Microsoft integral numeric types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/integral-numeric-types)

[Microsoft floating-point numeric types](https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/floating-point-numeric-types)

#### Examples

``` C#
GetUShort(new byte[] { 0x30, 0x39 })
    .Should()
    .Be(12345);
```

``` C#
GetUShort(new byte[] { 0x49, 0x96, 0x02, 0xd3 })
    .Should()
    .Be(1323);
```

``` C#
GetULong(new byte[] { 0x49, 0x96, 0x02, 0xd3 })
    .Should()
    .Be(1234567891);
```

``` C#
GetULong(new byte[] { 0x06, 0xef, 0x79, 0x07, 0x7f, 0xbb })
    .Should()
    .Be(2030534587);
```

``` C#
GetDecimal(new byte[] { 0xeb, 0xec, 0xde, 0x35, 0x85, 0x7a, 0xed, 0x5a, 0x57, 0xd5, 0x19, 0xab, 0x00, 0x1c, 0x00, 0x00 })
    .Should()
    .Be(2.71828182845904523536028747140E+000m);
```

### `byte[] GetBytes(*NumericType* s)`

Converts number to its `byte[]` equivalent.

#### Examples

``` C#
GetBytes((ushort)12345)
    .Should()
    .BeEquivalentTo(new byte[] { 0x30, 0x39 });
```

``` C#
GetBytes(1323)
    .Should()
    .BeEquivalentTo(new byte[] { 0x02, 0xd3 });
```

``` C#
GetBytes(1234567891)
    .Should()
    .BeEquivalentTo(new byte[] { 0x49, 0x96, 0x02, 0xd3 });
```

``` C#
GetBytes(2030534587)
    .Should()
    .BeEquivalentTo(new byte[] { 0x06, 0xef, 0x79, 0x07, 0x7f, 0xbb });
```

``` C#
GetBytes(2.71828182845904523536028747140E+000m)
    .Should()
    .BeEquivalentTo(new byte[] { 0xeb, 0xec, 0xde, 0x35, 0x85, 0x7a, 0xed, 0x5a, 0x57, 0xd5, 0x19, 0xab, 0x00, 0x1c, 0x00, 0x00 });
```

## Test projects

To test the implementation, use the following:

- Unit tests
``` .net core
dotnet test DataConverter.Core
```
- Benchmarks
``` .net core
dotnet run --project DataConverter.Core.Benchmarks --framework netcoreapp3.1 --configuration Release
```
- Console test app:
```
dotnet run --project DataConverter.Console
```
```
dotnet run --project DataConverter.Console -- -i 10 -t Int -c DotNet
```
- WPF test app:
```
dotnet run --project Challenger.Wpf
``` 
- UWP test app:
