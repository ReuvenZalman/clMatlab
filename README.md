# clMatlab
Functions inspired by Matlab/Octave workflow in C#.

## Installation
Either run 
```
git clone https://github.com/ReuvenZalman/clMatlab
```
or just download the zip file from the Code tab. \
In your project, add `clMatlab.dll` which is found in `clMatlab\bin\Debug\net5.0\` to the project references. \
In Visual Studio 2019 this can be done via the Reference Manager -> Browse tab, from where you can browse for the .dll file. 

## Usage
In your project, at the top, add `using cl=clMatlab.clMatlab;`. This shortens the call to any function from the library from `clMatlab.clMatlab.someFunc()` to `cl.someFunc()`.

## General Remarks
This project is oriented toward the engineer who is used to high-level languages such as Octave / Matlab or Python but requires a C# implementaion either for the performance benefit or the platform ubiquity. \
This project is publicly shared with the hope the those who find it useful, happily contribute.

