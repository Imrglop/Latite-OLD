#include "memory.h"

vector<unsigned char> memory::ReadMemoryRaw(ADDRESS address, unsigned long long size)
{
    vector<unsigned char> retVal = { 0 };
    ReadProcessMemory(getHProcess(), (void*)address, &retVal[0], size, NULL);
    return retVal;
}

float memory::ReadFloat(ADDRESS address)
{
    try {
        auto rawMem = memory::ReadMemoryRaw(address, 4);
        float* ptr = (float*)&rawMem[0];
        return *ptr;
    }
    catch (std::exception e) {
        std::cerr << "Exception occured while reading float: " << e.what() << std::endl;
        return NAN;
    }
}

byte memory::ReadByte(ADDRESS address)
{
    auto rawMem = memory::ReadMemoryRaw(address, 1);
    return rawMem[0];
}


std::string memory::ReadVarString(ADDRESS address, int maxSize, char otherDelim)
{
    unsigned int size = 0;
    char val;
    vector<char> retVal = {};
    for (int i = 0; i < maxSize; i++)
    {
        val = 0;
        ReadProcessMemory(getHProcess(), (void*)(address + i), &val, 1, 0);
        if (val == 0) break;
        if (val == otherDelim) break;
        retVal.push_back(val);
    }
    return std::string(retVal.begin(), retVal.end());
}

void memory::Nop(ADDRESS address, unsigned long long amt)
{
    std::vector<byte> bytes;
    for (unsigned long long i = 0; i < amt; i++)
    {
        bytes.push_back(0x90);
    }
    memory::WriteBytes(address, bytes);
}

ADDRESS memory::GetMLPtrAddy(void* addy, vector<DWORD> offsets)
{
    ADDRESS ptrPoint = 0;

    if (ReadProcessMemory(getHProcess(), addy, &ptrPoint, sizeof(ptrPoint), NULL) != 0)
    {
        for (unsigned int i = 0; i < offsets.size(); i++)
        {
            ptrPoint = GetMLPtrAddy((void*)(ptrPoint + offsets[i]), {});
        }
        return ptrPoint;
    }
    return 0;
}

void memory::WriteBytes(ADDRESS address, vector<unsigned char> bytes)
{
    DWORD oldVp;
    auto hProcess = getHProcess();
    // be able to read/write code
    VirtualProtectEx(hProcess, (void*)address, bytes.size(), PAGE_EXECUTE_READWRITE, &oldVp);
    // write array of byte to process
    WriteProcessMemory(hProcess, (void*)address, &bytes[0], bytes.size(), 0);
    // set it back to the original
    VirtualProtectEx(hProcess, (void*)address, bytes.size(), oldVp, &oldVp);
}