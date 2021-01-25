#include "ToggleSprint.h"
#include "dllmain.h"
#include "memory.h"

void ToggleSprint::onDisable()
{
	log << "Disabling Toggle Sprint\n";
	memory::WriteBytes(currentModuleBase() + ADDRESS_STATIC_SPRINT_CODE, { 0x0F, 0xB6, 0x41, 0x5C }); // movzx eax,byte ptr [rcx+5C]
	this->enabled = false;
}

void ToggleSprint::onEnable()
{
	log << "Enabling Toggle Sprint\n";
	memory::WriteBytes(currentModuleBase() + ADDRESS_STATIC_SPRINT_CODE, { 0x90, 0x90, 0x90, 0x90 }); // nop
	this->enabled = true;
}

void ToggleSprint::onTick()
{
}
