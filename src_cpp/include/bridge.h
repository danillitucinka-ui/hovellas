#ifndef BRIDGE_H
#define BRIDGE_H

#ifdef _WIN32
#define EXPORT __declspec(dllexport)
#else
#define EXPORT
#endif

extern "C" {
    EXPORT void InitializeEngine();
    EXPORT void RenderScene(const char* sceneName);
    EXPORT void ShutdownEngine();
}

#endif // BRIDGE_H