#pragma once
#ifndef BASE_H

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

// Exports

extern "C" LATITE_API bool connectedToMinecraft(int type = 2);
extern "C" LATITE_API DWORD attach();
extern "C" LATITE_API void consoleMain();
extern "C" LATITE_API void detach();
extern "C" LATITE_API void loop();

extern "C" LATITE_API void setEnabled(unsigned int modId, bool enabled);

// this should be namespace if c# is good with that
extern "C" LATITE_API void mod_zoom_setBind(char bind);
extern "C" LATITE_API void mod_zoom_setAmount(float amount);
extern "C" LATITE_API void mod_lookBehind_setBind(char bind);

// Local Player
extern "C" LATITE_API float LPGetYMotion();
extern "C" LATITE_API float LPGetMotion();

extern "C" LATITE_API float LPGetXPos();
extern "C" LATITE_API float LPGetYPos();
extern "C" LATITE_API float LPGetZPos();

// TODO export local player?
//extern "C" LATITE_API struct LocalPlayer;

// Functions

// Gets address from a multi-level pointer
ADDRESS GetMLPtrAddy(void* addy, vector<DWORD> offsets);

#define ADDRESS_FOV_BASEADDY 0x0369BD40
#define ADDRESS_FOV_SEMI_OFFSETS { 0x20, 0xC98, 0x68, 0x08, 0x1A0, 0x120 }

#define ADDRESS_FSENS_BASEADDY 0x0369BD40
#define ADDRESS_FSENS_SEMI_OFFSETS { 0x20, 0xC00, 0x08, 0x0, 0x0 }
#define ADDRESS_FSENS_LAST_OFFSET 0x314

#define ADDRESS_FHH_BASEADDY 0x0369BD40
#define ADDRESS_FHH_SEMI_OFFSETS { 0x20, 0x9F8, 0x1D8, 0x08, 0xD10 }
#define ADDRESS_FHH_LAST_OFFSET 0x1E0

#define ADDRESS_Y_BASEADDY 0x03699238
#define ADDRESS_Y_SEMI_OFFSETS { 0x10, 0x128, 0x0, 0x138, 0x490, 0xc0 }
#define ADDRESS_Y_LAST_OFFSET 0x49C

#define ADDRESS_PRESPECTIVE_BASEADDY 0x0369BD40
#define ADDRESS_PRESPECTIVE_OFFSETS { 0x20, 0xE88, 0x1D8, 0x08, 0x20 }
#define ADDRESS_PRESPECTIVE_LAST_OFFSET 0x1E8

ADDRESS currentModuleBase();

HANDLE getHProcess();

#endif