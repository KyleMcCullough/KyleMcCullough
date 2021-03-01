//
// Created by kyleg on 2/20/2021.
//

#include "Stack.h"

void Stack::Push(int x, int y) {

    // Create new node and save information.
    Node* node = new Node();
    node->position.x = x;
    node->position.y = y;
    node->prev = last;

    // If it is the first node, save it to first.
    if (first == nullptr) {
        first = node;
    }

    // If it is not first, add it to last.
    else {
        last->next = node;
    }

    // Set last to the node.
    last = node;
}

Position Stack::Pop() {

    if (first != nullptr) {
        Node* node = last;

        last = last->prev;

        if (last != nullptr) {

            // Sets to the nodes next to the old last's next. Should point to nullptr.
            last->next = node->next;
        }

        if (node == first) {
            first = nullptr;
        }

        // Grabs position before deleting node, then returns it.
        Position temp = node->position;

        delete node;
        return temp;
    }
    return {};
}

Position Stack::Peek() {
    if (last != nullptr) {
        return last->position;
    }

    return {};
}
