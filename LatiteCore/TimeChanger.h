#pragma once

#include "LocalPlayer.h"
class TimeChanger
{
public:
	bool enabled = false;
	void onDisable();
	void onEnable(int time);
	void onTick();
};

