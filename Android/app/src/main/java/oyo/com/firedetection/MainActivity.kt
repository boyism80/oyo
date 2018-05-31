package oyo.com.firedetection

import android.content.Intent
import android.location.Geocoder
import android.os.Bundle
import android.support.v4.app.NotificationCompat
import android.support.v4.app.NotificationManagerCompat
import android.support.v7.app.AppCompatActivity
import android.util.Log
import android.view.View
import android.widget.AdapterView
import kotlinx.android.synthetic.main.activity_main.*
import org.json.JSONObject
import oyo.com.firedetection.Adapter.DetectionAdapter

@Suppress("DEPRECATION")
class MainActivity : AppCompatActivity(), OYOReceiver.Listener, AdapterView.OnItemClickListener {

    private val TAG = "MainActivity"

    private lateinit var _geocoder: Geocoder

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        this._geocoder = Geocoder(this)
        this.history.onItemClickListener = this

//        val notificationManager = getSystemService(NotificationManager::class.java)
//        notificationManager.createNotificationChannel(NotificationChannel(channelId, channelName, NotificationManager.IMPORTANCE_LOW))

        val builder = NotificationCompat.Builder(this).setContentTitle("set content title").setContentText("set content text").setTicker("new message alert").setSmallIcon(R.drawable.ic_stat_ic_notification).setAutoCancel(true)
        val style = NotificationCompat.InboxStyle().setBigContentTitle("big content title")
        builder.setStyle(style)

        val notificationManager = NotificationManagerCompat.from(applicationContext)
        notificationManager.notify(this.getString(R.string.default_notification_channel_id), 0, builder.build())


        if (intent.extras != null) {
            for (key in intent.extras!!.keySet()) {
                val value = intent.extras!!.get(key)
                Log.d(TAG, "Key: $key Value: $value")
            }
        }

        OYOReceiver(this, this.resources.getString(R.string.host), "get detections", this)
                .route("gets")
                .add("offset", "0")
                .add("count", "10")
                .start()
    }

    override fun onItemClick(parent: AdapterView<*>?, view: View?, position: Int, id: Long) {
        try {

            val json = parent?.getItemAtPosition(position) as JSONObject
            val intent = Intent(this, DetectionActivity::class.java)
            intent.putExtra("id", json.getInt("id"))
            this.startActivity(intent)
        } catch (e: Exception) {

            Log.d("onDetectionClicked", e.message)
        }
    }

    override fun onResponse(id: String, data: JSONObject) {

        try {
            when (id) {

                "get detections" -> {
                    val array = data.getJSONArray("data")
                    for (i in 0 until array.length()) {

                        val json = array.getJSONObject(i)
                        val position = json.getJSONObject("position")
                        val lat = position.getDouble("lat")
                        val lon = position.getDouble("lon")
                        val addressList = this._geocoder!!.getFromLocation(lat, lon, 1)
                        position.put("address", addressList[0].getAddressLine(0))
                    }
                    val adapter = DetectionAdapter(this, data.getJSONArray("data"))
                    this.history.adapter = adapter
                }
            }
        } catch (e: Exception) {

            Log.d("onResponse", e.message)
        }

    }

    override fun onError(id: String, message: String?) {

    }
}
