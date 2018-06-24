#-*- coding: utf-8 -*-

import pymysql
import os
import uuid
import time
import urllib
import datetime
import math
import requests
from oyo_flask import oyo_flask
from flask import *


# 플라스크를 사용하기 위한 인스턴스 변수입니다.
app     		= oyo_flask(__name__)
@app.route('/')
def index():
	return render_template('index.html')

@app.route('/detection', methods=['POST'])
def detection():

	ret = {}
	try:
		host = request.remote_addr
		lat, lon, alt, tem = float(request.form.get('lat')), float(request.form.get('lon')), float(request.form.get('alt')), float(request.form.get('tem'))
		if app.near_exists(lat, lon):
			raise Exception('near exists')

		inf, vis, thumb = request.files['inf'], request.files['vis'], request.files['thumb']
		inf_path, vis_path, thumb_path = None, None, None

		if inf:
			content = inf.read()
			inf_path = app.generate_filename('static/images', 'inf', 'jpg')
			with open(inf_path, 'wb') as f:
				f.write(content)

		if vis:
			content = vis.read()
			vis_path = app.generate_filename('static/images', 'vis', 'jpg')
			with open(vis_path, 'wb') as f:
				f.write(content)

		if thumb:
			content = thumb.read()
			thumb_path = app.generate_filename('static/images', 'thumb', 'jpg')
			with open(thumb_path, 'wb') as f:
				f.write(content)

		connection = app.connect_db()
		with connection.cursor() as cursor:
			sql = "INSERT INTO detection (addr, lat, lon, alt, temperature, thumb, infrared, visual, date) VALUES (%s, %s, %s, %s, %s, %s, %s, %s, %s)"
			cursor.execute(sql, (str(host), lat, lon, alt, tem, thumb_path, inf_path, vis_path, time.strftime('%Y-%m-%d %H:%M:%S')))
			connection.commit()
		app.disconnect_db()

		ret['success'] = True

		# notification
		message_id = app.notification_fcm('산불이 감지되었습니다.', '클릭하여 자세한 정보를 확인하세요.')
		if message_id is None:
			raise Exception('Failed receive message id from fcm server')
	
	except Exception as e:
		ret['success'] = False
		ret['error'] = str(e)
	finally:
		return json.dumps(ret)

@app.route('/gets', methods=['POST'])
def gets():

	connection = app.connect_db()
	offset = int(request.form.get('offset'))
	count = int(request.form.get('count'))

	sql = "SELECT id, lat, lon, alt, temperature, thumb, date FROM detection WHERE deleted = 0 AND lat != 500 AND lon != 500 AND lat != 0 AND lon != 0 ORDER BY id DESC LIMIT %s, %s"
	ret = {}
	try:
		ret['success'] = True
		ret['data'] = []

		with connection.cursor() as cursor:
			count = cursor.execute(sql, (offset, count))
			for element in cursor.fetchall():
				item                = {}
				id, lat, lon, alt, tem, thumb, date = element
			
				item['id']          = id
				item['temperature'] = float(tem)
				item['position']    = {'lat': float(lat), 'lon': float(lon), 'alt': float(alt)}
				item['date']        = str(date)
				item['thumb']       = urllib.parse.urljoin(request.url_root, thumb)

				ret['data'].append(item)
	except Exception as e:
		ret['success'] = False
		ret['error'] = str(e)
		if 'data' in ret:
			del ret['data']

	finally:
		app.disconnect_db()

	return json.dumps(ret)

@app.route('/get', methods=['POST'])
def get():
	connection = app.connect_db()
	id = int(request.form.get('id'))
	sql = "SELECT id, lat, lon, alt, temperature, infrared, visual, date FROM detection WHERE id = %s AND deleted = 0 LIMIT 1"
	
	ret = {}
	try:
		with connection.cursor() as cursor:
			if cursor.execute(sql, (id,)) > 0:
				id, lat, lon, alt, tem, inf, vis, date = cursor.fetchone()
				ret['data'] = {'id': id, 'position': {'lat': float(lat), 'lon': float(lon), 'alt': float(alt)}, 'tem': float(tem), 'inf': urllib.parse.urljoin(request.url_root, inf), 'vis': urllib.parse.urljoin(request.url_root, vis), 'date': str(date)}

		ret['success'] = True
	except Exception as e:
		ret['success'] = False
		ret['error'] = str(e)

	finally:
		app.disconnect_db()

	return json.dumps(ret)

@app.route('/generate', methods=['POST'])
def generate():
	
	connection = app.connect_db()
	ret = {}
	try:
		app.lat = float(request.form.get('lat'))
		app.lon = float(request.form.get('lon'))
		app.alt = float(request.form.get('alt'))
		app.battery = int(request.form.get('battery'))

		ret['success'] = True
	except Exception as e:
		ret['success'] = False
		ret['error'] = str(e)

	finally:
		app.disconnect_db()

	return json.dumps(ret)

@app.route('/status', methods=['GET', 'POST'])
def status():
	connection = app.connect_db()
	ret = {}
	try:
		ret['position'] = {'lat': app.lat, 'lon': app.lon, 'alt': app.alt}
		ret['battery'] = app.battery
		ret['success'] = True
	except Exception as e:
		if 'position' in ret:
			del ret['position']

		if 'battery' in ret:
			del ret['battery']
			
		ret['success'] = False
		ret['error'] = str(e)

	finally:
		app.disconnect_db()

	return json.dumps(ret)


if __name__ == '__main__':
	app.run(host='0.0.0.0', port=8001)
