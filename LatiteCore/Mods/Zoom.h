#pragma once

#ifndef ZOOM_H
#define ZOOM_H

class Zoom {
public:
	const char* nid = "zoom";
	char bind = 'C';
	float fovAmount = 45;
	void setFovAmount(float fov);
	bool enabled = false;
	void setBind(char b);
	void onDisable();
	void onEnable();
	void onTick();
};

#endif