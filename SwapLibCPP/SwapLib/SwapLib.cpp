// SwapLib.cpp : Defines the functions for the static library.
//

#include "pch.h"
#include "framework.h"

extern "C" __declspec(dllexport) void swapCPP(int* r, int* s)
{
	int temp = *r;
	*r = *s;
	*s = temp;
	return;
}
