using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Task_2.Infostructure
{
    public class CommentInfo
    {
        public CommentInfo()
        {

        }

        public CommentInfo(string username, string comment, DateTime time)
        {
            Username = username;
            Comment = comment;
            Time = time.ToShortDateString() + " " + time.ToShortTimeString();
        }

        public string Username { get; set; }
        public string Comment { get; set; }
        public string Time { get; set; }
    }
}