#!/usr/bin/env python3
# encoding: utf-8

from distutils.core import setup, Extension

lepton_module = Extension('clepton', 
							include_dirs = ['../cpp/lepton', '../cpp/vospi', '/usr/local/include'], 
							# libraries = ['opencv_core', 'opencv_highgui'], 
							library_dirs = ['/usr/local/lib'], 
							sources = ['lepton.cpp', '../cpp/lepton/lepton.cpp', '../cpp/vospi/vospi.cpp'])

setup(name='clepton',
      version='0.1.0',
      description='lepton module written in C++',
      ext_modules=[lepton_module])