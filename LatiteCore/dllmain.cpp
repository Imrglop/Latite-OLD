/*
Latite - Minecraft PVP Mod
by Imrglop
*/

#include "dllmain.h"
#include <TlHelp32.h>
#include <tchar.h>

bool connected;

HANDLE hProcess;

DWORD_PTR GetModuleBase(DWORD pID, wchar_t* moduleName)
{
    DWORD_PTR moduleBase = 0;
    DWORD _err;
    HANDLE hSnapshot = CreateToolhelp32Snapshot(TH32CS_SNAPMODULE | TH32CS_SNAPMODULE32, pID);
    if (hSnapshot != INVALID_HANDLE_VALUE)
    {
        MODULEENTRY32W moduleEntry32;
        moduleEntry32.dwSize = sizeof(MODULEENTRY32W);
        if (Module32FirstW(hSnapshot, &moduleEntry32)) {
            do {
                if (_tcsicmp(moduleEntry32.szModule, moduleName) == NULL) {
                    // found match
                    moduleBase = (DWORD_PTR)moduleEntry32.modBaseAddr;
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
    return moduleBase;
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
    DWORD _err;
    // attach to Minecraft
    HWND mcWindow = FindWindow(NULL, L"Minecraft");
    // assuming it's minecraft bedrock for now..
    DWORD pID = 0;
    GetWindowThreadProcessId(mcWindow, &pID);
    if (pID == 0)
    {
        _err = GetLastError();
        return _err;
    }
    return 0;
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

