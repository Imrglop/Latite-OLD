#include "Freelook.h"
#include "../Utils/server_mod_disabler.h"
#include "../Utils/LocalPlayer.h"
#include "../Utils/memory.h"
#define mds moduleDisabledOnServer(LocalPlayer::getServer(), this->nid)

char flBind = 'F';
bool flEnabled = false;

void Freelook::start()
{
	assert(flEnabled);
	assert(!mds);
	log << "Freelook: Start\n";
	memory::Nop(currentModuleBase() + ADDRESS_STATIC_FREELOOK_CODE, 2);
	memory::Nop(currentModuleBase() + ADDRESS_STATIC_FREELOOK2_CODE, 6);
	LocalPlayer::setPerspective(1);
}

void Freelook::stop()
{
	assert(flEnabled);
	log << "Freelook: Stop\n";
	memory::WriteBytes(currentModuleBase() + ADDRESS_STATIC_FREELOOK2_CODE, ADDRESS_STATIC_FREELOOK2_CONTENT);
	memory::WriteBytes(currentModuleBase() + ADDRESS_STATIC_FREELOOK_CODE, ADDRESS_STATIC_FREELOOK_CONTENT);
	LocalPlayer::setPerspective(0);
}

void Freelook::setBind(char b)
{
	this->bind = b;
	flBind = b;
}

void Freelook::onDisable()
{
	log << "Freelook: Disable";
	flEnabled = false;
	this->enabled = false;
	assert(!mds);
}

void Freelook::onEnable()
{
	log << "Freelook: Enable";
	flEnabled = true;
	this->enabled = true;
	assert(!mds);
}

void Freelook::onTick()
{
	if ((GetKeyState(flBind) & 0x8000) && !keyPressed) 
	{
		if (!LocalPlayer::UIOpen()) this->start();
		keyPressed = true;
	}
	else if (!(GetKeyState(flBind) & 0x8000) && keyPressed)
	{
		if (!LocalPlayer::UIOpen()) this->stop();
		keyPressed = false;
	}
	if ((keyPressed && LocalPlayer::UIOpen()) || mds) {
		this->stop();
	}
}
