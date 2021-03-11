#pragma once

#include "../dllmain.h"

struct LocalPlayer
{
	static uintptr_t getPtr();
	// Add this amount to the local player pointer.

	template <typename T>
	static T push(uintptr_t offset);

	static uintptr_t add(uintptr_t amount) {
		return getPtr() + amount;
	}

	// Get the player's field of view
	static float getFOV();
	// Gets in-game display name of player
	static std::string getUsername();
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
	// Gets whether the player is in game or not
	static bool isInGame();
	// Gets your perspective 0: first person 1: 3rd person back 2: 3rd person front
	static unsigned char getPerspective();
	// Sets your prespective
	static void setPerspective(unsigned char val);
	// Sets your time of day
	static void setTime(int time);
	// Gets the ip of server you're in
	static std::string getServer();
	// Get the open gui string
	static std::string getUIState();
	// Gets whether a GUI is open
	static bool UIOpen();
	// Gets the coordinates of the block you're looking at as an 3-int array
	static int* getLookAtBlock();
	static float getBrightness();
	static void setBrightness(float bright);
	// --------------------
};

