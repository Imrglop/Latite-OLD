#include <vector>
using std::vector;
typedef unsigned char byte;

namespace utils {
    template <typename T>
    T getItemFromBytes(byte* bytes) { return *((T*)bytes); };

    template <typename T>
    vector<byte> getBytes(T val) {
        vector<byte> retVal;
        byte* pbyte = (byte*)&val;
        for (size_t i = 0; i < sizeof(val); i++) {
            retVal.push_back(*(pbyte + i));
        }
        return retVal;
    }
}