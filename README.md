# Blackjack Game

This is a console-based Blackjack game implemented in C#. The game is built on .NET 6.0 and follows the standard rules of Blackjack.

## Features

- Multiple Players: The game supports multiple players playing against a dealer. Each player is welcomed at the start of the game and asked for their name and the amount they are willing to play with.

- Game Loop: The game continues in loops, allowing players to play multiple rounds until they decide to quit.

- Player Actions: During their turn, each player can choose to hit (draw a card) or stand (end their turn).

- Game State Tracking: The game keeps track of each player's chips, wins, losses, and draws. It also tracks the state of the game (in progress, dealer's turn, ended) and the result of each match (win, loss, draw).

## Code Structure

The codebase is organized into several classes, each responsible for a specific part of the game:

- `Program`: This is the entry point of the application. It creates a new instance of the `GameArea` class to start the game.

- `GameArea`: This class represents the game area where the game takes place. It manages the players and the dealer, and controls the game loop.

- `Player` and `Dealer`: These classes represent the players and the dealer. They inherit from the `Person` class and have properties like name, hand of cards, and methods to perform actions like hit or stand.

- `Interactions`: This class handles all interactions with the players, such as welcoming players, asking for player actions, and displaying match results.

- `Match`: This class represents a match between a player and the dealer. It manages the deck of cards and controls the flow of the match.

- `Hand` and `Card`: These classes represent a hand of cards and a single card, respectively. The `Hand` class has a list of `Card` objects and can calculate the value of the hand.

## How to Build and Run

1. Clone the repository to your local machine.
2. Navigate to the project directory (where the .sln file is located).
3. Build the project using the .NET CLI:

```
dotnet build
```

4. Run the project:

```
dotnet run
```

## Prerequisites

- .NET 6.0 SDK

## Future Enhancements

The game is designed to be extensible. For example, you can add more features like betting, splitting, insurance, etc., by modifying the `Player` and `GameArea` classes. The game uses enums for game states and player actions, which makes it easy to add new states and actions if needed.
