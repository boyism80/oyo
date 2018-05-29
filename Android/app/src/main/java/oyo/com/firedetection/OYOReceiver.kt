package oyo.com.firedetection

import android.app.Activity
import android.text.TextUtils

import org.json.JSONObject

import java.util.HashMap

class OYOReceiver(private val _activity: Activity, private var _host: String, private val _id: String, private val _listener: Listener) : Thread() {
    private val _parameters = HashMap<String, String>()

    interface Listener {

        fun onResponse(id: String, response: JSONObject)

        fun onError(id: String, message: String?)
    }

    fun route(name: String): OYOReceiver {

        if (!this._host.endsWith("/"))
            this._host += "/"

        this._host += name
        return this
    }

    fun add(name: String, value: String): OYOReceiver {

        this._parameters[name] = value
        return this
    }

    override fun run() {

        try {

            val multipart = MultipartUtility(this._host, "UTF-8")
            for (name in this._parameters.keys) {

                multipart.addFormField(name, this._parameters[name])
            }

            val result = TextUtils.join("\n", multipart.finish())
            val response = JSONObject(result)

            this._activity.runOnUiThread { _listener.onResponse(_id, response) }


        } catch (e: Exception) {

            this._activity.runOnUiThread { _listener.onError(_id, e.message) }
        }

    }
}
