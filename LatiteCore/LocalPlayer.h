#pragma once

#include "dllmain.h"

struct LocalPlayer
{
	// ----- Settings ----

	// Get the player's field of view
	static float getFOV();
	// Set the player's field of view
	static void setFOV(float fov);
	// Set sensitivity
	static void setSensitivity(float sens);
	// Get sensitivity
	static float getSensitivity();
	// Gets hide hand setting
	static unsigned char getHideHand();
	// Sets hide hand setting
	static void setHideHand(unsigned char val);
	// Tells whether the player is in game or not
	static bool isInGame();
	// Gets your perspective 0: first person 1: 3rd person back 2: 3rd person front
	static unsigned char getPerspective();
	// Sets your prespective
	static void setPerspective(unsigned char val);
	// --------------------
};

