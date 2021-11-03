# C--
### A weird language that I'm developing.

Plan for the language:
- [ ] Interpreted
- [ ] Turing-complete
- [ ] Statically Typed
- [ ] Crossplatform


## Syntax Prototype
```
using "std" // Try to find a namespace 'std'. If found multiple, throw an error.

private function<int> main() // Main cannot be set as public. Global public methods can be called directly.
{
	int nice = 69; // The integer type determines what type the 69 will be
	int pp = 420;
	print(nice + (pp * 1)); // Only one operation allowed for each 'context' and ints and floats cannot be mixed in arithmetic operations;

	if (pp >= nice)
	{
		print($"{pp} is more or equal to {nice}"); // To have { in a formatted string, use \{
	}

	return 0; // Application must always return a status code.
}
```
