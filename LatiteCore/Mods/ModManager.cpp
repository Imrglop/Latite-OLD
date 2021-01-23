#include "ModManager.h"

Zoom zoom;
LookBehind lookBehind;

void Mod::disableAll()
{
	zoom.enabled = false;
	zoom.onDisable();
	lookBehind.enabled = false;
	lookBehind.onDisable();
}

void Mod::initialize()
{
	log << "Initializing mods\n";
	zoom.onEnable();
	lookBehind.onEnable();
	zoom.enabled = true;
	lookBehind.enabled = true;
}

void Mod::tickModules()
{
	zoom.onTick();
	lookBehind.onTick();
}

Zoom getZoomModule()
{
	return zoom;
}

LookBehind getLookBehindModule()
{
	return lookBehind;
}
