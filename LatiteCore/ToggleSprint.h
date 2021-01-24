#pragma once
class ToggleSprint
{
public:
	bool enabled = false;
	void onDisable();
	void onEnable();
	void onTick();
};

