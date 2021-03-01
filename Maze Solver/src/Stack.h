//
// Created by kyleg on 2/20/2021.
//

#ifndef ASSIGNMENT_2_STACK_H
#define ASSIGNMENT_2_STACK_H
#include "Node.h"

class Stack {
private:
    Node* first;
    Node* last;

public:
    Stack() : first(nullptr), last(nullptr) {}

    void Push(int x, int y);
    Position Pop();
    Position Peek();

};


#endif //ASSIGNMENT_2_STACK_H
