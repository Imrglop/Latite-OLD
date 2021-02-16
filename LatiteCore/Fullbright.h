#pragma once
class Fullbright
{
private:
	int tick = 0;
	float lastBrightness = 0.f;
	bool enabled = false;
public:
	void onDisable();
	const char* nid = "fullbright";
	void onEnable();
	void onTick();
};

