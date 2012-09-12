using System.IO;
using System.Web.UI;

namespace BusinessLogic.Render
{
    public class RenderToString
    {
        public static string RenderControl(Control control)
        {
            var tw = new StringWriter();

            // *** Simple rendering - just write the control to the text writer
            // *** works well for single controls without containers
            var writer = new Html32TextWriter(tw);
            control.RenderControl(writer);
            writer.Close();

            return tw.ToString();
        }
    }
}
