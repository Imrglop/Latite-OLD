#include "Zoom.h"
#include "../LocalPlayer.h"
#include "ModManager.h"

float pastFOV;
bool keyPressed = false;
float fovAmt = 45;

void unzoom()
{
	log << "pastfov: " << pastFOV << '\n';
	LocalPlayer::setFOV(pastFOV);
}

void zoom()
{
	pastFOV = LocalPlayer::getFOV();
	for (float i = pastFOV; i > fovAmt; i -= 10)
	{
		// smoother thing
		Sleep(10);
		LocalPlayer::setFOV(i);
	}
	LocalPlayer::setFOV(pastFOV - fovAmt);
}

void Zoom::setFovAmount(float fov)
{
	this->fovAmount = fov;
	fovAmt = fov;
	log << "new fa: " << this->fovAmount << "\n";
}

void Zoom::setBind(char b)
{
	this->bind = b;
}

void Zoom::onDisable()
{
	unzoom();
}

void Zoom::onEnable()
{
	
}

void Zoom::onTick()
{
	/*
	check if they started pressing C (or whatever the key is)
	*/
	if ((GetKeyState(Zoom::bind) & 0x8000) && !keyPressed) // started being held down
	{
		keyPressed = true;
		zoom();
	}
	else if (!(GetKeyState(Zoom::bind) & 0x8000) && keyPressed)
	{
		keyPressed = false;
		unzoom();
	}
}