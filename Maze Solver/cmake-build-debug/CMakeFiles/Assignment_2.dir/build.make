# CMAKE generated file: DO NOT EDIT!
# Generated by "MinGW Makefiles" Generator, CMake Version 3.17

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:


#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:


# Disable VCS-based implicit rules.
% : %,v


# Disable VCS-based implicit rules.
% : RCS/%


# Disable VCS-based implicit rules.
% : RCS/%,v


# Disable VCS-based implicit rules.
% : SCCS/s.%


# Disable VCS-based implicit rules.
% : s.%


.SUFFIXES: .hpux_make_needs_suffix_list


# Command-line flag to silence nested $(MAKE).
$(VERBOSE)MAKESILENT = -s

# Suppress display of executed commands.
$(VERBOSE).SILENT:


# A target that is always out of date.
cmake_force:

.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

SHELL = cmd.exe

# The CMake executable.
CMAKE_COMMAND = "E:\Program Files\JetBrains\CLion 2019.3.5\bin\cmake\win\bin\cmake.exe"

# The command to remove a file.
RM = "E:\Program Files\JetBrains\CLion 2019.3.5\bin\cmake\win\bin\cmake.exe" -E rm -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = "E:\Github repositories\assignment-2-KyleMcCullough"

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = "E:\Github repositories\assignment-2-KyleMcCullough\cmake-build-debug"

# Include any dependencies generated for this target.
include CMakeFiles/Assignment_2.dir/depend.make

# Include the progress variables for this target.
include CMakeFiles/Assignment_2.dir/progress.make

# Include the compile flags for this target's objects.
include CMakeFiles/Assignment_2.dir/flags.make

CMakeFiles/Assignment_2.dir/src/main.cpp.obj: CMakeFiles/Assignment_2.dir/flags.make
CMakeFiles/Assignment_2.dir/src/main.cpp.obj: ../src/main.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir="E:\Github repositories\assignment-2-KyleMcCullough\cmake-build-debug\CMakeFiles" --progress-num=$(CMAKE_PROGRESS_1) "Building CXX object CMakeFiles/Assignment_2.dir/src/main.cpp.obj"
	C:\msys64\mingw64\bin\g++.exe  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles\Assignment_2.dir\src\main.cpp.obj -c "E:\Github repositories\assignment-2-KyleMcCullough\src\main.cpp"

CMakeFiles/Assignment_2.dir/src/main.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/Assignment_2.dir/src/main.cpp.i"
	C:\msys64\mingw64\bin\g++.exe $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E "E:\Github repositories\assignment-2-KyleMcCullough\src\main.cpp" > CMakeFiles\Assignment_2.dir\src\main.cpp.i

CMakeFiles/Assignment_2.dir/src/main.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/Assignment_2.dir/src/main.cpp.s"
	C:\msys64\mingw64\bin\g++.exe $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S "E:\Github repositories\assignment-2-KyleMcCullough\src\main.cpp" -o CMakeFiles\Assignment_2.dir\src\main.cpp.s

CMakeFiles/Assignment_2.dir/src/Stack.cpp.obj: CMakeFiles/Assignment_2.dir/flags.make
CMakeFiles/Assignment_2.dir/src/Stack.cpp.obj: ../src/Stack.cpp
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir="E:\Github repositories\assignment-2-KyleMcCullough\cmake-build-debug\CMakeFiles" --progress-num=$(CMAKE_PROGRESS_2) "Building CXX object CMakeFiles/Assignment_2.dir/src/Stack.cpp.obj"
	C:\msys64\mingw64\bin\g++.exe  $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -o CMakeFiles\Assignment_2.dir\src\Stack.cpp.obj -c "E:\Github repositories\assignment-2-KyleMcCullough\src\Stack.cpp"

CMakeFiles/Assignment_2.dir/src/Stack.cpp.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing CXX source to CMakeFiles/Assignment_2.dir/src/Stack.cpp.i"
	C:\msys64\mingw64\bin\g++.exe $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -E "E:\Github repositories\assignment-2-KyleMcCullough\src\Stack.cpp" > CMakeFiles\Assignment_2.dir\src\Stack.cpp.i

CMakeFiles/Assignment_2.dir/src/Stack.cpp.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling CXX source to assembly CMakeFiles/Assignment_2.dir/src/Stack.cpp.s"
	C:\msys64\mingw64\bin\g++.exe $(CXX_DEFINES) $(CXX_INCLUDES) $(CXX_FLAGS) -S "E:\Github repositories\assignment-2-KyleMcCullough\src\Stack.cpp" -o CMakeFiles\Assignment_2.dir\src\Stack.cpp.s

# Object files for target Assignment_2
Assignment_2_OBJECTS = \
"CMakeFiles/Assignment_2.dir/src/main.cpp.obj" \
"CMakeFiles/Assignment_2.dir/src/Stack.cpp.obj"

# External object files for target Assignment_2
Assignment_2_EXTERNAL_OBJECTS =

Assignment_2.exe: CMakeFiles/Assignment_2.dir/src/main.cpp.obj
Assignment_2.exe: CMakeFiles/Assignment_2.dir/src/Stack.cpp.obj
Assignment_2.exe: CMakeFiles/Assignment_2.dir/build.make
Assignment_2.exe: CMakeFiles/Assignment_2.dir/linklibs.rsp
Assignment_2.exe: CMakeFiles/Assignment_2.dir/objects1.rsp
Assignment_2.exe: CMakeFiles/Assignment_2.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir="E:\Github repositories\assignment-2-KyleMcCullough\cmake-build-debug\CMakeFiles" --progress-num=$(CMAKE_PROGRESS_3) "Linking CXX executable Assignment_2.exe"
	$(CMAKE_COMMAND) -E cmake_link_script CMakeFiles\Assignment_2.dir\link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
CMakeFiles/Assignment_2.dir/build: Assignment_2.exe

.PHONY : CMakeFiles/Assignment_2.dir/build

CMakeFiles/Assignment_2.dir/clean:
	$(CMAKE_COMMAND) -P CMakeFiles\Assignment_2.dir\cmake_clean.cmake
.PHONY : CMakeFiles/Assignment_2.dir/clean

CMakeFiles/Assignment_2.dir/depend:
	$(CMAKE_COMMAND) -E cmake_depends "MinGW Makefiles" "E:\Github repositories\assignment-2-KyleMcCullough" "E:\Github repositories\assignment-2-KyleMcCullough" "E:\Github repositories\assignment-2-KyleMcCullough\cmake-build-debug" "E:\Github repositories\assignment-2-KyleMcCullough\cmake-build-debug" "E:\Github repositories\assignment-2-KyleMcCullough\cmake-build-debug\CMakeFiles\Assignment_2.dir\DependInfo.cmake" --color=$(COLOR)
.PHONY : CMakeFiles/Assignment_2.dir/depend

