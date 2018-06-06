# Cut List King

Cut List King is built to organize the cuts applied to linear material, maximizing for efficient use.

This prototype uses a static list of cuts called *CutItems* and applies them to a series of *Sticks*.  A CutItem is something you would find on a cut list.  It has a cutCode (description) and a length.  The "sticks" could be anything measured in linear whole numbers.

For examlpe, shoe moulding at a supply house might be measured in 16 foot pieces (192 inches).  If a house requires 400 linear feet of shoe moulding, you could simply divide the applicable numbers and proceed.  But what if you didn't want any breaks in your final installation and wanted to use uninterrupted pieces for your project.  A cut item that spans only 12 of the available 16 feet would leave 4 feet of potential waste.  How would you best use the remaining material on this first stock piece?  How would you best use the remaining material on any of the other pieces?

Cut List King is the solution.
* Enter your cuts, or *cut items*.
* Get a report of your sticks and which cut items belong to each of them.

## Example:

### Cut List ( 192 inch stock pieces ):

1. alpha 123"
2. bravo 12"
3. charlie 144"
4. delta 24"

*Note: the "charlie" cut is too long for the first stick and appears on its own.  The remaining room on Stick 1 is used by the fourth cut "delta".*

#### Stick List (Report with Cuts)
 ```
The shoe moulding in this case is 16 feet or a total length of 192 inches.

Total sticks required: 2

Stick 1
----------------------------

alpha                   -    123
bravo                   -     12
delta                   -     24

Total used: 159 -=- remaining 33


Stick 2
----------------------------

charlie                 -    144

Total used: 144 -=- remaining 48

```

## How it was made

This prototype is a simple console application written in C# .net core 2.0.  It's first use was to provide a cut plan to install shoe moulding.  Its output was pasted into a to-do style app for easy checking off.

There are a few simple classes, like *CutItem* that describe a cut, and another class, *CutListStacker*, that holds the logic.

### Future Plans

The very next code to be written for this application will be a test project (XUnit).

This application will serve as a learning tool to further explore emerging web technologies.

It will expand from a simple console application into a SPA frontend with an API backend.

This application will exist on both AWS and Azure.  This will allow the opportunity to leverage DynamoDB and Cosmos DB among other services.  Moreover, this application will be entirely *serverless* in the modern sense of the term.  This means AWS Lambda and Azure functions will be at the core.

Eventually, this will be made available to the public to use for free.

#### The comments found in the code are informational only.  Martin Fowler and Uncle Bob have strong opinions on code comments.