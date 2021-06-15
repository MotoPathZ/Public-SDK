using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MPZ.Tools
{
    public class Logger
    {
        public delegate Task<string> Message(string text, LogType type, string nameCallingClass);
        public Message messageSend;
        public Message messageShow;
        public enum LogType:int { Messages, Wardings, Errors }
        private LogType _logTypeShow;
        private int maxStringCount=0;
        public Logger(LogType logTypeShow)
        {
            _logTypeShow = logTypeShow;
            messageSend = LogSend;
            messageShow += LogShow;
        }
        public async void Log(string text)
        {
            var stacktrace = new System.Diagnostics.StackTrace();
            var prevframe = stacktrace.GetFrame(1);
            var method = prevframe.GetMethod();

            await LogCheck(text, LogType.Messages, method.ReflectedType.Name);
        }
        public async void Log(string text,LogType type)
        {
            var stacktrace = new System.Diagnostics.StackTrace();
            var prevframe = stacktrace.GetFrame(1);
            var method = prevframe.GetMethod();

            await LogCheck(text, type, method.ReflectedType.Name);
        }
        public async Task<string> TaskLog(string text,LogType type)
        {
            var stacktrace = new System.Diagnostics.StackTrace();
            var prevframe = stacktrace.GetFrame(1);
            var method = prevframe.GetMethod();

            return await LogCheck(text, type, method.ReflectedType.Name);
        }
        private async Task<string> LogCheck(string text, LogType type, string nameCallingClass)
        {
            if (_logTypeShow > type)
            {
                string textTemplate = $"{DateTime.Now} | [{type}] | MPZ Library | {nameCallingClass} | {text}";
                if (maxStringCount == 0)
                {
                    string textForConsole = "";
                    for (int x=0; x < textTemplate.Length; x++)
                    {
                        textForConsole += "-";
                    }
                    Console.WriteLine($"{textForConsole}");
                }
                if (textTemplate.Length > maxStringCount) maxStringCount = textTemplate.Length;
                return await messageSend.Invoke(text, type, nameCallingClass);
            }
            else return "";
        }

        private async Task<string> LogSend(string text, LogType type, string nameCallingClass)
        {
            return await messageShow.Invoke(text, type, nameCallingClass);
        }
        private Task<string> LogShow(string text, LogType type, string nameCallingClass)
        {
            Console.WriteLine($"{DateTime.Now} | [{type}] | MPZ Library | {nameCallingClass} | {text}");
            return Task.FromResult(text);
        }
    }
}
