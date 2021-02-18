#include <vector>
#include <sstream>

using std::vector;
using std::string;

namespace utils {
    std::vector<std::string> splitString(std::string str, char delim);
    int indexOf(std::string str, char ch, int ignore = -1);
    int lastIndexOf(std::string str, char ch);
}