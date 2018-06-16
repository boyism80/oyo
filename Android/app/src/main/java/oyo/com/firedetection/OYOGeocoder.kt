package oyo.com.firedetection

import android.content.Context
import android.location.Address
import android.location.Geocoder

class OYOGeocoder(context: Context) {

    private val _geocoder: Geocoder

    init {

        this._geocoder = Geocoder(context)
    }

    fun address(lat: Double, lon: Double): String? {

        try {
            val addressList = this._geocoder.getFromLocation(lat, lon, 1)
            return addressList[0].getAddressLine(0)
        } catch (e: Exception) {

            return null
        }
    }
}