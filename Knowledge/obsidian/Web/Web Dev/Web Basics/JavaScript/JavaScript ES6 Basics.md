https://snippets.cacher.io/snippet/e7ff752f48f81f8b95d0

Date: 10/15/2019, 6:43 PM

> Difference between JavaScript ES5 and ES6 :

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/aMt-BQq9qTP0yPIYJFrrY8YAC4ZchKkz/dfrnc_btwn_js_es5_vs_es6.png)

- "let" and "const" type.
- main difference between "let" and "var" the local/global scope!
- "class" added in JS for OOP programming.
- "static" method.
- "extends" for inheritance.
- "constructor()" to call constructor.
- "super ()" to call inherited class.
- Template Literals - purpose is to contact strings of multiple lines using ` `. And more importantly you can use variable and call function using ${} ................................................. EX : `Hello ${name}` , `Hello Mzs, ${myFunc()}`, `$(myFunc(name)}`
- default parameters
- Arrow Functions / Fat Arrow Function - instead of Prefix
- Promises // the operation hasn't completed yet but expected to complete in future!
- Call Back Function / Higher Order Function / Timeout Function
- Object literal Extensions
- spread operator [ ... ] // (used in function call)
- rest operator [ ... ] // (used in function decoration... like params in c# ) 
- spread operator (opposite of rest operator)
- for of loop , for in loop
- destructuring - multiple variables!
- Set(), Map(), WeakSet(), WeakMap()
- Generators " * " // functions that can be paused or resumed at anytime and you also can return value on pause or resume!

EX : 

function  *mzs()   ||   function*  mzs() {

 console.log("hi");
 
 yield  'will pause here until next call';
 
 console.log("mzs");
 
 yield  'will pause here until next call';
 
 return 'returned'; // have to return something after the last yield!
 
}

var mz = mzs();

console.log(mz.next(). value);

console.log(mz.next(). value);

console.log(mz.next(). value);

- Iterators //
- Symbols();
- Symbol.iterator();
- Decorators
- 


> Built-in Keywords :
- NaN // Not a Number
- Infinity
- Number
- .size
- function
- this
- prototype
- prefixArray
- Promise // Built-in class object name !
- toAdd
- result
- return
- let
- const
- var
- arguments / arguments [ ] !
- static
- Promise
- .response
- .yield // use in Generator


> Built-In Methods / functions :
- setTimeout(() => console.log('Hello'), 1000); // 1000 = 1000 ms ( mili seconds) 
- .isFinite(3);
- .isNaN(); // NaN = not a number!
- .isInteger();
- .apply(null , )
- .add();
- .push();
- .delete();
- .forEach(function(val)); //pass value though function inside forEach!

- .then(); // use in Promise
- .resolve(); // use in Promise
- .reject(); // use in Promise
- .sort();
- constructor();
- Super ();
- Map();
- WeakSet();
- WeakMap();
- 

//-------- used in Map ------\\
- .set();
- .get();
- .has();
- .delete();
- .size();

- .entries ();
- .open();
- .send();
- getData( , ) // 1st parameter is Method : 'GET' / 'POST' & 2nd parameter is API link to access Data!
- .parse(data);
- .Symbol();
- Promise.all();
- Promise.race();
- .then();
- iterator.next();
- setPrototypeOf(); // 1st parameter is destination object and 2nd parameter is source object.
- Object.assign(); //can able to assign other object method to another or totally create a new object using other object methods!! 1st parameter will be where you want to assign other stuff!
- 

> String methods / functions :
- startsWith(); //exist at the beginning - true
- endsWith(); //exist at the end - true
- includes(); //exist any where in the string - true
-


> Built-in Classes :
- new Set();
- new Map();
- new weakSet();
- new weakMap();
- new Promise ();
- new XMLHttpRequeat();
- 


> Difference between Arrow Function / Fat Arrow Function and Normal Function
- Arrow Function / Fat Arrow Function doesn't have it's own "this" so "this" of Arrow Function / Fat Arrow Function always points the parents element "this". In DOM Parent element is "Window". !!No matter from which particular element it was triggered ... It will always point to the global element of that particular element!!
- But In Normal Function "this" always point to the particular element from which the function was triggered! 
Remember one thing , function has it's own "this" as well!!
- Arrow Function / Fat Arrow Function doesn't have arguments variable.

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/sauu7lgb5iMk6u3nlaeIhVbHHY6fDhkd/js_es6-arrow_function.jpg)

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/kT49luL4_7T8wzeTUAz8XDxxXO72fdhT/js_es6_nrml_func_vs_arrw_func.png)

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/OQk3PuQHA0Qlg8ZyHj_eP6XIKJw0aIZ5/js_es6_arrw_func-3.png)

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/JLaLJJuHLQweFb_l7UUAmfvFbPK9lRRw/js_es6_arrw_func-4.jpg)

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/1dkYOF8mV86SE699B62HlepBisod-mEE/js_es6_arrw_func-5.png)

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/VBsm5GQvXbL8HPTlgTZohKxMgqdErp5u/js_es6_arrw_func-6.jpg)

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/-t6_1GEmSSrR4O1sRREwa4PAexId0lDl/js_es6_arrw_func-7.jpg)

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/_GRhPOL4cXFJ-3QhV9eIQnFJK6LOBgin/js_es6_arrw_func-8.jpg)

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/6bmJrETwzoohghHRxSH4hMO9H1wLN-Fv/js_es6_arrw_func-9.jpg)



> Arrow Function instead of Prefix :

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/uguAmNROg4eBTJhEX44CyWwm_5imP-VZ/js_es6_arrw_func-1.png)

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/e79O_y6ENeIWVY_VWqo3QIUlT7NhiblO/js_es6_arrw_func-2.png)

> for of loop :

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/uPIgoTOF4f9ViqhbHu_ZlBx31TbuPyYk/js_es6_for_of_loop.jpg)

> let VS var :

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/BCoxjCnt3bC04eJW7ebgPWgdTCmT3mse/js_es6_let_vs_var-1.jpg)

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/3KgYZgP3dC2IJIJWUHvkHUPu9DAEhOPY/js_es6_let_vs_var-2.jpg)

> Hexa, Binary & Octal support :
- console.log(0xFF); - 255 // "0x" means hexa
- console.log(0b101011); - 43 //"0b" means binary
- console.log(0o543); = 355 // "0o" means Octal


> Spread Operators :
- To pass the args1 or args2 what we could do in ES5 is: test.apply(null, args1);
- But in ES6 to pass the args1 we should use spread Operator "..." // 3 dots and the variable name!

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/Z_RMWZFPl0v_dpur8oZXEqgxrTyT6L68/js_es6_spread_operator.png)

> "const" as value / array / object - the difference :
- Inner value inside object / array can be changed but cant change the type / object instance when it's Constant

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/MujvEiyFIHZ67j-OJ8_Cld0T_755yjd5/js_es6_constant-1.jpg)

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/GigEE9KnkkX7Hy4PCMc_mzFbETQLVtBG/js_es6_constant-2.jpg)

![](https://cdn.cacher.io/attachments/u/36tbqq15khlfj/Dxo4zPxPI-LZUnX0nf4va6MtJAA2iG-m/js_es6_constant-3.jpg)
