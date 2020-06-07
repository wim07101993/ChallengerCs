# ChallengerCs

ChallengerCs challenges you to write some algorithms in C#. The challenge just
has one rule: **it must work**. To verify whether it works, unit tests and
benchmarks are written, ready to test.

To keep comparisons fair, there are different categories to enter in:

- `.Net`
- `Linq`
- Performance
- Obfuscation / Source length

## Challenge categories

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
has the best performance. The main-goal is execution time but memory is also
something to keep in mind.

### Obfuscation / Source length

This one might be close to the performance challenge but here short and
obfuscated source code is the goal. To show others what happens it is
preferable to add a private non obfuscated method or comments explaining
the flow.

## How participate

1. Create a separate branch under `challenge-solutions` (eg:
   `challenge-solutions\wim07101993`)
2. Implement the functionality as you think best.
3. Test code.
4. Create a pull request.

Or help me judge which code is best in it's category.

The best code will be used in the master branch.

## Visual studio solution overview

| Item                 | Description                                                                               |
| :------------------- | :---------------------------------------------------------------------------------------- |
| Core                 | Library project (`.netstandard2.0`) containing the logic to convert the data.             |
|                      |
| **Applications**     | Applications based on the library functionality.                                          |
| Console              | Console application project (`.netcore3.1`) that uses the library functionality.          |
| Shared               | Library project (`.netstandard2.0`) containing shared items for the WPF and UWP projects. |
| UWP                  | UWP application project () that uses the library functionality.                           |
| WPF                  | WPF application project (`.netcore3.1`) that uses the library functionality.              |
|                      |
| **Solution items**   | Files on solution level.                                                                  |
| `.editorconifg`-file | containing the code-style rules to program in.                                            |
|                      |
| **Testing**          | Projects to test the written code.                                                        |
| Benchmark            | A project to benchmark the challenge                                                      |
| Test                 | A project to test the challenge with unit tests.                                          |
| TestData             | A project containing mock-data to do the unit-tests/benchmarks.                           |
