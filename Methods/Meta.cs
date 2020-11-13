using System.IO;
using System.Reflection;

namespace Schlauchboot.Hosting.SoundCloud.Manager.Methods
{
    public class Meta
    {
        public string GetAssemblyPath()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().GetName().CodeBase).Remove(0, 6); ;
        }
    }
}
