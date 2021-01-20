#pragma once
#ifndef BASE_H

// Libraries

#include <Windows.h>
#include <WinUser.h>
#include <iostream>
#include <sstream>

// Macros

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

#endif