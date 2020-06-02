# DataConverter

The DataConverter is a `C#` application that converts binary data to readable
data. Next to that is this a challenge repo. It contains a library containing
the logic to do the conversions. The challeng is to write the 'best' code.
Because the 'best' is very subjective in programming, there are 4 different
categories:

- `.Net`
- `Linq`
- Performance
- Obsucation / Source length

## Solution structure

| Item                 | Description                                    |
|:---------------------|:-----------------------------------------------|
| Core                 | Library project (`.netstandard2.0`) containing the logic to convert the data. |
||
| **Applications**     | Applications based on the library functionality. |
| Console              | Console application project (`.netcore3.1`) that uses the library functionality. |
| Shared               | Library project (`.netstandard2.0`) containing shared items for the WPF and UWP projects. |
| UWP                  | UWP application project () that uses the library functionality. |
| WPF                  | WPF application project (`.netcore3.1`) that uses the library functionality. |
||
| **Solution items**   | Files on solution level.                       |
| `.editorconifg`-file | containing the code-style rules to program in. |
||
| **Testing**          | Projects to test the writen code.              |
| Benchmark            | A project to benchmark the library             |
| Test                 | A project to test the functionality of the library with unit tests. |
| TestData             | A project containing mock-data to do the unit-tests/benchmarks. |

## Challenge

The challenge of the project is to implement the logic needed for the
applications to work. This logic is defined in the
`DataConverter.Core.Converters.IConverter`. This interface also contains
a brief documentation of the methods.

The implementing classes can be tested with the other projects. For a
functional test, run the *Test* project. For a benchmark, run the *Benchmark*
project. And the general functionality can be manually tested with the
application projects.

There is just one rule for the implementation: it must work. This means that
the tests should all pass (if a fault is found in the test, please report it).
The tests are however only a tool to test a part of the functionality. This
means that just returning the solution of th thest depending on which test
input is given, is not valid!

As stated before are there 4 different categories. To keep as objective as
possible.

### `.Net`

The `.Net` challenge is the least objective challenge. The goal here is to
write code that is as clean and idiomatic as possible according to the `.Net`
standards. What this exactly means is probably depends on the viewer. For the
challenges sake, I am the referee here. However, I might be persuaded with
compelling arguments (but my friends say I am quit stubborn so...).

### `Linq`

The `Linq` challenge is much alike the `.Net` challenge in the way that it
is not completely objective. The goal here is to try write code 'only' with
`Linq` statements. This might not possible for everything but try and prove
me otherwise.

### Performance

The performance challenge is quite obvious I think. Try to write code that
has the best performacne. The main-goal is execution time but memory is also
something to keep in mind.

### Obfuscation / Source length

This one might be close to the performance challenge but here short and obfuscated source code is the gloal. To show others what happens it is
preferable to add a private non obfuscated method or comments explaining 
the flow.

## How participate

1. Create a separate branch
2. Implement the functionality as you would like it.
3. Test code.
4. Create a pull request.

Or help me judge which code is best in it's category.

The best code will be used in the master branch.
