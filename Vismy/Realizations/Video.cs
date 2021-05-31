using System;

namespace Vismy
{
    class Video
    {
        public readonly string Title;
        public readonly TimeSpan Length;

        public Video(in string title, in TimeSpan length)
        {
            Title = title;
            Length = length;
        }
    }
}