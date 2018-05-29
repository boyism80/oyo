package oyo.com.firedetection.Adapter

import android.content.Context
import android.support.v4.view.PagerAdapter
import android.support.v4.view.ViewPager
import android.view.LayoutInflater
import android.view.View
import android.view.ViewGroup
import com.androidquery.AQuery
import kotlinx.android.synthetic.main.custom_layout.view.*
import oyo.com.firedetection.R

class ViewPagerAdapter(private val _context: Context, private val _listener: Listener, hrefGmap: String, hrefInf: String, hrefVis: String) : PagerAdapter() {
    private val _hrefs: Array<String> = arrayOf(hrefGmap, hrefInf, hrefVis)

    interface Listener {

        fun onViewPageClicked(position: Int)
    }

    override fun getCount(): Int {
        return this._hrefs.size
    }

    override fun isViewFromObject(view: View, `object`: Any): Boolean {
        return view === `object`
    }

    override fun instantiateItem(container: ViewGroup, position: Int): Any {
        val inflater = this._context.getSystemService(Context.LAYOUT_INFLATER_SERVICE) as LayoutInflater
        val view = inflater.inflate(R.layout.custom_layout, null)
        var aq = AQuery(view)

        aq.id(view.image).image(this._hrefs[position])
        view.image.setOnClickListener{ _listener.onViewPageClicked(position) }

        val vp = container as ViewPager
        vp.addView(view, 0)
        return view
    }

    override fun destroyItem(container: ViewGroup, position: Int, `object`: Any) {
        val vp = container as ViewPager
        val view = `object` as View
        vp.removeView(view)
    }
}
