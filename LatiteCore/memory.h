#pragma once
#include "dllmain.h"
namespace memory 
{
	// Gets address from a multi-level pointer
	ADDRESS GetMLPtrAddy(void* addy, vector<DWORD> offsets);
	// Designed to write static assembly code to Minecraft
	void WriteBytes(ADDRESS address, vector<unsigned char> bytes);
	// Reads raw array of byte
	vector<unsigned char> ReadMemoryRaw(ADDRESS address, unsigned long long size);
	// read 4 byte float
	float ReadFloat(ADDRESS address);
	byte ReadByte(ADDRESS address);
	// Reads ASCII format string with unknown size
	std::string ReadVarString(ADDRESS address, int maxSize = 20);
}