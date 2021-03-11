#pragma once

// Libraries

#include <Windows.h>
#include <WinUser.h>
#include <iostream>
#include <sstream>
#include <vector>
#define assert(x) if (!(x)) return
// Macros / Types

// 64 Bit unsigned integer
typedef uintptr_t ADDRESS;
#ifndef LATITE_EXPORTS
#define LATITE_API __declspec(dllexport)
#else
#define LATITE_API __declspec(dllimport)
#endif
#define BASE_H
#define DEBUG_MODE TRUE
#define log std::cout<<"[Core] "
#define cstring char*

#define SETTINGS_TXT_DEFAULT "#\n# Settings File\n#\n\n# (For debugging) this will determine if console will be enabled every time \n# you attach launch. Can also be edited in the GUI/app itself but this one\n# will save\n\nconsole=false\n\n# This area is setting for offsets. you should leave enabled to false\n# if u want it to work on the latest version every update. But if you\n# are on a different version, place the offsets for your version here.\n\n# Warning: If you mess with those, it can crash the game or cause unexpected\n# behavior.\n\n# COMING SOON\noffsets_enabled=false\noffests=0,0,0,0,0"

// Api Functions

extern "C" {

	LATITE_API bool connectedToMinecraft(int type = 2);
	LATITE_API DWORD attach();
	LATITE_API void consoleMain();
	LATITE_API void detach();
	LATITE_API void loop();

	LATITE_API void setEnabled(unsigned int modId, bool enabled);

#pragma region Mods
	LATITE_API void mod_zoom_setBind(char bind);
	LATITE_API void mod_zoom_setAmount(float amount);
	LATITE_API void mod_lookBehind_setBind(char bind);
	LATITE_API void mod_freelook_setBind(char bind);
#pragma endregion
	LATITE_API void setTimeChangerSetting(int setting);
#pragma region LocalPlayer
	LATITE_API float LPGetYMotion();
	LATITE_API float LPGetMotion();

	LATITE_API float* LPGetPos();

	LATITE_API int* LPGetLookAtBlock();
	LATITE_API int getCurrentGui();
#pragma endregion
#pragma region Settings/Config
	LATITE_API void settingsConfigSet(cstring k, cstring v);
	LATITE_API void settingsConfigGet(cstring k, LPWSTR* os);
#pragma endregion
#pragma region SilverWrapper
	LATITE_API int SilverNextInt(bool* status = 0);
	LATITE_API byte SilverNextByte(bool* status = 0);
	LATITE_API double SilverNextDouble(bool* status = 0);
	LATITE_API void SilverClear();
	LATITE_API void SilverJump(unsigned int pos = 1);
	LATITE_API void SilverInsertInt(int val);
	LATITE_API void SilverInsertByte(byte val);
	LATITE_API void SilverInsertDouble(double val);
	LATITE_API unsigned __int64 SilverGetFileSize();
#pragma endregion
}

#pragma region Offsets
// these are to be updated every Minecraft update
// TODO: Make 1 pointer to the Actor/local player, so no need to get a pointer for every thing


// pointer to the local player
// [1.16.210]
#define GET_LOCALPLAYER() memory::GetMLPtrAddy((void*)(currentModuleBase() + 0x03B5B378), { 0x10, 0x20, 0xC8 })

// pointer to FOV
// [1.16.210]
#define ADDRESS_FOV_BASEADDY 0x037CB460
#define ADDRESS_FOV_SEMI_OFFSETS { 0x18, 0x130, 0x18 }

// pointer to sensitivity
// [1.16.210]
#define ADDRESS_FSENS_BASEADDY 0x037CB460
#define ADDRESS_FSENS_SEMI_OFFSETS { 0xAA8, 0x18, 0xC90, 0x30, 0x48 }
#define ADDRESS_FSENS_LAST_OFFSET 0x14

// pointer to hide hand
// [1.16.201]
#define ADDRESS_FHH_BASEADDY 0x0369BD40
#define ADDRESS_FHH_SEMI_OFFSETS { 0x20, 0x9F8, 0x1D8, 0x08, 0xD10 }
#define ADDRESS_FHH_LAST_OFFSET 0x1E0

// pointer to F3 perspective
// [1.16.210]
#define ADDRESS_PRESPECTIVE_BASEADDY 0x037CB460
#define ADDRESS_PRESPECTIVE_OFFSETS { 0x18, 0x30 }
#define ADDRESS_PRESPECTIVE_LAST_OFFSET 0x18

// address to assembly code that checks if you're holding CTRL before sprinting
// [1.16.201]
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
// [1.16.210]
#define ADDRESS_GUI_BASEADDY 0x03787148
//#define ADDRESS_GUI_OFFSETS
#define ADDRESS_GUI_OFFSET 0xAEBC
#define ADDRESS_GUI_STRING_OFFSET 1048

// pointer to lookat block
// [1.16.210] [FIXME: BROKEN]
#define ADDRESS_LOOKAT_BASEADDY 0x03B5B328
#define ADDRESS_LOOKAT_OFFSETS { 0x8, 0x8, 0x18, 0xB8, 0x358 }
#define ADDRESS_LOOKAT_LAST_OFFSET 0x948

// pointer to brightness
// [1.16.201]
#define ADDRESS_BRIGHTNESS_BASEADDY 0x0369BD40
#define ADDRESS_BRIGHTNESS_OFFSETS { 0x20, 0xFF0, 0x1D8, 0x8, 0x138 }
#define ADDRESS_BRIGHTNESS_LAST_OFFSET 0x1E8

// [1.16.201]
#define ADDRESS_STATIC_FREELOOK_CODE 0x1AB7E57
#define ADDRESS_STATIC_FREELOOK_CONTENT { 0x89, 0x01 }

// [1.16.201]
#define ADDRESS_STATIC_FREELOOK2_CODE 0x1ab7e62
#define ADDRESS_STATIC_FREELOOK2_CONTENT { 0x89, 0x87, 0x20, 0x01, 0x00, 0x00 }
#pragma endregion

// functions

// Gets starting address of Minecraft
ADDRESS currentModuleBase();
// Gets the process of Minecraft
HANDLE getHProcess();