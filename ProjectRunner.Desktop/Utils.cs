﻿using System;

namespace ProjectRunner.Desktop
{
    public class Utils
    {
        public static string HandleExceptionMessage(Exception exception)
        {

            return (exception.InnerException != null) ? exception.Message + Environment.NewLine + exception.InnerException.Message : exception.Message;
        }
    }
}
