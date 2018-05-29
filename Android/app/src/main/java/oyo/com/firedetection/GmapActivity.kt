package oyo.com.firedetection

import android.os.Bundle
import android.support.v4.app.FragmentActivity
import com.google.android.gms.maps.CameraUpdateFactory
import com.google.android.gms.maps.GoogleMap
import com.google.android.gms.maps.OnMapReadyCallback
import com.google.android.gms.maps.SupportMapFragment
import com.google.android.gms.maps.model.LatLng
import com.google.android.gms.maps.model.MarkerOptions

class GmapActivity : FragmentActivity(), OnMapReadyCallback {

    private lateinit var _map: GoogleMap
    private var _lat: Double = 0.0
    private var _lon: Double = 0.0

    override fun onCreate(savedInstanceState: Bundle?) {
        super.onCreate(savedInstanceState)
        setContentView(R.layout.activity_gmap)

        val bundle = this.intent.extras
        this._lat = bundle.getDouble("lat")
        this._lon = bundle.getDouble("lon")

        val mapFragment = supportFragmentManager.findFragmentById(R.id.map) as SupportMapFragment
        mapFragment.getMapAsync(this)
    }

    override fun onMapReady(googleMap: GoogleMap) {
        this._map = googleMap

        // Add a marker in position and move the camera
        val position = LatLng(this._lat, this._lon)
        this._map.addMarker(MarkerOptions().position(position).title("Marker in position"))
        this._map.moveCamera(CameraUpdateFactory.newLatLngZoom(position, 18f))
    }
}
