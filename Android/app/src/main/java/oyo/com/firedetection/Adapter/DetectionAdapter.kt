package oyo.com.firedetection.Adapter

import android.app.Activity
import android.content.Context
import android.util.Log
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import android.widget.BaseAdapter
import com.androidquery.AQuery
import kotlinx.android.synthetic.main.detection_listview_item.view.*
import org.json.JSONArray
import oyo.com.firedetection.R

class DetectionAdapter
(

    private val _activity: Activity, private val _detections: JSONArray) : BaseAdapter() {

    override fun getCount(): Int {
        return this._detections.length()
    }

    override fun getItem(i: Int): Any? {

        return this._detections.get(i)
    }

    override fun getItemId(i: Int): Long {

        return i.toLong()
    }

    override fun getView(i: Int, contentView: View?, viewGroup: ViewGroup): View? {
        var contentView = contentView

        try {

            if (contentView == null) {

                val inflater = this._activity.getSystemService(Context.LAYOUT_INFLATER_SERVICE) as LayoutInflater
                contentView = inflater.inflate(R.layout.detection_listview_item, null)
            }

            if (contentView == null)
                return null

            val aq = AQuery(contentView)
            val data = this._detections.getJSONObject(i)
            val position = data.getJSONObject("position")
            contentView.address.text = position.getString("address")
            contentView.temperature.text = "감지 온도 : " + data.getDouble("temperature")
            contentView.datetime.text = data.getString("date")
            aq.id(contentView.thumb).image(data.getString("thumb"))

        } catch (e: Exception) {


            Log.d("getView", e.message)
        }

        return contentView
    }
}
