#include "ModManager.h"

Zoom zoom;
LookBehind lookBehind;
ToggleSprint toggleSprint;
TimeChanger timeChanger;
Fullbright fullBright;
Freelook freelook;

void Mod::disableAll()
{
	zoom.enabled = false;
	zoom.onDisable();
	lookBehind.enabled = false;
	lookBehind.onDisable();
	toggleSprint.enabled = false;
	toggleSprint.onDisable();
	timeChanger.onDisable();
	freelook.onDisable();
}

void Mod::initialize()
{
	log << "Initializing mods\n";
	zoom.enabled = true;
	lookBehind.enabled = true;
}

void Mod::tickModules()
{
	if (zoom.enabled) zoom.onTick();
	if (lookBehind.enabled) lookBehind.onTick();
	//toggleSprint.onTick(); - not needed
	if (timeChanger.enabled) timeChanger.onTick();
	//freelook.onTick();
	fullBright.onTick();
	freelook.onTick();
}

Zoom getZoomModule()
{
	return zoom;
}

LookBehind getLookBehindModule()
{
	return lookBehind;
}

ToggleSprint getToggleSprintModule()
{
	return toggleSprint;
}

TimeChanger getTimeChangerModule()
{
	return timeChanger;
}

Fullbright getFullbrightModule()
{
	return fullBright;
}

Freelook getFreelookModule() 
{
	return freelook;
}