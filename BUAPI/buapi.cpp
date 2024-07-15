#include "pch.h"
#include "buapi.h"

#include <stdio.h>
#include <iostream>
#include <SketchUpAPI/common.h>
#include <SketchUpAPI/geometry.h>
#include <SketchUpAPI/initialize.h>
#include <SketchUpAPI/model/model.h>

// SUModelVersion_SU3,     ///< SketchUp 3
// SUModelVersion_SU4,     ///< SketchUp 4
// SUModelVersion_SU5,     ///< SketchUp 5
// SUModelVersion_SU6,     ///< SketchUp 6
// SUModelVersion_SU7,     ///< SketchUp 7
// SUModelVersion_SU8,     ///< SketchUp 8
// SUModelVersion_SU2013,  ///< SketchUp 2013
// SUModelVersion_SU2014,  ///< SketchUp 2014
// SUModelVersion_SU2015,  ///< SketchUp 2015
// SUModelVersion_SU2016,  ///< SketchUp 2016
// SUModelVersion_SU2017,  ///< SketchUp 2017
// SUModelVersion_SU2018,  ///< SketchUp 2018
// SUModelVersion_SU2019,  ///< SketchUp 2019
// SUModelVersion_SU2020,  ///< SketchUp 2020
// SUModelVersion_SU2021,  ///< "Versionless" file format. Starting with SketchUp 2021.
// SUModelVersion_Current = SUModelVersion_SU2021 

SUModelVersion get_version(int version)
{
	switch (version)
	{
		case 3:
			return SUModelVersion_SU3;
		case 4:
			return SUModelVersion_SU4;
		case 5:
			return SUModelVersion_SU5;
		case 6:
			return SUModelVersion_SU6;
		case 7:
			return SUModelVersion_SU7;
		case 8:
			return SUModelVersion_SU8;
		case 2013:
			return SUModelVersion_SU2013;
		case 2014:
			return SUModelVersion_SU2014;
		case 2015:
			return SUModelVersion_SU2015;
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
