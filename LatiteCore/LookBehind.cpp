#include "LookBehind.h"
#include "LocalPlayer.h"
#include "dllmain.h"

char lbBind_;
unsigned char oldView;
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
	goBack();
}

void LookBehind::onEnable()
{
	lbBind_ = this->bind;
}

void LookBehind::onTick()
{
	if ((GetKeyState(lbBind_) & 0x8000) && !lbKeyPressed) // started being held down
	{
		lbKeyPressed = true;
		if (this->enabled)
			lookBehind();
	}
	else if (!(GetKeyState(lbBind_) & 0x8000) && lbKeyPressed)
	{
		lbKeyPressed = false;
		if (this->enabled)
			goBack();
	}
}
