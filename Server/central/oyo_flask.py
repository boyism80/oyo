import pymysql
import os
import uuid
import time
import urllib
import datetime
import math
import requests
import threading
from flask import *

class oyo_flask(Flask):
	FCM_API_KEY 	= 'AAAAtlOL1Xo:APA91bG8x7sPpkDE9-CojYOUgbrUeijlnc6kMyd9kEY3xjh0YUPMg5DkJKeoueQubw0rmvHzfFBvZpMIczWdLoIMSE_CCTFYBbRi03VvXn41aKiLCQgDUsFh3wZ63x6HIkL9VmHibolM'

	def __init__(self, name):
		Flask.__init__(self, name)
		self.config['MAX_CONTENT_LENGTH'] = 16 * 1024 * 1024

		self.lat, self.lon, self.alt = (500, 500, 0)
		self.battery = 0

		self.__connection = None

		self.__db_lock = threading.Lock()

	def distance(self, p1, p2):
		R = 6373.0

		lat1, lon1 = (math.radians(p1[0]), math.radians(p1[1]))
		lat2, lon2 = (math.radians(p2[0]), math.radians(p2[1]))
		dlat, dlon = (lat2 - lat1, lon2 - lon1)

		a = math.sin(dlat / 2)**2 + math.cos(lat1) * math.cos(lat2) * math.sin(dlon / 2)**2
		c = 2 * math.atan2(math.sqrt(a), math.sqrt(1 - a))

		return R * c

	def notification_fcm(self, title, message):
		try:
			url = 'https://fcm.googleapis.com/fcm/send'
			data = {'notification': {'title': title, 'body': message}, 'to': '/topics/all'}
			headers = {'Content-type': 'application/json', 'Authorization': 'key={}'.format(oyo_flask.FCM_API_KEY)}
			r = requests.post(url, data=json.dumps(data), headers=headers)
			return json.loads(r.text)

		except Exception as e:
			print('error :', str(e))
			return None

	def near_exists(self, lat, lon):
		ago_5m = datetime.datetime.now() - datetime.timedelta(seconds=10)
		sql = "SELECT lat, lon FROM detection WHERE date >= %s"
		ret = False

		connection = self.connect_db()
		with connection.cursor() as cursor:
			count = cursor.execute(sql, (ago_5m.strftime('%Y-%m-%d %H:%M:%S'),))

			for row in cursor.fetchall():
				_lat, _lon = row
				_lat, _lon = float(_lat), float(_lon)

				if self.distance((lat, lon), (_lat, _lon)) < 0.02:
					ret = True
					break
		self.disconnect_db()

		return ret

	def generate_filename(self, directory, prefix, ext):
		if not os.path.exists(directory):
			os.mkdir(directory)

		if not os.path.isdir(directory):
			return None

		while True:
			filename = '{}/{}_{}.{}'.format(directory, prefix, uuid.uuid4(), ext)
			if not os.path.exists(filename):
				return filename

	def connect_db(self):
		self.__db_lock.acquire()
		self.__connection = pymysql.connect(host='localhost', user='oyo', password='oyoteam', db='oyo', charset='utf8')
		return self.__connection

	def disconnect_db(self):
		self.__connection.close()
		self.__connection = None
		self.__db_lock.release()

