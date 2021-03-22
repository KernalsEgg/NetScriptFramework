#pragma once

#include <cstdint>	  // std::uintptr_t
#include <filesystem> // std::filesystem
#include <fstream>	  // std::ifstream
#include <intrin.h>	  // _mm_setr_ps, m128_f32
#include <iostream>	  // std::hex, std::uppercase
#include <random>	  // std::random_device, std::mt19937, std::uniform_real_distribution
#include <sstream>	  // std::stringstream
#include <string>	  // std::string, std::stoul, _stricmp
#include <vector>	  // std::vector

#include <spdlog/sinks/basic_file_sink.h>

#include "RE/Skyrim.h"
#include "REL/Relocation.h"
#include "SKSE/SKSE.h"

using namespace std::literals;

#include "Settings.h"
#include "Version.h"

#define DLLEXPORT __declspec(dllexport)
