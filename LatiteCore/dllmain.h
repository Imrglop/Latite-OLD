#pragma once

// Libraries

#include <Windows.h>
#include <WinUser.h>
#include <iostream>
#include <sstream>
#include <vector>

using std::vector;

// Macros / Types

// 64 Bit unsigned integer
typedef unsigned long long ADDRESS;
#ifndef LATITE_EXPORTS
#define LATITE_API __declspec(dllexport)
#else
#define LATITE_API __declspec(dllimport)
#endif
#define BASE_H
#define DEBUG_MODE TRUE
#define log std::cout
#define cstring char*

#define SETTINGS_TXT_DEFAULT "#\n# Settings File\n#\n\n# (For debugging) this will determine if console will be enabled every time \n# you attach launch. Can also be edited in the GUI/app itself but this one\n# will save\n\nconsole=false\n\n# This area is setting for offsets. you should leave enabled to false\n# if u want it to work on the latest version every update. But if you\n# are on a different version, place the offsets for your version here.\n\n# Warning: If you mess with those, it can crash the game or cause unexpected\n# behavior.\n\n# COMING SOON\noffsets_enabled=false\noffests=0,0,0,0,0"

// Exports

struct Settings {
public:
	int __ANCHORS[3];

	int __LOCATION_KEYSTROKES[2] = { 0, 0 };
	int __LOCATION_POSITION[2] = { 0, 0 };
	int __LOCATION_TOGGLE_SPRINT[2] = { 0, 0 };
};

// Api Functions

extern "C" {

	LATITE_API bool connectedToMinecraft(int type = 2);
	LATITE_API DWORD attach();
	LATITE_API void consoleMain();
	LATITE_API void detach();
	LATITE_API void loop();

	LATITE_API void setEnabled(unsigned int modId, bool enabled);

	// this should be namespace if c# is good with that
	LATITE_API void mod_zoom_setBind(char bind);
	LATITE_API void mod_zoom_setAmount(float amount);
	LATITE_API void mod_lookBehind_setBind(char bind);

	LATITE_API void setTimeChangerSetting(int setting);

	// Local Player
	LATITE_API float LPGetYMotion();
	LATITE_API float LPGetMotion();

	LATITE_API float LPGetXPos();
	LATITE_API float LPGetYPos();
	LATITE_API float LPGetZPos();

	LATITE_API int* LPGetLookAtBlock();

	// Config
	LATITE_API void settingsConfigSet(cstring k, cstring v);
	LATITE_API void settingsConfigGet(cstring k, LPWSTR* os);

	LATITE_API int getCurrentGui();

	// Silver Link (data.bin)
	LATITE_API int SilverNextInt(bool* status = 0);
	LATITE_API byte SilverNextByte(bool* status = 0);
	LATITE_API double SilverNextDouble(bool* status = 0);
	LATITE_API void SilverClear();
	LATITE_API void SilverJump(unsigned int pos = 1);
	LATITE_API void SilverInsertInt(int val);
	LATITE_API void SilverInsertByte(byte val);
	LATITE_API void SilverInsertDouble(double val);
	LATITE_API unsigned __int64 SilverGetFileSize();
}

// code

// these are to be updated every Minecraft update

// pointer to fov
#define ADDRESS_FOV_BASEADDY 0x0369BD40
#define ADDRESS_FOV_SEMI_OFFSETS { 0x20, 0xC98, 0x68, 0x08, 0x1A0, 0x120 }

// pointer to sensitivity
#define ADDRESS_FSENS_BASEADDY 0x0369BD40
#define ADDRESS_FSENS_SEMI_OFFSETS { 0x20, 0xFA0, 0x1A8, 0xC78, 0x200, 0x48 }
#define ADDRESS_FSENS_LAST_OFFSET 0x14

// pointer to hide hand
#define ADDRESS_FHH_BASEADDY 0x0369BD40
#define ADDRESS_FHH_SEMI_OFFSETS { 0x20, 0x9F8, 0x1D8, 0x08, 0xD10 }
#define ADDRESS_FHH_LAST_OFFSET 0x1E0

// pointer to Y lower coordinate
#define ADDRESS_Y_BASEADDY 0x03699238
#define ADDRESS_Y_SEMI_OFFSETS { 0x10, 0x128, 0x0, 0x138, 0x490, 0xc0 }
#define ADDRESS_Y_LAST_OFFSET 0x49C

// pointer to F3 prespective
#define ADDRESS_PRESPECTIVE_BASEADDY 0x0369BD40
#define ADDRESS_PRESPECTIVE_OFFSETS { 0x20, 0xE88, 0x1D8, 0x08, 0x20 }
#define ADDRESS_PRESPECTIVE_LAST_OFFSET 0x1E8

// address to assembly code that checks if you're holding CTRL before sprinting
#define ADDRESS_STATIC_SPRINT_CODE 0x1618D8F

// pointer to time of day client side
// [1.16.201]
#define ADDRESS_TIME_BASEADDY 0x036A1FB0
#define ADDRESS_TIME_OFFSETS { 0x0, 0x8F0, 0x28, 0x10, 0x7F8, 0x0 }
#define ADDRESS_TIME_LAST_OFFSET 0x5D0

// pointer to server IP
// [1.16.201]
#define ADDRESS_SERVER_BASEADDY 0x36A1FB0
#define ADDRESS_SERVER_OFFSETS { 0x0, 0x518, 0x10, 0x0, 0x1E8, 0x380 }
#define ADDRESS_SERVER_LAST_OFFSET 0x0

// pointer to the (address near) GUI opened
// [1.16.201]
#define ADDRESS_GUI_BASEADDY 0x03653A48
//#define ADDRESS_GUI_OFFSETS
#define ADDRESS_GUI_OFFSET 0xAEBC
#define ADDRESS_GUI_STRING_OFFSET 1048

// pointer to lookat block
// [1.16.201]
#define ADDRESS_LOOKAT_BASEADDY 0x03699028
#define ADDRESS_LOOKAT_OFFSETS { 0x10, 0x1F0, 0x0, 0x138, 0x358 }
#define ADDRESS_LOOKAT_LAST_OFFSET 0x9A0

// pointer to brightness
#define ADDRESS_BRIGHTNESS_BASEADDY 0x0369BD40
#define ADDRESS_BRIGHTNESS_OFFSETS { 0x20, 0xFF0, 0x1D8, 0x8, 0x138 }
#define ADDRESS_BRIGHTNESS_LAST_OFFSET 0x1E8

// functions

// Gets starting address of Minecraft
ADDRESS currentModuleBase();
// Gets the process of Minecraft
HANDLE getHProcess();