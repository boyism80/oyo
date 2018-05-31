package oyo.com.firedetection

import java.io.BufferedReader
import java.io.File
import java.io.FileInputStream
import java.io.IOException
import java.io.InputStreamReader
import java.io.OutputStream
import java.io.OutputStreamWriter
import java.io.PrintWriter
import java.net.HttpURLConnection
import java.net.URL
import java.net.URLConnection
import java.util.ArrayList

class MultipartUtility
/**
 * This constructor initializes a new HTTP POST request with content type
 * is set to multipart/form-data
 *
 * @param requestURL
 * @param charset
 * @throws IOException
 */
@Throws(IOException::class)
constructor(requestURL: String, private val charset: String) {
    private val boundary: String
    private val httpConn: HttpURLConnection
    private val outputStream: OutputStream
    private val writer: PrintWriter

    init {

        // creates a unique boundary based on time stamp
        boundary = "===" + System.currentTimeMillis() + "==="
        val url = URL(requestURL)
        httpConn = url.openConnection() as HttpURLConnection
        httpConn.useCaches = false
        httpConn.doOutput = true    // indicates POST method
        httpConn.doInput = true
        httpConn.setRequestProperty("Content-Type",
                "multipart/form-data; boundary=$boundary")
        outputStream = httpConn.outputStream
        writer = PrintWriter(OutputStreamWriter(outputStream, charset),
                true)
    }

    /**
     * Adds a form field to the request
     *
     * @param name  field name
     * @param value field value
     */
    fun addFormField(name: String, value: String?) {
        writer.append("--$boundary").append(LINE_FEED)
        writer.append("Content-Disposition: form-data; name=\"$name\"")
                .append(LINE_FEED)
        writer.append("Content-Type: text/plain; charset=$charset").append(
                LINE_FEED)
        writer.append(LINE_FEED)
        writer.append(value)
        writer.flush()
        writer.append(LINE_FEED)
    }

    /**
     * Adds a upload file section to the request
     *
     * @param fieldName  name attribute in <input type="file" name="..."></input>
     * @param uploadFile a File to be uploaded
     * @throws IOException
     */
    @Throws(IOException::class)
    fun addFilePart(fieldName: String, uploadFile: File) {
        val fileName = uploadFile.name
        writer.append("--$boundary").append(LINE_FEED)
        writer.append(
                "Content-Disposition: form-data; name=\"" + fieldName
                        + "\"; filename=\"" + fileName + "\"")
                .append(LINE_FEED)
        writer.append(
                "Content-Type: " + URLConnection.guessContentTypeFromName(fileName))
                .append(LINE_FEED)
        writer.append("Content-Transfer-Encoding: binary").append(LINE_FEED)
        writer.append(LINE_FEED)
        writer.flush()

        val inputStream = FileInputStream(uploadFile)
        val buffer = ByteArray(4096)
        while(true) {
            val bytesRead = inputStream.read(buffer)
            if(bytesRead == -1)
                break

            outputStream.write(buffer, 0, bytesRead)
        }
        outputStream.flush()
        inputStream.close()
        writer.append(LINE_FEED)
        writer.flush()
    }

    /**
     * Adds a header field to the request.
     *
     * @param name  - name of the header field
     * @param value - value of the header field
     */
    fun addHeaderField(name: String, value: String) {
        writer.append("$name: $value").append(LINE_FEED)
        writer.flush()
    }

    /**
     * Completes the request and receives response from the server.
     *
     * @return a list of Strings as response in case the server returned
     * status OK, otherwise an exception is thrown.
     * @throws IOException
     */
    @Throws(IOException::class)
    fun finish(): List<String> {
        val response = ArrayList<String>()
        writer.append(LINE_FEED).flush()
        writer.append("--$boundary--").append(LINE_FEED)
        writer.close()

        // checks server's status code first
        val status = httpConn.responseCode
        if (status == HttpURLConnection.HTTP_OK) {
            val reader = BufferedReader(InputStreamReader(httpConn.inputStream))

            while(true) {

                val line = reader.readLine() ?: break
                response.add(line)
            }
            reader.close()
            httpConn.disconnect()
        } else {
            throw IOException("Server returned non-OK status: $status")
        }
        return response
    }

    companion object {
        private val LINE_FEED = "\r\n"
    }
}
