/*
Latite - Minecraft PVP Mod
by Imrglop
*/

#include "dllmain.h"
#include <TlHelp32.h>
#include <tchar.h>
#include "Mods/ModManager.h"
#include "./Mods/Zoom.h"
#include <stdlib.h>

bool connected;

DWORD pID;

ADDRESS moduleBase;
HANDLE hProcess;

HANDLE GetProcessByName(WCHAR* processName)
{
    PROCESSENTRY32 pe32;
    DWORD pID = 0ul;
    DWORD _err;
    ZeroMemory(&pe32, sizeof(PROCESSENTRY32));
    pe32.dwSize = sizeof(PROCESSENTRY32);
    HANDLE snap = CreateToolhelp32Snapshot(TH32CS_SNAPPROCESS, 0);

    if (snap == INVALID_HANDLE_VALUE) {
        printf("Error occured!, %x", GetLastError());
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
            if (_tcsicmp(pe32.szExeFile, processName) == 0) {
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
                if (_tcsicmp(moduleEntry32.szModule, moduleName) == 0) {
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

void detach() {
    // TODO: do shut-down code here
}

void mod_zoom_setBind(char bind)
{
    getZoomModule().setBind(bind);
}

void mod_zoom_setAmount(float amount)
{
    getZoomModule().setFovAmount(amount);
}

ADDRESS GetMLPtrAddy(void* addy, vector<DWORD> offsets)
{
    ADDRESS ptrPoint = 0;

    if (ReadProcessMemory(hProcess, addy, &ptrPoint, sizeof(ptrPoint), NULL) != 0)
    {
        for (unsigned int i = 0; i < offsets.size(); i++)
        {
            ptrPoint = GetMLPtrAddy((void*)(ptrPoint + offsets[i]), {});
        }
        return ptrPoint;
    }
    return 0;
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

DWORD attach() {
    // attach to Minecraft
    hProcess = GetProcessByName((WCHAR*)L"Minecraft.Windows.exe");
    log << "HProcess: " << hProcess << '\n';
    pID = GetProcessId(hProcess);
    moduleBase = GetModuleBase(pID, (WCHAR*)L"Minecraft.Windows.exe");
    if (hProcess == 0) return GetLastError();
    log << "Module Base: " << (void*)moduleBase << '\n';
    if (moduleBase == 0ui64) return GetLastError();
    return 0;
}

void loop()
{
    if (connectedToMinecraft())
    {
        Mod::tickModules();
    }
}

BOOL APIENTRY DllMain( HMODULE hModule,
                       DWORD  ul_reason_for_call,
                       LPVOID lpReserved
                     )
{
    if (ul_reason_for_call == DLL_PROCESS_ATTACH)
    {
        // attach to Latite.exe
    }
    return TRUE;
}

