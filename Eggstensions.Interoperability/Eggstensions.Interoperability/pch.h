#pragma once

#ifndef PCH_H
#define PCH_H

#include <Windows.h>		// VirtualProtect
#include <Memoryapi.h>		// VirtualProtect

#include <cstddef>			// offsetof
#include <msclr\gcroot.h>	// msclr::gcroot
#include <msclr\lock.h>		// msclr::lock
#include <utility>			// std::forward

using FormID = System::UInt32;

#endif //PCH_H
