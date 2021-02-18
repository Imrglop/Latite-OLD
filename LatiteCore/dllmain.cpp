/*
 *
 * Latite - A minecraft: Windows 10 Edition PVP mod.
 * Copyright (c) 2021 Imrglop
 *
*/

#include "dllmain.h"
#include <TlHelp32.h>
#include <tchar.h>
#include "Mods/ModManager.h"
#include "./Mods/Zoom.h"
#include <stdlib.h>
#include "memory.h"

#include "Config.h"

bool connected;

DWORD pID;

ADDRESS moduleBase;
HANDLE hProcess;

int timeChangerSetting = 0;
Config settings("settings.txt", SETTINGS_TXT_DEFAULT);

HANDLE GetProcessByName(const char* processName)
{
    PROCESSENTRY32 pe32;
    DWORD pID = 0ul;
    DWORD _err;
    ZeroMemory(&pe32, sizeof(PROCESSENTRY32));
    pe32.dwSize = sizeof(PROCESSENTRY32);
    HANDLE snap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

    if (snap == INVALID_HANDLE_VALUE) {
        printf("Error occured! (0x%x)", GetLastError());
        return NULL;
    }
    if (Process32First(snap, &pe32) == FALSE)
    {
        _err = GetLastError();
        CloseHandle(snap);
        return NULL;
    }
    do {
        //PROCESS_ALL_ACCESS;
        hProcess = OpenProcess(PROCESS_VM_OPERATION |
            PROCESS_VM_READ |
            PROCESS_VM_WRITE,
            FALSE, pe32.th32ProcessID);
        // Grant perms

        if (hProcess != 0)
        {
            // Compare processes with processName
            if (strcmp(pe32.szExeFile, processName) == 0) {
                CloseHandle(snap);
                return hProcess;
            }
            CloseHandle(hProcess);
        }
    } while (Process32Next(snap, &pe32) != 0);
    CloseHandle(snap);
    return NULL;
}

ADDRESS GetModuleBase(DWORD pID, wchar_t* moduleName)
{
    DWORD _err;
    ADDRESS _moduleBase = 0ui64;
    HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE | TH32CS_SNAPMODULE32, pID);
    if (hSnapshot != INVALID_HANDLE_VALUE)
    {
        MODULEENTRY32W moduleEntry32;
        moduleEntry32.dwSize = sizeof(MODULEENTRY32W);
        if (Module32FirstW(hSnapshot, &moduleEntry32)) {
            do {
                if (_wcsicmp(moduleEntry32.szModule, moduleName) == 0) {
                    // found match
                    _moduleBase = (ADDRESS)moduleEntry32.modBaseAddr;
                    break;
                }
            } while (Module32NextW(hSnapshot, &moduleEntry32));
        }
        CloseHandle(hSnapshot);
    }
    else {
        _err = GetLastError();
        log << "CreateTH32Snapshot failed! error: " << _err << '\n';
    }
    return _moduleBase;
}

void detach() 
{
    Mod::disableAll();
}

void mod_zoom_setBind(char bind)
{
    getZoomModule().setBind(bind);
}

void mod_lookBehind_setBind(char bind)
{
    getLookBehindModule().setBind(bind);
}

float LPGetMotion()
{
    ADDRESS yAddy = memory::GetMLPtrAddy((void*)(moduleBase + ADDRESS_Y_BASEADDY),
        ADDRESS_Y_SEMI_OFFSETS) + ADDRESS_Y_LAST_OFFSET;
    float vel = 0.f;
    ReadProcessMemory(hProcess, (void*)(yAddy - 0x16C), &vel, sizeof(vel), 0);
    return vel;
}

float LPGetYMotion()
{
    // y position address
    ADDRESS yAddy = memory::GetMLPtrAddy((void*)(moduleBase + ADDRESS_Y_BASEADDY),
        ADDRESS_Y_SEMI_OFFSETS) + ADDRESS_Y_LAST_OFFSET;
    float yVel = 0.f;
    ADDRESS yVelAddy = yAddy + 60;
    ReadProcessMemory(hProcess, (void*)yVelAddy, &yVel, sizeof(yVel), 0);
    return yVel;
}

float LPGetYPos()
{
    ADDRESS addy = memory::GetMLPtrAddy((void*)(moduleBase + ADDRESS_Y_BASEADDY),
        ADDRESS_Y_SEMI_OFFSETS) + ADDRESS_Y_LAST_OFFSET;
    float pos = 0.f;
    ReadProcessMemory(hProcess, (void*)addy, &pos, sizeof(pos), 0);
    return pos;
}

float LPGetXPos()
{
    ADDRESS addy = memory::GetMLPtrAddy((void*)(moduleBase + ADDRESS_Y_BASEADDY),
        ADDRESS_Y_SEMI_OFFSETS) + ADDRESS_Y_LAST_OFFSET;
    addy -= 4; // 1 float value (4 bytes) right before to the y position
    float pos = 0.f;
    ReadProcessMemory(hProcess, (void*)addy, &pos, sizeof(pos), 0);
    return pos;
}

float LPGetZPos()
{
    ADDRESS addy = memory::GetMLPtrAddy((void*)(moduleBase + ADDRESS_Y_BASEADDY),
        ADDRESS_Y_SEMI_OFFSETS) + ADDRESS_Y_LAST_OFFSET;
    addy += 4; // 1 float value (4 bytes) right after to the y position
    float pos = 0.f;
    ReadProcessMemory(hProcess, (void*)addy, &pos, sizeof(pos), 0);
    return pos;
}

int* LPGetLookAtBlock()
{
    return LocalPlayer::getLookAtBlock();
}

void settingsConfigSet(cstring k, cstring v)
{
    settings.set(k, v);
}

void settingsConfigGet(cstring k, LPWSTR* os) {
    std::cout << "From: " << k << '\n';
    std::cout << (unsigned __int64)k << '\n';
    std::string s = settings.getString(k);
}

int getCurrentGui()
{
    string name = LocalPlayer::getUIState();
    if (name == "hud_screen") return 0;
    if (name == "pause_screen") return 1;
    if (name == "in_game_play_screen") return 2;
    if (name == "inventory_screen") return 3;
    if (name == "chat_screen") return 4;
    return -1;
}

void mod_zoom_setAmount(float amount)
{
    getZoomModule().setFovAmount(amount);
}

ADDRESS currentModuleBase()
{
    return moduleBase;
}

HANDLE getHProcess()
{
    return hProcess;
}

void consoleMain() {
    AllocConsole(); // make console
    FILE* f;
    freopen_s(&f, "CONOUT$", "w", stdout); // open console output
    SetConsoleTitle(_T("Latite Console"));
}

bool connectedToMinecraft(int type)
{
    if (type == 2)
    {
        return connected;
    }
    if (type == 1 || type == 0)
    {
        connected = (bool)type;
    }
    return false;
}

int test() {
    return 21394;
}

DWORD attach() {
    // attach to Minecraft
    hProcess = GetProcessByName("Minecraft.Windows.exe");
    log << "HProcess: " << hProcess << '\n';
    pID = GetProcessId(hProcess);
    moduleBase = GetModuleBase(pID, (WCHAR*)L"Minecraft.Windows.exe");
    if (hProcess == 0) return GetLastError();
    log << "Module Base: " << (void*)moduleBase << '\n';
    if (moduleBase == 0ui64) return GetLastError();
    log << "[test] Server player in: " << LocalPlayer::getServer() << '\n';
    
    settings.load();
    if (settings.getBool("console")) {
        consoleMain();
    }
    Mod::initialize();
    return 0;
}


void loop()
{
    if (connectedToMinecraft())
    {
        if (GetForegroundWindow() == FindWindowA(NULL, "Minecraft"))
        {
            Mod::tickModules();
        }
    }
}

void setTimeChangerSetting(int setting)
{
    timeChangerSetting = setting;
}

void setEnabled(unsigned int modId, bool enabled)
{
    log << "set enabled " << modId << " to " << enabled << '\n';
    switch (modId)
    {
    case 1: //zoom
        log << "action on Zoom\n";
        if (!enabled)
            getZoomModule().onDisable();
        else
            getZoomModule().onEnable();
        break;
    case 2: //lookbehind
        log << "action on LookBehind\n";
        if (!enabled)
            getLookBehindModule().onDisable();
        else
            getLookBehindModule().onEnable();
        break;
    case 3: // togglesprint
        log << "action on Toggle Sprint\n";
        if (!enabled)
            getToggleSprintModule().onDisable();
        else
            getToggleSprintModule().onEnable();
        break;
    case 4: //timechnager
        log << "action on Time Changer\n";
        if (!enabled)
            getTimeChangerModule().onDisable();
        else
            getTimeChangerModule().onEnable(timeChangerSetting);
    case 5:
        if (enabled)
            getFullbrightModule().onEnable();
        else
            getFullbrightModule().onDisable();
    }
}

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    if (ul_reason_for_call == DLL_PROCESS_ATTACH)
    {
    }
    return TRUE;
}

