#pragma once
class Freelook
{
private:
	char bind = 'F';
	bool keyPressed;
	void start();
	void stop();
public:
	const char* nid = "freelook";
	bool enabled = false;
	void setBind(char b);
	void onDisable();
	void onEnable();
	void onTick();
};

