#include <iostream>
#include <errno.h>
#include <fstream>
#include <string.h>
#include <string>
#include "utils.hh"

using std::cin;
using std::cout;
using std::string;
using std::fstream;
using std::ofstream;
using std::ifstream;

void intAt(ifstream file, size_t ln = 0) {
    
}

int main(int argc, char** argv) {
    ofstream outFile;
    string fileName = "";
    int itemToConvert = 0;
    if (argc < 2) fileName = "set.bin";
    else fileName = (string)argv[1] + ".bin";
    try {
        if (argc >= 3) itemToConvert = std::stoi(argv[2]);
    } catch (std::exception) {
        itemToConvert = 0;
    }

    outFile.open(fileName);
    if (outFile.fail()) {
        std::cerr << "Error: could not open file: " << errno << "\n";
        return EXIT_FAILURE;
    }
    auto bytes = utils::getBytes(itemToConvert);
    for (size_t i = 0; i < bytes.size(); i++)
    {
        std::cout << (int)bytes[i] << '\n';
        outFile << bytes[i];
    }
    outFile.close();
    cout << "hi\n";
    return 0;
}