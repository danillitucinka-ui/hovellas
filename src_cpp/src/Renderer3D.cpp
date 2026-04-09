#include <raylib.h>
#include <iostream>

void Render3DScene() {
    // Load or generate interrogation room
    // For now, simple room
    DrawCube(Vector3{0, 0, 0}, 2, 2, 2, BLUE);
    DrawCube(Vector3{5, 0, 0}, 1, 1, 1, RED); // Table or something
    // Add camera and player movement
    Camera camera = { 0 };
    camera.position = Vector3{ 0.0f, 2.0f, 4.0f };
    camera.target = Vector3{ 0.0f, 0.0f, 0.0f };
    camera.up = Vector3{ 0.0f, 1.0f, 0.0f };
    camera.fovy = 45.0f;
    camera.projection = CAMERA_PERSPECTIVE;
    BeginMode3D(camera);
    // Draw models here
    EndMode3D();
}