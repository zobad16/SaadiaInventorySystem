using System;

namespace SaadiaInventorySystem.Client.Util
{
    public static class ExceptionEntensions
    {
        public static string GetFullMessage(this Exception ex)
        {
            return ex.InnerException == null
                 ? ex.Message
                 : ex.Message + "->" + ex.InnerException.GetFullMessage();
        }

    }
}
