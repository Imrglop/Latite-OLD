#include <vector>
#include <sstream>

using std::vector;
using std::string;

namespace utils {
    std::vector<std::string> splitString(std::string str, char delim) {
        vector<std::string> retVal = {};
        std::istringstream split(str);
        for (std::string each; std::getline(split, each, delim); retVal.push_back(each));
        return retVal;
    }
    int indexOf(std::string str, char ch, int ignore = -1) {
        for (int i = 0; i < str.size(); i++)
        {
            if (str[i] == ch) {
                if (i <= ignore) {
                    //std::cout << "I: " << i << "\nIgnore: " << ignore <<"\n"; 
                    continue;
                };
                return i;
            }
        }
        return -1;
    }
    int lastIndexOf(std::string str, char ch) {
        int final = -1;
        for (int i = 0; i < str.size(); i++)
        {
            if (str[i] == ch) {
                final = i;
            }
        }
        return final;
    }
}