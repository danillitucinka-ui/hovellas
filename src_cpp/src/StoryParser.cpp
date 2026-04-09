#include "StoryParser.h"
#include <fstream>
#include <iostream>

void StoryParser::LoadQuests(const std::string& filePath) {
    std::ifstream file(filePath);
    nlohmann::json j;
    file >> j;
    for (auto& q : j["quests"]) {
        Quest quest;
        quest.id = q["id"];
        quest.title = q["title"];
        quest.description = q["description"];
        quest.time = q["time"];
        for (auto& s : q["steps"]) {
            quest.steps.push_back(s);
        }
        quests.push_back(quest);
    }
}

void StoryParser::LoadCharacters(const std::string& filePath) {
    std::ifstream file(filePath);
    nlohmann::json j;
    file >> j;
    for (auto& c : j["characters"]) {
        Character character;
        character.id = c["id"];
        character.name = c["name"];
        character.role = c["role"];
        character.description = c["description"];
        characters.push_back(character);
    }
}

std::vector<Quest> StoryParser::GetQuests() {
    return quests;
}

std::vector<Character> StoryParser::GetCharacters() {
    return characters;
}