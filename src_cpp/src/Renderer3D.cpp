#include <raylib.h>
#include <iostream>
#include "EvidenceManager.h" // Assume header

// Глобальный менеджер улик
EvidenceManager* evidenceManager;

void Render3DScene() {
    // Загрузка или генерация комнаты допроса
    DrawCube(Vector3{0, 0, 0}, 2, 2, 2, BLUE); // Стена
    DrawCube(Vector3{5, 0, 0}, 1, 1, 1, RED); // Стол

    // Рендеринг улик
    for (auto& ev : evidenceManager->GetAllEvidences()) {
        if (!ev.Found) {
            DrawCube(ev.Position, 0.5f, 0.5f, 0.5f, GREEN); // Скрытая улика
        }
    }

    Camera camera = { 0 };
    camera.position = Vector3{ 0.0f, 2.0f, 4.0f };
    camera.target = Vector3{ 0.0f, 0.0f, 0.0f };
    camera.up = Vector3{ 0.0f, 1.0f, 0.0f };
    camera.fovy = 45.0f;
    camera.projection = CAMERA_PERSPECTIVE;
    BeginMode3D(camera);
    // Рисуем модели здесь
    EndMode3D();
}

void CheckInteraction(Vector3 playerPos) {
    // Проверка взаимодействия с уликами
    for (auto& ev : evidenceManager->GetAllEvidences()) {
        if (Vector3Distance(playerPos, ev.Position) < 1.0f && IsKeyPressed(KEY_E)) {
            // Вызвать .NET окно с описанием
            // P/Invoke to .NET
            std::cout << "Evidence found: " << ev.Name << std::endl;
            evidenceManager->MarkFound(ev.Id);
        }
    }
}