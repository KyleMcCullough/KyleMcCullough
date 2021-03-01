//
// Created by kyleg on 1/27/2021.
//

#ifndef ASSIGNMENT1_LINKEDLISTNODE_H
#define ASSIGNMENT1_LINKEDLISTNODE_H

#include <iostream>
#include "Position.h"

class Node {
public:
    Position position;
    Node* next;
    Node* prev;

    Node() : position(), next(nullptr), prev(nullptr) {}
};


#endif //ASSIGNMENT1_LINKEDLISTNODE_H
