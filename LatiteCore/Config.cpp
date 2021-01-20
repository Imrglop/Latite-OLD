// Simpler .properties config by Imrglop

#include "Config.h"
#include <fstream>
#include <iostream>
#include "dllmain.h"

using std::string;
using std::fstream;

std::vector<string> keys;
std::vector<string> values;

const char* filepath = "config.txt";
char splitChar = '=';
const char* fileDefault = "# Coming Soon\n";

bool Config::load()
{
	fstream file;
	file.open(filepath, std::ios_base::in);
	string finalCollection = "";
	if (file.fail())
	{
		// file failed
		if (errno == ENOENT) {
			log << filepath << " doesn't exist, trying to make new one...\n";
			std::ofstream newFile(filepath);
			newFile << fileDefault;
			newFile.close();
			std::flush(newFile);
			this->load();
			return true;
		}
		else {
			log << "Couldn't load config! errno: " << errno;
			return false;
		}
		return false;
	}
	// file is good

	string line = "";
	for (string currentLine; std::getline(file, line);)
	{
		std::istringstream toSplit(line);
		if (line[0] == '#' || line[0] == '!') { // comment
			continue;
		}
		std::vector<string> sl;
		for (std::string each; std::getline(toSplit, each, splitChar);) {
			sl.push_back(each);
		};
		if (sl.size() < 2) continue; // empty line
		keys.push_back(sl[0]);
		values.push_back(sl[1]);
	}
	file.close();
	return true;
}

int Config::findInList(std::vector<string> list, string item)
{
	unsigned int i = 0;
	for (; i < list.size(); i++)
	{
		if (list[i].compare(item) == 0) 
			break;
	};
	return i;
}

bool Config::getBool(string key)
{
	return values[findInList(keys, key)].compare("true") == 0 ? true : false;
}

int Config::getInteger(string key)
{
	try {
		string toint = values[findInList(keys, key)];
		return std::stoi(toint);
	}
	catch (std::exception e)
	{
		log << "Config Error: cannot set " << key << " to integer\n";
		return 0;
	}
}

float Config::getNumber(string key)
{
	try {
		string tofloat = values[findInList(keys, key)];
		return std::stof(tofloat);
	}
	catch (std::exception e) {
		log << "Config Error: cannot set " << key << " to number\n";
		return 0.0;
	}
}

unsigned char Config::getByte(string key)
{
	try {
		string tobyte = values[findInList(keys, key)];
		return (unsigned char)std::stoi(tobyte);
	}
	catch (std::exception e)
	{
		log << "Config Error: cannot set " << key << " to byte\n";
		return (unsigned char)0;
	}
}

string Config::getString(string key)
{
	return values[findInList(keys, key)];
}
