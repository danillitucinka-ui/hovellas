#include <raylib.h>
#include "GameStateManager.h"
#include "Renderer3D.h"
#include "InputHandler.h"
#include "StoryParser.h"
#include "EvidenceManager.h"
#include "SceneManager.h"

// Глобальные объекты
GameStateManager gameState;
Renderer3D renderer;
InputHandler inputHandler;
StoryParser storyParser;
EvidenceManager evidenceManager;
SceneManager sceneManager;

Vector3 playerPos = {0, 0, 0};
Camera camera = {0};

void DetectiveVision() {
    // Подсвечиваем улики неоновым контуром при Tab
    if (IsKeyPressed(KEY_TAB)) {
        for (auto& ev : evidenceManager.GetAllEvidences()) {
            if (!ev.Found) {
                DrawCubeWires(ev.Position, 0.6f, 0.6f, 0.6f, GREEN); // Неоновый контур
            }
        }
    }
}

int main() {
    InitWindow(1280, 720, "Hovellas: The Glass Paradox");
    SetTargetFPS(60); // Оптимизация для i5-12450H и 16GB RAM

    // Загрузка данных
    storyParser.LoadQuests("../../src/data/quests.json");
    storyParser.LoadCharacters("../../assets/characters.json");

    // Инициализация камеры
    camera.position = Vector3{0.0f, 2.0f, 4.0f};
    camera.target = Vector3{0.0f, 0.0f, 0.0f};
    camera.up = Vector3{0.0f, 1.0f, 0.0f};
    camera.fovy = 45.0f;
    camera.projection = CAMERA_PERSPECTIVE;

    std::string currentLocation = "office";
    while (!WindowShouldClose()) {
        float deltaTime = GetFrameTime();
        gameState.Update(deltaTime);

        inputHandler.Update3DControls(playerPos, camera);
        renderer.CheckInteraction(playerPos);

        // Перемещение между локациями
        if (IsKeyPressed(KEY_L)) {
            if (currentLocation == "office") {
                sceneManager.SwitchScene("street.json");
                currentLocation = "street";
                playerPos = Vector3{10, 0, 0}; // Новая позиция
            }
        }

        BeginDrawing();
        ClearBackground(BLACK);

        renderer.Render3DScene();
        DetectiveVision();

        EndDrawing();
    }

    CloseWindow();
    return 0;
}