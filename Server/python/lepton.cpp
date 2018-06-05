#include "lepton.h"
#include <Python.h>

void clepton_destructor(PyObject* self)
{
	delete static_cast<lx::lepton*>(PyCapsule_GetPointer(self, "clepton"));
}

static PyObject* create25(PyObject* self, PyObject* args)
{
	lx::lepton* 				clepton = NULL;
	try
	{
		const char* 			spidev	= NULL;
		if (!PyArg_ParseTuple(args, "s", &spidev))
			throw std::exception();

		if((clepton = new lx::lepton25(spidev)) == NULL)
			throw std::exception();

		return PyCapsule_New(clepton, "clepton", clepton_destructor);
	}
	catch(...)
	{
		if(clepton != NULL)
			delete clepton;

		Py_RETURN_NONE;
	}
}

static PyObject* create30(PyObject* self, PyObject* args)
{
	lx::lepton* 				clepton = NULL;
	try
	{
		const char* 			spidev	= NULL;
		if (!PyArg_ParseTuple(args, "s", &spidev))
			throw std::exception();

		if((clepton = new lx::lepton30(spidev)) == NULL)
			throw std::exception();

		return PyCapsule_New(clepton, "clepton", clepton_destructor);
	}
	catch(...)
	{
		if(clepton != NULL)
			delete clepton;

		Py_RETURN_NONE;
	}
}

static PyObject* transfer(PyObject *self, PyObject *args) 
{
	static uint16_t 		buffer[19200]	= {0, };
	PyObject*				clepton_obj		= NULL;

	if(PyArg_ParseTuple(args, "O", &clepton_obj) == false)
		Py_RETURN_FALSE;

	void*					clepton_ref 	= PyCapsule_GetPointer(clepton_obj, "clepton");
	if(clepton_ref == NULL)
		Py_RETURN_FALSE;

	lx::lepton* 			clepton 			= static_cast<lx::lepton*>(clepton_ref);
	size_t 					size   			= 0;

	if(clepton->transfer(buffer, &size) == false)
		Py_RETURN_FALSE;

	return Py_BuildValue("y#", (const void*)buffer, size);
}


static PyMethodDef clepton_methods[] = { 
	{   
		"create25", create25, METH_VARARGS,
		"Create lepton 2.5 module"
	},
	{   
		"create30", create30, METH_VARARGS,
		"Create lepton 3.0 module"
	},
	{   
		"transfer", transfer, METH_VARARGS,
		"Get lepton's captured frame"
	},
	{NULL, NULL, 0, NULL}
};

static struct PyModuleDef clepton_definition = { 
	PyModuleDef_HEAD_INIT,
	"clepton",
	"A Python module that capture infrared frame from lepton 2.5 or 3.0.",
	-1, 
	clepton_methods
};

PyMODINIT_FUNC PyInit_clepton(void) {
	Py_Initialize();
	return PyModule_Create(&clepton_definition);
}