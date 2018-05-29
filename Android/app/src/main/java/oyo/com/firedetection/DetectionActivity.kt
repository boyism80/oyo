package oyo.com.firedetection

import android.app.Activity
import android.content.Intent
import android.location.Address
import android.location.Geocoder
import android.os.Bundle
import android.support.v4.view.ViewPager
import android.support.v7.app.AppCompatActivity
import android.util.Log
import android.widget.TextView

import org.json.JSONObject

import butterknife.BindView
import butterknife.ButterKnife
import kotlinx.android.synthetic.main.activity_detection.*
import oyo.com.firedetection.Adapter.ViewPagerAdapter

class DetectionActivity : Activity(), OYOReceiver.Listener, ViewPagerAdapter.Listener {

    private lateinit var _data: JSONObject
    private lateinit var _geocoder: Geocoder


    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_detection)
        ButterKnife.bind(this)

        this._geocoder = Geocoder(this)

        try {
            val id = intent.getIntExtra("id", 0)
            OYOReceiver(this, this.resources.getString(R.string.host), "get detection", this)
                    .route("get")
                    .add("id", Integer.toString(id))
                    .start()
        } catch (e: Exception) {

            Log.d("onCreate", e.message)
        }

    }

    override fun onResponse(id: String, response: JSONObject) {

        try {
            when (id) {

                "get detection" -> {
                    this._data = response.getJSONObject("data")

                    val position = this._data.getJSONObject("position")
                    val lat = position.getDouble("lat")
                    val lon = position.getDouble("lon")

                    val hrefGmap = String.format("http://maps.googleapis.com/maps/api/staticmap?center=%f,%f&markers=color:blue%%7Clabel:OYO%%7C%f,%f&size=%dx%d&sensor=true&format=png&maptype=roadmap&zoom=18&language=ko&key=AIzaSyDO1LpjNHsEWBWLFdBPc6acJgyujd8ur2s", lat, lon, lat, lon, 640, 480)
                    val hrefInf = this._data.getString("inf")
                    val hrefVis = this._data.getString("vis")

                    val adapter = ViewPagerAdapter(this, this, hrefGmap, hrefInf, hrefVis)
                    this.viewpager.adapter = adapter

                    val addressList = this._geocoder.getFromLocation(lat, lon, 1)
                    this.address.text = "위치 : " + addressList[0].getAddressLine(0)

                    val tem = this._data.getDouble("tem")
                    this.temperature.text = "감지 온도 : $tem"
                }
            }
        } catch (e: Exception) {

            Log.d("onResponse", e.message)
        }

    }

    override fun onError(id: String, message: String?) {

    }

    override fun onViewPageClicked(position: Int) {

        try {

            var intent:Intent? = null
            var bundle = Bundle()

            when (position) {

                0 -> {
                    val pos = this._data.getJSONObject("position")
                    val lat = pos.getDouble("lat")
                    val lon = pos.getDouble("lon")

                    intent = Intent(this, GmapActivity::class.java)
                    bundle.putDouble("lat", lat)
                    bundle.putDouble("lon", lon)
                }

                1 -> {
                    intent = Intent(this, DetailViewactivity::class.java)
                    bundle.putString("href", this._data.getString("inf"))
                }

                2 -> {
                    intent = Intent(this, DetailViewactivity::class.java)
                    bundle.putString("href", this._data.getString("vis"))
                }
            }

            intent?.putExtras(bundle)
            startActivity(intent)

        } catch (e: Exception) {


        }


    }
}
