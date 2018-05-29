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
    lat = float(request.form.get('lat'))
    lon = float(request.form.get('lon'))
    tem = float(request.form.get('tem'))
    inf = request.files['inf']
    vis = request.files['vis']
    thumb = request.files['thumb']
    inf_path = None
    vis_path = None
    thumb_path = None

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

    if thumb:
        content = thumb.read()
        thumb_path = generate_filename('static/images', 'thumb', 'jpg')
        with open(thumb_path, 'wb') as f:
            f.write(content)
        # bnd.save(bnd_path)

    sql = "INSERT INTO detection (addr, lat, lon, temperature, thumb, infrared, visual, date) VALUES (%s, %s, %s, %s, %s, %s, %s, %s)"
    cursor.execute(sql, (str(host), lat, lon, tem, thumb_path, inf_path, vis_path, time.strftime('%Y-%m-%d %H:%M:%S')))
    conn.commit()

    return 'success'

@app.route('/gets', methods=['POST'])
def gest():
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



if __name__ == '__main__':
    global conn
    global cursor

    conn = pymysql.connect(host='localhost', user='oyo', password='oyoteam', db='oyo', charset='utf8')
    cursor = conn.cursor()
    
    app.run(host='0.0.0.0', port=8001)

    cursor.close()
    conn.close()