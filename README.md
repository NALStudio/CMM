# C--
### A weird language that I'm developing.

Plan for the language:
- [ ] Interpreted
- [ ] Turing-complete
- [ ] Statically Typed
- [ ] Crossplatform


## Syntax Prototype
```
using std; // Import all "std" namespaces from builtins and subdirectories.

private function main() // Main cannot be set as public. Global public methods can be called directly. Function returns are written like "function<int>"
{
	int nice = 69; // The integer type determines what type the 69 will be
	int pp = 420;
	print(nice + pp * 1); // ints and floats cannot be mixed in arithmetic operations;

	if (pp >= nice)
	{
		print($"{pp} is more or equal to {nice}"); // To have { in a formatted string, use \{
	}

	exit(0); // Exit call is optional.
}
```
