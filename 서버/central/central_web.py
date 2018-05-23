import pymysql
import os
import uuid
import time
import urllib
from flask import *


app     = Flask(__name__)
app.config['MAX_CONTENT_LENGTH'] = 16 * 1024 * 1024
conn    = None
cursor  = None

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
	host = request.remote_addr
	lat = int(request.form.get('lat'))
	lon = int(request.form.get('lon'))
	inf = request.files['inf']
	vis = request.files['vis']
	bnd = request.files['bnd']
	inf_path = None
	vis_path = None
	bnd_path = None

	if inf:
		content = inf.read()
		inf_path = generate_filename('static/images', 'inf', 'jpg')
		with open(inf_path, 'wb') as f:
			f.write(content)
		#inf.save(inf_path)

	if vis:
		content = vis.read()
		vis_path = generate_filename('static/images', 'vis', 'jpg')
		with open(vis_path, 'wb') as f:
			f.write(content)
		# vis.save(vis_path)

	if bnd:
		content = bnd.read()
		bnd_path = generate_filename('static/images', 'bnd', 'jpg')
		with open(bnd_path, 'wb') as f:
			f.write(content)
		# bnd.save(bnd_path)

	sql = "INSERT INTO detection (addr, lat, lon, infrared, visual, blended, date) VALUES (%s, %s, %s, %s, %s, %s, %s)"
	cursor.execute(sql, (str(host), lat, lon, inf_path, vis_path, bnd_path, time.strftime('%Y-%m-%d %H:%M:%S')))
	conn.commit()

	return 'success'

@app.route('/get', methods=['GET', 'POST'])
def get():
	offset = int(request.form.get('offset'))
	count = int(request.form.get('count'))

	sql = "SELECT id, lat, lon, infrared, visual, blended, date FROM detection WHERE deleted = 0 ORDER BY id DESC LIMIT %s, %s"
	count = cursor.execute(sql, (offset, count))

	ret = {'success': True, 'data': []}
	for element in cursor.fetchall():
		item                = {}
		id, lat, lon, inf, vis, bnd, date = element
		
		item['id']          = id
		item['position']    = {'lat': float(lat), 'lon': float(lon)}
		item['date']        = str(date)
		item['images']      = {'inf': urllib.parse.urljoin(request.url_root, inf), 'vis': urllib.parse.urljoin(request.url_root, vis), 'bnd': urllib.parse.urljoin(request.url_root, bnd)}

		ret['data'].append(item)

	return json.dumps(ret)


if __name__ == '__main__':
	global conn
	global cursor

	conn = pymysql.connect(host='localhost', user='oyo', password='oyoteam', db='oyo', charset='utf8')
	cursor = conn.cursor()
	
	app.run(host='0.0.0.0', port=8001)

	cursor.close()
	conn.close()