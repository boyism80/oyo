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
import com.google.firebase.messaging.FirebaseMessaging
import kotlinx.android.synthetic.main.activity_main.*
import org.json.JSONObject
import oyo.com.firedetection.Adapter.DetectionAdapter

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


        FirebaseMessaging.getInstance().subscribeToTopic("all")


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
