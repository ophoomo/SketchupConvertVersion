#include "pch.h"
#include "buapi.h"

#include <stdio.h>
#include <iostream>
#include <SketchUpAPI/common.h>
#include <SketchUpAPI/geometry.h>
#include <SketchUpAPI/initialize.h>
#include <SketchUpAPI/model/model.h>


SUModelVersion get_version(int version)
{
	switch (version)
	{
		case 2016:
			return SUModelVersion_SU2016;
		case 2017:
			return SUModelVersion_SU2017;
		case 2018:
			return SUModelVersion_SU2018;
		case 2019:
			return SUModelVersion_SU2019;
		case 2021:
			return SUModelVersion_SU2021;
		default:
			return SUModelVersion_Current;
	}
}

BUAPI bool BUSaveAs(const char* oldFile, const char* newFile, int version)
{
	SUInitialize();
	// // Load the model from a file
	SUModelRef model = SU_INVALID;
	SUModelLoadStatus status;
	SUResult res = SUModelCreateFromFileWithStatus(&model, oldFile, &status);

	// // It's best to always check the return code from each SU function call.
	// // Only showing this check once to keep this example short.
	if (res != SU_ERROR_NONE) {
		std::cout << "Failed creating model from a file" << std::endl;
		return false;
	}

	if (status == SUModelLoadStatus_Success_MoreRecent) {
		std::cout
		<< "This model was created in a more recent SketchUp version than that of the SDK. "
		   "It contains data which will not be read. Saving the model over the original file may "
		   "lead to permanent data loss."
		<< std::endl;
		return false;
	}

	// // Save the in-memory model to a file
	res = SUModelSaveToFileWithVersion(model, newFile, get_version(version));
	// // Must release the model or there will be memory leaks
	SUModelRelease(&model);
	// // Always terminate the API when done using it
	SUTerminate();

	if (res != SU_ERROR_NONE) {
		std::cout << "Unable to save document!";
		return false;
	}
    return true;
}
