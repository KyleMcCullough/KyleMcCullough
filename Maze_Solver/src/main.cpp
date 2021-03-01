#include <iostream>
#include <fstream>
#include "Stack.h"
#include <string>


using namespace std;

// Constants for maze defining items.
const int mazeWidth = 51;
const int mazeLength = 51;

void LoadMaze(char mazeValues[][mazeWidth], const string& mazeName);
void SaveMazeSolution(char mazeValues[][mazeWidth], const string& mazeName);

int main() {

    const string mazeName = "Testing/test3.txt";
    const char invalidPathIndicator = 'N';
    Stack stack;

    char mazeCharacters[mazeLength][mazeWidth];
    LoadMaze(mazeCharacters, mazeName);

    // Pushes the initial starting position.
    stack.Push(0, 1);

    int x = 0;
    int y = 1;
    bool yBlocked;
    bool xBlocked;

    // Continues until the end is reached.
    while (true) {
        yBlocked = false;
        xBlocked = false;

        // Checks if pathing X can go to the right. Creates a weighted bias towards the right.
        if (mazeCharacters[x + 1][y] == ' ') {
            mazeCharacters[x + 1][y] = 'X';
            x++;
            stack.Push(x, y);
        }

        else if (mazeCharacters[x - 1][y] == ' ') {
            mazeCharacters[x - 1][y] = 'X';
            x--;
            stack.Push(x, y);
        }

        else {
            xBlocked = true;
        }

        // Checks if pathing Y can go down. This makes a weighed bias towards going downward.
        if (mazeCharacters[x][y + 1] == ' ') {
            mazeCharacters[x][y + 1] = 'X';
            y++;
            stack.Push(x, y);
        }

        else if (mazeCharacters[x][y - 1] == ' ') {
            mazeCharacters[x][y - 1] = 'X';
            y--;
            stack.Push(x, y);
        }

        else {
            yBlocked = true;
        }

        // Only happens if both axis's are unable to move... aka means a dead end.
        // Reverts to last position, and sets the position it was in before with a special
        // character so it doesn't go there again.
        if (yBlocked && xBlocked) {

            Position currentPos = stack.Pop();
            Position lastPos = stack.Peek();

            mazeCharacters[lastPos.x][lastPos.y] = 'X';
            x = lastPos.x;
            y = lastPos.y;

            mazeCharacters[currentPos.x][currentPos.y] = invalidPathIndicator;
        }

        // Breaks if the bottom right is reached.
        if (x == 49 && y == 50) {
            break;
        }
    }

    // Prints the solution and removes all invalid path icons if required.
    for (auto & row : mazeCharacters) {
        for (char & character : row) {
            if (character == invalidPathIndicator) {
                character = ' ';
            }

            cout << character;
        }
        cout << endl;
    }

    SaveMazeSolution(mazeCharacters, mazeName);
    cout << "Solution has been saved." << endl;
    return 0;
}

void LoadMaze(char mazeValues[][mazeWidth], const string& mazeName) {

    ifstream file(mazeName);
    string line;

    // Returns if the file is invalid.
    if (!file.is_open()) {
        return;
    }

    // Loads each character into the array.
    for (int x = 0; x < mazeLength; ++x) {

        getline(file, line);
        for (int y = 0; y < line.size(); ++y) {
            mazeValues[x][y] = line.at(y);
        }
    }

    file.close();
}

void SaveMazeSolution(char mazeValues[][mazeWidth], const string& mazeName) {

    // Gets the file name without the extension, and adds solution to its name.
    ofstream file(mazeName.substr(0, mazeName.find('.')) + "_solution.txt");

    for (int x = 0; x < mazeLength; ++x) {
        for (int y = 0; y < mazeWidth; ++y) {

            file << mazeValues[x][y];
        }
        file << endl;
    }

    file.close();
}