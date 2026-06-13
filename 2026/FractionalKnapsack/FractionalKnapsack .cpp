// filename: fractionalKnapsack.cpp
#include <iostream>
#include <algorithm>
#include <vector>
using namespace std;

struct Item {
    int iNo;
    float weight;
    float benefit;
    float value;
};

void printItems(vector<Item>& items) {
    cout << "Item\tWeight\tBenefit\tValue\n";
    for (int i = 0; i < items.size(); i++)
        cout << items[i].iNo << "\t" << items[i].weight << "\t"
             << items[i].benefit << "\t" << items[i].value << endl;
}

bool sortByValDesc(const Item &itm1, const Item &itm2) {
    return itm1.value > itm2.value;
}

int main() {
    int maxW, n;
    maxW = 20;
    n = 7;

    vector<Item> items(n);
    items[0].weight = 7;  items[0].benefit = 70;
    items[1].weight = 4;  items[1].benefit = 16;
    items[2].weight = 3;  items[2].benefit = 45;
    items[3].weight = 9;  items[3].benefit = 45;
    items[4].weight = 8;  items[4].benefit = 40;
    items[5].weight = 4;  items[5].benefit = 80;
    items[6].weight = 5;  items[6].benefit = 10;

    // Compute value density (benefit / weight) — the greedy criterion
    for (vector<Item>::size_type i = 0; i < n; i++) {
        items[i].iNo = i;
        items[i].value = items[i].benefit / items[i].weight;
    }

    printItems(items);
    sort(items.begin(), items.end(), sortByValDesc);
    cout << "\n\nAfter sort based on value:\n";
    printItems(items);
    cout << "\n\n";

    int currentItem = 0;
    float totalW   = 0;       // ← use float for fractional support
    float totalBen = 0;
    float remW     = maxW;    // ← FIXED: was uninitialized in original

    // ── WHILE: take full items as long as they fit ──────────────────
    while ((totalW < maxW) && (currentItem < n) &&
           (items[currentItem].weight <= remW))
    {
        // Include the full current item
        totalW   += items[currentItem].weight;
        totalBen += items[currentItem].benefit;
        remW      = maxW - totalW;
        cout << "Take FULL item " << items[currentItem].iNo
             << " (weight " << items[currentItem].weight
             << ", benefit " << items[currentItem].benefit << ")\n";
        currentItem++;
    }

    // ── IF: take a fraction of the next item to fill remaining space ─
    if (totalW < maxW && currentItem < n)
    {
        float fraction = remW / items[currentItem].weight;
        cout << "Take FRACTION " << fraction << " of item "
             << items[currentItem].iNo
             << " (weight " << fraction * items[currentItem].weight
             << " of " << items[currentItem].weight
             << ", benefit " << fraction * items[currentItem].benefit << ")\n";
        totalW   += fraction * items[currentItem].weight;  // = remW
        totalBen += fraction * items[currentItem].benefit;
    }

    cout << "\nMaximum total benefit = " << totalBen;
    cout << "\nTotal weight = " << totalW << endl;
    return 0;
}