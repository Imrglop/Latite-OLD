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

// this should be namespace if c# is good with that
extern "C" LATITE_API void mod_zoom_setBind(char bind);
extern "C" LATITE_API void mod_zoom_setAmount(float amount);

// TODO export local player?
//extern "C" LATITE_API struct LocalPlayer;

// Functions

// Gets address from a multi-level pointer
ADDRESS GetMLPtrAddy(void* addy, vector<DWORD> offsets);

#define ADDRESS_FOV_BASEADDY 0x0369BD40
#define ADDRESS_FOV_SEMI_OFFSETS { 0x20, 0xC98, 0x68, 0x08, 0x1A0, 0x120 }

ADDRESS currentModuleBase();

HANDLE getHProcess();

#endif