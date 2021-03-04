#include "server_mod_disabler.h"
#include "SA_utils.h"
#include <iostream>

Config serverConfig("servers.txt", "# If you are seeing this, that means you didn't have the servers.txt file.\r\n# Grab the latest from https://github.com/Imrglop/Latite");

using std::string;

bool moduleDisabledOnServer(string server, string mod)
{
	if (!serverConfig.loaded) { 
		std::cout << "loading servers.txt\n";
		serverConfig.load();
	}

	auto status = serverConfig.getString(server);
	//std::cout << "status: " << status << '\n';
	if (status == "null") return false;
	auto list = utils::splitString(serverConfig.getString(server), ',');
	for (unsigned int i = 0; i < list.size(); i++)
	{
		//std::cout << "Compare " << list[i] << " : " << mod << '\n';
		if (list[i] == mod)
		{
			//std::cout << "Match!\n";
			return true;
		}
	}
	return false;
}
