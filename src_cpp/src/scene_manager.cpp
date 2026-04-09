#include "scene_manager.h"
#include <fstream>
#include <iostream>

void SceneManager::LoadScene(const std::string& sceneFile) {
    std::ifstream file(sceneFile);
    nlohmann::json j;
    file >> j;
    // Load 3D model based on j["model"]
    std::cout << "Loading scene: " << j["name"] << std::endl;
}

void SceneManager::UnloadScene() {
    // Unload current model
    std::cout << "Unloading scene" << std::endl;
}

void SceneManager::SwitchScene(const std::string& newSceneFile) {
    UnloadScene();
    LoadScene(newSceneFile);
}