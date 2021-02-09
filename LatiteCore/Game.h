#pragma once
#include <vector>
struct Player {
	char* name;
	static Player fromListAddress(void* addy);
};

struct Game {
	static std::vector<Player> getOnlinePlayers();
};