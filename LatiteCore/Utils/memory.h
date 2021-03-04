#pragma once
#include "../dllmain.h"
namespace memory 
{
	// Gets address from a multi-level pointer
	ADDRESS GetMLPtrAddy(void* addy, std::vector<DWORD> offsets);
	// Designed to write static assembly code to Minecraft
	void WriteBytes(ADDRESS address, std::vector<unsigned char> bytes);
	// Reads raw array of byte
	std::vector<unsigned char> ReadMemoryRaw(ADDRESS address, unsigned long long size);
	// read 4 byte float
	float ReadFloat(ADDRESS address);
	byte ReadByte(ADDRESS address);
	// Reads ASCII format string with unknown size
	std::string ReadVarString(ADDRESS address, int maxSize = 20, char otherDelim = 0);
	// NOP code
	void Nop(ADDRESS address, unsigned long long amt);
}