#include "LocalPlayer.h"
#include "dllmain.h"
#include "memory.h"

float LocalPlayer::getFOV() 
{
	auto fovAddress = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_FOV_BASEADDY), ADDRESS_FOV_SEMI_OFFSETS) + 0x1E8;
	if (fovAddress != 0)
	{
		float fovVal = 0.f;
		ReadProcessMemory(getHProcess(), (void*)fovAddress, &fovVal, sizeof(fovVal), NULL);
		return fovVal;
	}
	else
	{
		log << "Fov address is 0 will not get fov.\n";
		return 0.f;
	}
}

void LocalPlayer::setFOV(float fov)
{
	auto fovAddress = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_FOV_BASEADDY), ADDRESS_FOV_SEMI_OFFSETS) + 0x1E8;
	if (fovAddress != 0)
	{
		bool w = WriteProcessMemory(getHProcess(), (void*)fovAddress, &fov, sizeof(fov), 0);
		if (!w)
		{
			log << "WPM failed! LastError: " << w << '\n';
		}
	}
	else
	{
		log << "Fov address is 0 will not set fov.\n";
	}
}

void LocalPlayer::setSensitivity(float sens)
{
	auto sensAddress = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_FSENS_BASEADDY),
		ADDRESS_FSENS_SEMI_OFFSETS) + ADDRESS_FSENS_LAST_OFFSET;
	if (sensAddress == 0) return;
	WriteProcessMemory(getHProcess(), (void*)sensAddress, &sens, sizeof(sens), NULL);
}

float LocalPlayer::getSensitivity()
{
	float val = 0;
	auto sensAddress = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_FSENS_BASEADDY),
		ADDRESS_FSENS_SEMI_OFFSETS) + ADDRESS_FSENS_LAST_OFFSET;
	if (sensAddress == 0) return 0.f;
	ReadProcessMemory(getHProcess(), (void*)sensAddress, &val, sizeof(val), NULL);
	return val;
}

unsigned char LocalPlayer::getHideHand()
{
	auto hhAddress = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_FHH_BASEADDY), ADDRESS_FHH_SEMI_OFFSETS) + ADDRESS_FSENS_LAST_OFFSET;
	unsigned char val = 0;
	ReadProcessMemory(getHProcess(), (void*)hhAddress, &val, sizeof(val), NULL);
	return val;
}

void LocalPlayer::setHideHand(unsigned char val)
{
	auto hhAddress = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_FHH_BASEADDY), ADDRESS_FHH_SEMI_OFFSETS) + ADDRESS_FHH_LAST_OFFSET;
	if (!WriteProcessMemory(getHProcess(), (void*)hhAddress, &val, sizeof(val), NULL))
	{
		log << "WPM error while setting Hide Hand to " << (int)val << ": " << GetLastError() << '\n';
	};
}

bool LocalPlayer::isInGame()
{
	// check if the Y position address is initialized
	ADDRESS yAddy = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_Y_BASEADDY), ADDRESS_Y_SEMI_OFFSETS) + ADDRESS_Y_LAST_OFFSET;
	if ((void*)yAddy == nullptr) return false;
	return true;
}

unsigned char LocalPlayer::getPerspective()
{
	unsigned char retVal = 0;
	ADDRESS pAddy = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_PRESPECTIVE_BASEADDY), ADDRESS_PRESPECTIVE_OFFSETS) + ADDRESS_PRESPECTIVE_LAST_OFFSET;
	if (pAddy != 0)
		ReadProcessMemory(getHProcess(), (void*)pAddy, &retVal, sizeof(retVal), NULL);
	return retVal;
}


void LocalPlayer::setPerspective(unsigned char val)
{
	ADDRESS pAddy = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_PRESPECTIVE_BASEADDY), ADDRESS_PRESPECTIVE_OFFSETS) + ADDRESS_PRESPECTIVE_LAST_OFFSET;
	if (pAddy != 0)
		WriteProcessMemory(getHProcess(), (void*)pAddy, &val, sizeof(val), NULL);
}
