@echo off
echo Building Hovellas Engine...

REM Build C++ part
cd src_cpp
if not exist build mkdir build
cd build
cmake ..
cmake --build . --config Release
cd ..\..

REM Build .NET part
cd src_net
dotnet build --configuration Release
cd ..

echo Build complete!