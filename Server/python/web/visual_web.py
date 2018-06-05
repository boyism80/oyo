import sys
import cv2
import numpy as np
from webstream import *

class vwebstream(webstream):
    def __init__(self, port):
        webstream.__init__(self, port)

        self.__device = cv2.VideoCapture(0)

    def __del__(self):
        webstream.__del__(self)
        self.__device.release()

    def on_request(self):
        ret, frame = self.__device.read()
        if ret is False:
            return None

        cv2.waitKey(27)
        return frame





if __name__ == '__main__':
    web = vwebstream(8000)
    if not web.execute(True):
        exit()

    while True:
        cmd = input('')
        if cmd.lower() == 'exit':
            break

    print('Wait for exit...')
    web.exit()