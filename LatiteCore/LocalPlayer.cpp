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

std::string LocalPlayer::getUsername()
{
	ADDRESS yPositionAddy = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_Y_BASEADDY), ADDRESS_Y_SEMI_OFFSETS) + ADDRESS_Y_LAST_OFFSET;
	ADDRESS nameAddy = yPositionAddy + 996;
	return memory::ReadVarString(nameAddy);
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
	if (yAddy == 0) return false;
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

void LocalPlayer::setTime(int time)
{
	//log << "Setting time to " << time << '\n';
	ADDRESS addy = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_TIME_BASEADDY), ADDRESS_TIME_OFFSETS) + ADDRESS_TIME_LAST_OFFSET;
	if (addy != 0)
		WriteProcessMemory(getHProcess(), (void*)addy, &time, sizeof(time), NULL);
}

std::string LocalPlayer::getServer()
{
	ADDRESS addy = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_SERVER_BASEADDY), ADDRESS_SERVER_OFFSETS) + ADDRESS_SERVER_LAST_OFFSET;
	if (addy == 0) return "N/A";
	return memory::ReadVarString(addy, 30); // get ip address
}

std::string LocalPlayer::getUIState()
{
	ADDRESS uiStateNear = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_GUI_BASEADDY), {}) + ADDRESS_GUI_OFFSET;
	//log << "UI state addy (near address): " << (void*)uiState << '\n';
	ADDRESS uiStateString = uiStateNear + ADDRESS_GUI_STRING_OFFSET;
	return memory::ReadVarString(uiStateString, 30, '\n');
}

bool LocalPlayer::UIOpen() {
	return getUIState() != "hud_screen";
}

int* LocalPlayer::getLookAtBlock()
{
	if (!isInGame()) return NULL;
	ADDRESS addy = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_LOOKAT_BASEADDY), ADDRESS_LOOKAT_OFFSETS) + ADDRESS_LOOKAT_LAST_OFFSET;
	if (addy == 0) return NULL;
	int* ints = new int[3];
	int written = ReadProcessMemory(getHProcess(), (void*)addy, &ints[0], sizeof(int) * 3, NULL);
	if (written != 1) return NULL;
	return ints;
}

float LocalPlayer::getBrightness()
{
	ADDRESS addy = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_BRIGHTNESS_BASEADDY), ADDRESS_BRIGHTNESS_OFFSETS) + ADDRESS_BRIGHTNESS_LAST_OFFSET;
	float bright = 0.f;
	ReadProcessMemory(getHProcess(), (void*)addy, &bright, sizeof(bright), NULL);
	return bright;
}

void LocalPlayer::setBrightness(float bright)
{
	ADDRESS addy = memory::GetMLPtrAddy((void*)(currentModuleBase() + ADDRESS_BRIGHTNESS_BASEADDY), ADDRESS_BRIGHTNESS_OFFSETS) + ADDRESS_BRIGHTNESS_LAST_OFFSET;
	WriteProcessMemory(getHProcess(), (void*)addy, &bright, sizeof(bright), NULL);
}