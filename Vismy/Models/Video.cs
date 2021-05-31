using System;

namespace Vismy.Models
{
    // TODO: need to realize saving byte[] video as mp4 file
    public class Video
    {
        public string Title { get; }
        public TimeSpan Length { get; }
        public string Path { get; }

        public Video(string title, TimeSpan length, string path)
        {
            Title = title;
            Length = length;
            Path = path;
        }
    }
}