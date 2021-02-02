#pragma once
#include <vector>
#include <string>

using std::vector;
using std::string;

class ToggleSprint
{
public:
	static vector<string> disabledServers;
	bool enabled = false;
	const char* nid = "toggle_sprint";
	void onDisable();
	void onEnable();
	void onTick();
};

