#pragma once
#ifndef CONFIG_H
#define CONFIG_H
#include <string>
#include <sstream>
#include <fstream>
#include <vector>
#include <string>
#include <map>

using std::string;

class Config
{
private:
	const char* filePath = "exampleConfig.txt";
	const char* fileDefault = "# Example Default\n";
	std::map<string, string> vars;
public:
	bool loaded = false;
	Config(const char* filePath, const char* defaults);
	bool load();
	std::vector<string> getKeys();
	std::string getString(string key);
	float getNumber(string key);
	unsigned char getByte(string key);
	bool getBool(string key);
	int getInteger(string key);
	int findInList(std::vector<string> list, string item);
};
#endif
