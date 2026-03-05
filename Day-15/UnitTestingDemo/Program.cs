using System;

// ------------------------- RED-GREEN-REFACTOR DEMO -------------------------

// ------------------------- STEP 1: RED -------------------------
// RED stage: We write tests first, BEFORE implementing the Add() function
// At this point, if Add() didn't exist or was incorrect, tests would fail

// Calling test methods one by one
AddFunctionShouldReturn30ForInputs10And20();
AddFunctionShouldReturn40ForInputs20And20();
AddFunctionShouldReturn50ForInputs25And25();

// ------------------------- TEST METHODS -------------------------

// ------------------------- RED / GREEN / REFACTOR EXPLAINED -------------------------

// Test method to check if Add(10, 20) returns 30
void AddFunctionShouldReturn30ForInputs10And20()
{
    // ----------------- ARRANGE -----------------
    // Set up the inputs and expected result
    var x = 10;
    var y = 20;
    var expectedResult = 30;

    // ----------------- ACT -----------------
    // Call the method under test
    // GREEN stage: After implementing Add(), this test should pass
    var actualResult = Add(x, y);

    // ----------------- ASSERT -----------------
    // Check if the actual result matches the expected result
    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");

    if (actualResult == expectedResult)
        Console.WriteLine("Test Passed");  // GREEN: Test passes
    else
        Console.WriteLine("Test Failed");  // RED: Test fails if Add() not implemented
}

// Test method to check if Add(20, 20) returns 40
void AddFunctionShouldReturn40ForInputs20And20()
{
    // ARRANGE
    var x = 20;
    var y = 20;
    var expectedResult = 40;

    // ACT
    var actualResult = Add(x, y);  // GREEN: Test will pass after Add() is implemented

    // ASSERT
    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");
    if (actualResult == expectedResult)
        Console.WriteLine("Test Passed");  // GREEN
    else
        Console.WriteLine("Test Failed");  // RED
}

// Test method to check if Add(25, 25) returns 50
void AddFunctionShouldReturn50ForInputs25And25()
{
    // ARRANGE
    var x = 25;
    var y = 25;
    var expectedResult = 50;

    // ACT
    var actualResult = Add(x, y);  // GREEN stage

    // ASSERT
    Console.WriteLine($"Actual Result: {actualResult}, Expected Result: {expectedResult}");
    if (actualResult == expectedResult)
        Console.WriteLine("Test Passed");  // GREEN
    else
        Console.WriteLine("Test Failed");  // RED
}

// ------------------------- STEP 2: GREEN -------------------------
// GREEN stage: Implement the simplest code to make tests pass
// Our Add() method is enough to make all tests pass
// This is minimal code to satisfy the Red tests

// ------------------------- METHOD UNDER TEST -------------------------
int Add(int x, int y)
{
    return x + y;  // GREEN: Simple implementation that passes all tests
}

// ------------------------- STEP 3: REFACTOR -------------------------
// REFACTOR stage: Clean up code without changing behavior
// For example, we could write Add as expression-bodied method:
// int Add(int x, int y) => x + y;
// Tests would still pass, so our code is cleaner    you mean this