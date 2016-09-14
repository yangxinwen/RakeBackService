using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCommon
{
    /// <summary>
    /// 播放器
    /// </summary>
    public class WebPlayer
    {
        public static string WebPlayerStr(int width, int high, string url)
        {
            try
            {
                string webplayerstr = "<object classid='clsid:D27CDB6E-AE6D-11cf-96B8-444553540000'" +
                                                     " codebase='http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0' height='" + high + "' width='" + width + "'>" +
                                                     " <param name='movie' " +
                                                     " value='vcastr22.swf?vcastr_file=" + url + "'>" +
                                                     " <param name='quality' value='high'> " +
                                                     " <param name='allowFullScreen' value='true' />  " +
                                                     " <embed " +
                                                     " src='vcastr22.swf?vcastr_file=" + url + "'  " +
                                                     " quality='high'  " +
                                                     " pluginspage='http://www.macromedia.com/go/getflashplayer' " +
                                                     " type='application/x-shockwave-flash' width='" + width + "' height='" + high + "'>" +
                                                     " </embed>" +
                                                     " </object> ";

                return webplayerstr;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
