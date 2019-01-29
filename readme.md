# .NET Code Challenge

You've been provided with the shell of a .Net application in Visual Studio with some sample inputs 

Create an application which outputs the horse names in price ascending order. 

The code should be at a standard you'd feel comfortable with putting in production.

## Background

The source data reflects how BetEasy has different providers of data which feed our website.
The data files are used allows creation of different races

## Feedback
* Implemented solution in C#

### Limitations
* I would've liked to institute more robust checks at several points in the application.
* Should've implemented a generic FileHandler 
* Implementation assumes files would be present at a location, though it streams it.
* The final result is the same from both file types so a nice data structure to accomodate both polymorphically woulld've been nice.

### Usage
* IMPORTANT! Please ensure that the source data files are in a folder called "FeedData" in the same location as the compiled executable file and binaries. When running the code from the IDE, please ensure that the "FeedData" folder with the json and xml data files have heen copied to the \bin\Debug\netcoreapp2.0 folder

### Thanks!
* Thank you so much - I quite enjoyed the challenge.
