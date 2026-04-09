#include "InputHandler.h"

void InputHandler::Update3DControls(Vector3& playerPos, Camera& camera) {
    if (inDialogMode) return; // Фокус на .NET

    // Управление движением
    if (IsKeyDown(KEY_W)) playerPos.z -= 0.1f;
    if (IsKeyDown(KEY_S)) playerPos.z += 0.1f;
    if (IsKeyDown(KEY_A)) playerPos.x -= 0.1f;
    if (IsKeyDown(KEY_D)) playerPos.x += 0.1f;

    // Камера
    UpdateCamera(&camera, CAMERA_FREE);
}

void InputHandler::SetDialogMode(bool mode) {
    inDialogMode = mode;
}