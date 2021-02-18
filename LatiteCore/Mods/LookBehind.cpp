#include "LookBehind.h"
#include "../Utils/LocalPlayer.h"
#include "../dllmain.h"
#include "../Utils/server_mod_disabler.h"

char lbBind_;
unsigned char oldView;
bool lbEnabled;
bool lookingBehind = false;
bool lbKeyPressed = false;

void lookBehind()
{
	if (LocalPlayer::UIOpen()) return;
	lookingBehind = true;
	if (moduleDisabledOnServer(LocalPlayer::getServer(), "look_behind")) return;
	LocalPlayer::setPerspective(2ui8);
}

void goBack()
{
	if (lookingBehind) {
		if (!moduleDisabledOnServer(LocalPlayer::getServer(), "look_behind"))
			LocalPlayer::setPerspective(0ui8);
	}
}

void LookBehind::setBind(char b)
{
	this->bind = b;
	lbBind_ = b;
}

void LookBehind::onDisable()
{
	this->enabled = false;
	// back to old view
	lbEnabled = false;
	goBack();
}

void LookBehind::onEnable()
{
	this->enabled = true;
	lbBind_ = this->bind;
	lbEnabled = true;
}

void LookBehind::onTick()
{
	if ((GetKeyState(lbBind_) & 0x8000) && !lbKeyPressed) // started being held down
	{
		lbKeyPressed = true;
		if (lbEnabled)
			lookBehind();
	}
	else if (!(GetKeyState(lbBind_) & 0x8000) && lbKeyPressed)
	{
		lbKeyPressed = false;
		if (lbEnabled)
			goBack();
	}
	if (lookingBehind && LocalPlayer::UIOpen()) goBack();
}
