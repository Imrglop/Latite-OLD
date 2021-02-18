#pragma once

#include "../Utils/LocalPlayer.h"
class TimeChanger
{
public:
	bool enabled = false;
	void onDisable();
	const char* nid = "time_changer";
	void onEnable(int time);
	void onTick();
};

