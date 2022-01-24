# Cb __(C-flat)__
### My own programming language. Runs on .NOT Framework (Not Optimized or Tuned Framework) 

Plan for the language:
- [ ] Interpreted
- [ ] Turing-complete
- [ ] Statically Typed
- [ ] Crossplatform


## Syntax Prototype
```
using std; // Import all "std" namespaces from builtins and subdirectories. std will most likely be renamed to something PascalCase friendly.

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
