Eastpoint CodeChallenge
=====================

This is the repository for Eastpoint Systems C# coding challenge.

## Setup

1. First fork this repository to your github account.
2. Create a new feature branch for your work.

## Challenge

There are two parts to this challenge:
* Add a service for the creation and retrieval of Regions.  The creation a Region requires a `string name` and a `List<string> zipcodes`.
* Add REST methods to the `RegionsController` to allow users to Add, Get and Remove regions.

Feel free to modify any of the existing code or add any additional libraries in order to complete the challenge.

When you're finished submit a pull request to the Eastpoint fork for review.

## Notes
An in-memory implementation of `IRegionRepository` is provided to use as persistence, this can be used as a dependency in your service.

Several third party libraries are in use in this project.  The main ones being:
* [Autofac](https://github.com/autofac/Autofac) - A DI container.
* [AutoFixture](https://github.com/AutoFixture/AutoFixture) - Used in creating randomized objects for testing.
* [Xunit](https://github.com/xunit/xunit) - A testing framework.  
