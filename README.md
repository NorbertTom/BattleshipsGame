# BattleshipsGame

## Task description

Task description taken from <a href = "https://medium.com/guestline-labs/hints-for-our-interview-process-and-code-test-ae647325f400">here</a>.

The challenge is to program a simple version of the game Battleships (<a href = "https://www.youtube.com/watch?v=q0qpQ8doUp8">video</a>). 
Create an application to allow a single human player to play a <b>one-sided game of Battleships</b> against ships placed by the computer.

The program should create a 10x10 grid, and place several ships on the grid at random with the following sizes:

1x Battleship (5 squares)

2x Destroyers (4 squares)

The player enters or selects coordinates of the form “A5”, where “A” is the column and “5” is the row, to specify a square to target. 
Shots result in hits, misses or sinks. The game ends when all ships are sunk.

## How to build and run the project

### Running the game

To run the project you can use Visual Studio 2019 with .NET Core 3.1 Framework installed.
In that case you can open the solution file (BattleshipsGame.sln), open <i>Build</i> and choose <i>Build Solution</i> option.
Make sure BattleshipsGame project is marked as Startup project.
After that you can run it by hitting F5 or open <i>Debug</i> and choose <i>Start Debugging</i>.

Alternatively you can run the game from command line - make sure you enter BattleshipsGame folder (it has BattleshipGame.csproj file in it).
Then you can enter command 'dotnet run' and the program should build and run.

### Running the tests

In case you use Visual Studio 2019 you need to open BattleshipsGame.sln solution file, open <i>Test</i> and choose <i>Run All Tests</i>.

If you wish to run tests from command line you need to enter BattleshipsGameTests or BattleshipsEngineTests folder for
BattleshipsGame or BattleshipsEngine tests respectively. Then you can enter command 'dotnet test' and tests should run correctly.