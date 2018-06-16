package oyo.com.firedetection

import android.app.Activity
import android.content.Intent
import android.os.Bundle
import android.util.Log
import android.view.View
import android.widget.AdapterView
import com.google.firebase.messaging.FirebaseMessaging
import kotlinx.android.synthetic.main.activity_main.*
import org.json.JSONObject
import oyo.com.firedetection.Adapter.DetectionAdapter
import java.util.*
import kotlin.concurrent.timerTask

class MainActivity : Activity(), OYOReceiver.Listener, AdapterView.OnItemClickListener {

    private val TAG = "MainActivity"

    private lateinit var _geocoder: OYOGeocoder

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_main)

        this._geocoder = OYOGeocoder(this)
        this.history.onItemClickListener = this

        FirebaseMessaging.getInstance().subscribeToTopic("all")

        OYOReceiver(this, this.resources.getString(R.string.host), "get detections", this)
                .route("gets")
                .add("offset", "0")
                .add("count", "10")
                .start()

        val timer = Timer(true)
        timer.scheduleAtFixedRate(timerTask {

            requestPosition()
        }, 0, 1000)
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
            if(data.getBoolean("success") == false)
                throw Exception(data.getString("error"))

            when (id) {

                "get detections" -> {
                    val array = data.getJSONArray("data")
                    for (i in 0 until array.length()) {

                        val json = array.getJSONObject(i)
                        val position = json.getJSONObject("position")
                        val lat = position.getDouble("lat")
                        val lon = position.getDouble("lon")
                        position.put("address", this._geocoder.address(lat, lon))
                    }
                    val adapter = DetectionAdapter(this, data.getJSONArray("data"))
                    this.history.adapter = adapter
                }

                "get status" -> {

                    val position = data.getJSONObject("position")
                    val lat = position.getDouble("lat")
                    val lon = position.getDouble("lon")
//                    val alt = position.getDouble("alt")
                    val battery = data.getInt("battery")

                    this.runOnUiThread {
                        this.address.text = this._geocoder.address(lat, lon) ?: "위치 정보를 얻어올 수 없습니다."
                        this.battery.text = "배터리 : $battery%"
                    }
                }
            }
        } catch (e: Exception) {

            when (id) {

                "get status" -> {

                    this.runOnUiThread { this.address.text = "위치 정보를 찾을 수 없습니다." }
                }
            }

            Log.d("onResponse", e.message)
        }

    }

    override fun onError(id: String, message: String?) {

    }

    private fun requestPosition() {

        OYOReceiver(this, this.resources.getString(R.string.host), "get status", this)
                .route("status")
                .start()
    }
}
