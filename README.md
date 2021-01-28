# cdull
CDull is a less amazing version of C#.
CDull is named that way because the opposite of "sharp" is dull!

Currently CDull doesn't do much, although the new version I am working on is gonna have much more.(Version: Midnight)

Expectation:

```
@include "io.ch"

/start App
   consoleWrite("Hello, world!");
/end App
```
Output: 

```
Hello, world!
```
Reality:

```
main start
   log("Hello, World!");
:
```
Output:
```Hello, World!```
(this is if you compile the generated C++ code)
