# Cb
### A weird language that I'm developing.
Cb (pronounced "See Flat") is a modern, object-oriented, and type-safe programming language. Cb enables developers to build many types of secure and robust applications that run in .NOT (Non-Optimised Technology). Cb has its roots in the C family of languages and will be immediately familiar to C, C++, C#, Java programmers and ~~JavaScript programmers~~ Demons.


### Plan for the language:
- [ ] Interpreted
- [ ] Turing-complete
- [ ] Statically Typed
- [ ] Crossplatform


## Syntax Prototype
```
using Standard; // Import all "Standard" namespaces from builtins and subdirectories.

namespace MyApp;

private function Main() // Main cannot be set as public. Global public methods can be called directly. Function returns are written like "function<int>"
{
	int nice = 69; // The integer type determines what type the 69 will be
	int pp = 420;
	Print(nice + pp * 1); // ints and floats cannot be mixed in arithmetic operations;

	if (pp >= nice)
	{
		Print($"{pp} is more or equal to {nice}"); // To have { in a formatted string, use \{
	}

	Exit(0); // Exit call is optional.
}
```
