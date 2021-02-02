// Simpler .properties config by Imrglop

#include "Config.h"
#include <fstream>
#include <iostream>

#define log std::cout

using std::string;
using std::fstream;

char splitChar = '=';


// constructor
Config::Config(const char* filePath, const char* defaults)
{
	this->fileDefault = defaults;
	this->filePath = filePath;
}

bool Config::load()
{
	fstream file;
	file.open(this->filePath, std::ios_base::in);
	string finalCollection = "";
	if (file.fail())
	{
		// file failed
		if (errno == ENOENT) {
			log << this->filePath << " doesn't exist, trying to make new one...\n";
			std::ofstream newFile(this->filePath);
			newFile << fileDefault;
			newFile.close();
			std::flush(newFile);
			this->load();
			return true;
		}
		else {
			log << "Couldn't load config! errno: " << errno << "\n";
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
		vars.insert({ sl[0], sl[1] });
	}
	file.close();
	this->loaded = true;
	return true;
}

int Config::findInList(std::vector<string> list, string item)
{
	for (unsigned int i = 0; i < list.size(); i++)
	{
		if (list[i].compare(item) == 0)
			return i;
	};
	return -1;
}

bool Config::getBool(string key)
{
	auto fli = vars.find(key);
	if (fli == vars.end()) return false;
	return fli->second.compare("true") == 0;
}

int Config::getInteger(string key)
{
	try {
		auto fli = vars.find(key);
		if (fli == vars.end()) return false;
		return std::stoi(fli->second);
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
		auto fli = vars.find(key);
		if (fli == vars.end()) return false;
		return std::stof(fli->second);
	}
	catch (std::exception e) {
		log << "Config Error: cannot set " << key << " to number\n";
		return 0.f;
	}
}

unsigned char Config::getByte(string key)
{
	try {
		auto fli = vars.find(key);
		if (fli == vars.end()) return false;
		return (unsigned char)std::stoi(fli->second);
	}
	catch (std::exception e)
	{
		log << "Config Error: cannot set " << key << " to byte\n";
		return 0ui8;
	}
}

std::vector<string> Config::getKeys()
{
	std::vector<string> retVal;
	for (std::map<string, string>::iterator it = vars.begin(); it != vars.end(); ++it)
	{
		retVal.push_back(it->first);
	}
	return retVal;
}

string Config::getString(string key)
{
	auto fli = vars.find(key);
	if (fli != vars.end()) return fli->second;
	return "null";
}
