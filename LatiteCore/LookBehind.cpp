#include "LookBehind.h"
#include "LocalPlayer.h"
#include "dllmain.h"

char lbBind_;
unsigned char oldView;
bool lbEnabled;
bool lbKeyPressed = false;

void lookBehind()
{
	LocalPlayer::setPerspective(2);
}

void goBack()
{
	if (oldView != 2) // small optimization
		LocalPlayer::setPerspective(oldView);
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
}
