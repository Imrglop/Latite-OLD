#pragma once

#ifndef LOOKBEHIND_H
#define LOOKBEHIND_H

class LookBehind {
public:
	char bind = 'G';
	const char* nid = "look_behind";
	bool enabled = false;
	void setBind(char b);
	void onDisable();
	void onEnable();
	void onTick();
};

#endif
