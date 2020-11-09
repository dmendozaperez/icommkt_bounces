using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

public class GetBounces
    {
    [Microsoft.SqlServer.Server.SqlFunction()]
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Assert, Unrestricted = true)]
    public static string get_bounces(SqlString count, SqlString offset, SqlString fromdate, SqlString todate)
    {
        string response_str = "";
        HttpWebRequest request = null;
        string apiKey = "d05d32c5-4703-465b-9b84-f0e43422263b";
        try
        {
            string myUrl = "https://api.trx.icommarketing.com/bounces?count=" + count.ToString() + "&offset=" + offset.ToString() + "&fromdate=" + fromdate.ToString() + "&todate=" + todate.ToString() +"";
            request = (HttpWebRequest)WebRequest.Create(myUrl);
            request.Headers["Authorization"] = "Bearer X-Trx-Api-Key";
            request.ContentType = "application/json";
            request.Headers.Add("X-Trx-Api-Key", apiKey);

            HttpWebResponse myHttpWebResponse = (HttpWebResponse)request.GetResponse();            

            var response = (HttpWebResponse)request.GetResponse();
            response_str = new StreamReader(response.GetResponseStream()).ReadToEnd();

        }
        catch (Exception exc)
        {
            response_str = exc.Message;
        }
        return response_str;
    }
}

