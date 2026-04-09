cmake_minimum_required(VERSION 3.16)
project(HovellasEngine)

set(CMAKE_CXX_STANDARD 17)

# Find Raylib
find_package(raylib REQUIRED)

# Include directories
include_directories(include)

# Source files
set(SOURCES src/Engine.cpp src/bridge.cpp src/scene_manager.cpp src/StoryParser.cpp src/Renderer3D.cpp src/InputHandler.cpp src/highlight.cpp)
file(GLOB HEADERS "include/*.h")

# Add JSON library
find_package(nlohmann_json REQUIRED)
target_link_libraries(hovellas_engine nlohmann_json::nlohmann_json)

# Create executable
add_executable(hovellas_engine ${SOURCES})

# Link Raylib
target_link_libraries(hovellas_engine raylib)

# Copy assets
configure_file(${CMAKE_SOURCE_DIR}/../assets/3d/models.obj ${CMAKE_BINARY_DIR}/models.obj COPYONLY)