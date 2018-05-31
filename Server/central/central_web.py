#-*- coding: utf-8 -*-

import pymysql
import os
import uuid
import time
import urllib
import datetime
import math
import requests
from flask import *


app     = Flask(__name__)
app.config['MAX_CONTENT_LENGTH'] = 16 * 1024 * 1024
conn, cursor = None, None
lat, lon, alt = (500, 500, 0)
FCM_API_KEY = 'AAAAtlOL1Xo:APA91bG8x7sPpkDE9-CojYOUgbrUeijlnc6kMyd9kEY3xjh0YUPMg5DkJKeoueQubw0rmvHzfFBvZpMIczWdLoIMSE_CCTFYBbRi03VvXn41aKiLCQgDUsFh3wZ63x6HIkL9VmHibolM'

def distance(p1, p2):
	R = 6373.0

	lat1, lon1 = (math.radians(p1[0]), math.radians(p1[1]))
	lat2, lon2 = (math.radians(p2[0]), math.radians(p2[1]))
	dlat, dlon = (lat2 - lat1, lon2 - lon1)

	a = math.sin(dlat / 2)**2 + math.cos(lat1) * math.cos(lat2) * math.sin(dlon / 2)**2
	c = 2 * math.atan2(math.sqrt(a), math.sqrt(1 - a))

	return R * c

def notification_fcm(title, message):
	try:
		url = 'https://fcm.googleapis.com/fcm/send'
		data = {'notification': {'title': title, 'body': message}, 'to': '/topics/all'}
		headers = {'Content-type': 'application/json', 'Authorization': 'key={}'.format(FCM_API_KEY)}
		r = requests.post(url, data=json.dumps(data), headers=headers)
		return json.loads(r.text)

	except Exception as e:
		print('error :', str(e))
		return None



def near_exists(lat, lon):
	ago_5m = datetime.datetime.now() - datetime.timedelta(minutes=5)
	sql = "SELECT lat, lon FROM detection WHERE date >= %s"
	count = cursor.execute(sql, (ago_5m.strftime('%Y-%m-%d %H:%M:%S'),))

	for row in cursor.fetchall():
		_lat, _lon = row
		_lat, _lon = float(_lat), float(_lon)

		if distance((lat, lon), (_lat, _lon)) < 0.02:
			return True

	return False




def generate_filename(directory, prefix, ext):
	if not os.path.exists(directory):
		os.mkdir(directory)

	if not os.path.isdir(directory):
		return None

	while True:
		filename = '{}/{}_{}.{}'.format(directory, prefix, uuid.uuid4(), ext)
		if not os.path.exists(filename):
			return filename

@app.route('/')
def index():
	return render_template('index.html')

@app.route('/detection', methods=['POST'])
def detection():
	ret = {}
	try:
		host = request.remote_addr
		lat, lon, tem = float(request.form.get('lat')), float(request.form.get('lon')), float(request.form.get('tem'))
		# if near_exists(lat, lon):
		# 	raise Exception('near exists')

		inf, vis, thumb = request.files['inf'], request.files['vis'], request.files['thumb']
		inf_path, vis_path, thumb_path = None, None, None

		if inf:
			content = inf.read()
			inf_path = generate_filename('static/images', 'inf', 'jpg')
			# with open(inf_path, 'wb') as f:
			# 	f.write(content)
			inf.save(inf_path)

		if vis:
			content = vis.read()
			vis_path = generate_filename('static/images', 'vis', 'jpg')
			# with open(vis_path, 'wb') as f:
			# 	f.write(content)
			vis.save(vis_path)

		if thumb:
			content = thumb.read()
			thumb_path = generate_filename('static/images', 'thumb', 'jpg')
			# with open(thumb_path, 'wb') as f:
			# 	f.write(content)
			thumb.save(thumb_path)

		sql = "INSERT INTO detection (addr, lat, lon, temperature, thumb, infrared, visual, date) VALUES (%s, %s, %s, %s, %s, %s, %s, %s)"
		cursor.execute(sql, (str(host), lat, lon, tem, thumb_path, inf_path, vis_path, time.strftime('%Y-%m-%d %H:%M:%S')))
		conn.commit()

		ret['success'] = True

		# notification
		message_id = notification_fcm('산불이 감지되었습니다.', '클릭하여 자세한 정보를 확인하세요.')
		if message_id is None:
			raise Exception('Failed receive message id from fcm server')
	
	except Exception as e:
		ret['success'] = False
		ret['error'] = str(e)

	return json.dumps(ret)

@app.route('/gets', methods=['POST'])
def gets():
	offset = int(request.form.get('offset'))
	count = int(request.form.get('count'))

	sql = "SELECT id, lat, lon, temperature, thumb, date FROM detection WHERE deleted = 0 ORDER BY id DESC LIMIT %s, %s"
	ret = {}
	try:
		ret['success'] = True
		ret['data'] = []

		count = cursor.execute(sql, (offset, count))
		for element in cursor.fetchall():
			item                = {}
			id, lat, lon, tem, thumb, date = element
		
			item['id']          = id
			item['temperature'] = float(tem)
			item['position']    = {'lat': float(lat), 'lon': float(lon)}
			item['date']        = str(date)
			item['thumb']       = urllib.parse.urljoin(request.url_root, thumb)

			ret['data'].append(item)
	except Exception as e:
		ret['success'] = False
		ret['error'] = str(e)
		if 'data' in ret:
			del ret['data']

	return json.dumps(ret)

@app.route('/get', methods=['POST'])
def get():
	id = int(request.form.get('id'))
	sql = "SELECT id, lat, lon, temperature, infrared, visual, date FROM detection WHERE id = %s AND deleted = 0 LIMIT 1"
	
	ret = {}
	try:
		ret['success'] = True
		if cursor.execute(sql, (id,)) > 0:
			id, lat, lon, tem, inf, vis, date = cursor.fetchone()
			ret['data'] = {'id': id, 'position': {'lat': float(lat), 'lon': float(lon)}, 'tem': float(tem), 'inf': urllib.parse.urljoin(request.url_root, inf), 'vis': urllib.parse.urljoin(request.url_root, vis), 'date': str(date)}
	except Exception as e:
		ret['success'] = False
		ret['error'] = str(e)

	return json.dumps(ret)

@app.route('/generate', methods=['POST'])
def generate():
	global lat, lon, alt
	ret = {}
	try:
		lat = float(request.form.get('lat'))
		lon = float(request.form.get('lon'))
		alt = float(request.form.get('alt'))

		ret['success'] = True
	except Exception as e:
		ret['success'] = False
		ret['error'] = str(e)

	return json.dumps(ret)

@app.route('/position', methods=['GET', 'POST'])
def position():
	global lat, lon, alt
	ret = {}
	try:
		if lat == 500 or lon == 500:
			raise Exception('Cannot generate drone\'s position')

		ret['lat'] = lat
		ret['lon'] = lon
		ret['alt'] = alt
		ret['success'] = True
	except Exception as e:
		ret['success'] = False
		ret['error'] = str(e)

	return json.dumps(ret)


if __name__ == '__main__':
	global conn, cursor

	conn = pymysql.connect(host='localhost', user='oyo', password='oyoteam', db='oyo', charset='utf8')
	cursor = conn.cursor()
	
	app.run(host='0.0.0.0', port=8001)

	cursor.close()
	conn.close()