#include "LocalPlayer.h"
#include "dllmain.h"

float LocalPlayer::getFOV() 
{
	auto fovAddress = GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_FOV_BASEADDY), ADDRESS_FOV_SEMI_OFFSETS) + 0x1E8;
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
	auto fovAddress = GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_FOV_BASEADDY), ADDRESS_FOV_SEMI_OFFSETS) + 0x1E8;
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
