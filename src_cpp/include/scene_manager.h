#ifndef SCENE_MANAGER_H
#define SCENE_MANAGER_H

#include <string>
#include "nlohmann/json.hpp"

class SceneManager {
public:
    void LoadScene(const std::string& sceneFile);
    void UnloadScene();
    void SwitchScene(const std::string& newSceneFile);
};

#endif // SCENE_MANAGER_H