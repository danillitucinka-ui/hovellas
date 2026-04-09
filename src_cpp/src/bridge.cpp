#include "bridge.h"
#include <raylib.h>
#include <iostream>

void InitializeEngine() {
    InitWindow(800, 600, "Hovellas");
    SetTargetFPS(60);
}

void RenderScene(const char* sceneName) {
    BeginDrawing();
    ClearBackground(RAYWHITE);
    DrawText(sceneName, 10, 10, 20, BLACK);
    EndDrawing();
}

void ShutdownEngine() {
    CloseWindow();
}