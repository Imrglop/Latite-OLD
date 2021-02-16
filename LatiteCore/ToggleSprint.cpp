#include "ToggleSprint.h"
#include "dllmain.h"
#include "memory.h"
#include "server_mod_disabler.h"
#include "LocalPlayer.h"

int tick = 0;
#define tsDisabledByServer moduleDisabledOnServer(LocalPlayer::getServer(), "toggle_sprint")

void ToggleSprint::onDisable()
{
	tick = 0;
	if (tsDisabledByServer) return;
	log << "Disabling Toggle Sprint\n";
	memory::WriteBytes(currentModuleBase() + ADDRESS_STATIC_SPRINT_CODE, { 0x0F, 0xB6, 0x41, 0x5C }); // movzx eax,byte ptr [rcx+5C]
	this->enabled = false;
}

void ToggleSprint::onEnable()
{
	if (tsDisabledByServer) return;
	log << "Enabling Toggle Sprint\n";
	memory::WriteBytes(currentModuleBase() + ADDRESS_STATIC_SPRINT_CODE, { 0x90, 0x90, 0x90, 0x90 }); // nop
	this->enabled = true;
}

void ToggleSprint::onTick()
{
	if (tick % 10 == 0)
	{
		if (tsDisabledByServer) this->onDisable();
	}
	tick++;
}
