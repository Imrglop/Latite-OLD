#include "ModManager.h"

Zoom zoom;

void Mod::disableAll()
{
	zoom.enabled = false;
	zoom.onDisable();
}

void Mod::initialize()
{
	log << "initialize mods\n";
}

void Mod::tickModules()
{
	zoom.onTick();
}

Zoom getZoomModule()
{
	return zoom;
}
