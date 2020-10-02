
using System;
using System.Windows.Media;

namespace DevTools.Modules.ColorTableMod
{
    public static class ColorExtention
    {
        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public static string ToHtmlHexadecimal6(this Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}", color.R, color.G, color.B);
        }

        public static string ToHtmlHexadecimal8(this Color color)
        {
            return string.Format("#{0:X2}{1:X2}{2:X2}{3:X2}", color.A, color.R, color.G, color.B);
        }
    }
}