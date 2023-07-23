#pragma once

using namespace std;

#ifdef BUAPI_EXPORTS
#define BUAPI __declspec(dllexport)
#else
#define BUAPI __declspec(dllimport)
#endif



extern "C" BUAPI bool BUSaveAs(const char *oldFile, const char *newFile, int version);