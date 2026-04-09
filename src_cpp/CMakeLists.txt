cmake_minimum_required(VERSION 3.16)
project(HovellasEngine)

set(CMAKE_CXX_STANDARD 17)

# Find Raylib
find_package(raylib REQUIRED)

# Include directories
include_directories(include)

# Source files
file(GLOB SOURCES "src/*.cpp")

# Create executable
add_executable(hovellas_engine ${SOURCES})

# Link Raylib
target_link_libraries(hovellas_engine raylib)

# Copy assets
configure_file(${CMAKE_SOURCE_DIR}/../assets/3d/models.obj ${CMAKE_BINARY_DIR}/models.obj COPYONLY)