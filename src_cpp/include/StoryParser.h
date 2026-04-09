#ifndef STORY_PARSER_H
#define STORY_PARSER_H

#include <string>
#include <vector>
#include <nlohmann/json.hpp>

struct Quest {
    std::string id;
    std::string title;
    std::string description;
    int time;
    std::vector<std::string> steps;
};

struct Character {
    std::string id;
    std::string name;
    std::string role;
    std::string description;
};

class StoryParser {
private:
    std::vector<Quest> quests;
    std::vector<Character> characters;

public:
    void LoadQuests(const std::string& filePath);
    void LoadCharacters(const std::string& filePath);
    std::vector<Quest> GetQuests();
    std::vector<Character> GetCharacters();
};

#endif // STORY_PARSER_H