#pragma once
#include "../Config/Config.h"

#define SERVER_DEFAULTS "! --------------------------------------------\n# This is just a config that disables certain modules in \n# certain servers. Use this for modules that are not allowed.\n# These servers are not affiliated with Latite.\n! --------------------------------------------\n\n# Example: example.com=toggle_sprint,zoom\n# That will disable both toggle sprint and zoom\n# in a Minecraft server called example.com\n\nplay.nethergames.org=toggle_sprint\ngeo.hivebedrock.network=freelook\n\n! --------------------------------------------\n# If you want a server added here by default,\n# ask in the Discord or submit a pull request.\n! --------------------------------------------"

bool moduleDisabledOnServer(std::string server, std::string mod);