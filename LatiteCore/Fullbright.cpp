#include "Fullbright.h"
#include "server_mod_disabler.h"
#include "LocalPlayer.h"

#define mds moduleDisabledOnServer(LocalPlayer::getServer(), this->nid)

void Fullbright::onDisable()
{
	if (mds) return;
	LocalPlayer::setBrightness(lastBrightness);
	log << "Lastbrightness: " << lastBrightness << '\n';
	this->enabled = false;
	log << "Fullbright: Disable\n";
}

void Fullbright::onEnable()
{
	this->tick = 0;
	if (mds) return;
	log << "Fullbright: Enable\n";
	this->lastBrightness = LocalPlayer::getBrightness();
	LocalPlayer::setBrightness(1000);
	this->enabled = true;
}

void Fullbright::onTick()
{
	if (this->tick % 20 == 0 && !mds) {
		LocalPlayer::setBrightness(1000);
	}
	else if (this->tick % 20 == 0 && mds) {
		this->onDisable();
	}
	this->tick++;
}
