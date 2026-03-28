using System;
using System.Collections.Generic;

namespace YouTubeVideos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a list to store videos
            List<Video> videos = new List<Video>();

            // Create 3 Video objects
            Video video1 = new Video("Learning C#", "Austine", 15.5);
            Video video2 = new Video("Cooking Pasta", "Mary", 8.2);
            Video video3 = new Video("Football Highlights", "John", 12.0);

            // Add comments to each video
            video1.AddComment(new Comment("James", "Great tutorial!"));
            video1.AddComment(new Comment("Sarah", "Very clear explanation."));
            video1.AddComment(new Comment("Mike", "Helped me a lot."));

            video2.AddComment(new Comment("Anna", "Looks delicious!"));
            video2.AddComment(new Comment("Paul", "I’ll try this recipe."));
            video2.AddComment(new Comment("Lucy", "Easy to follow steps."));

            video3.AddComment(new Comment("Chris", "Amazing goals!"));
            video3.AddComment(new Comment("David", "Best match ever."));
            video3.AddComment(new Comment("Emma", "Loved the energy."));

            // Store videos in the list
            videos.Add(video1);
            videos.Add(video2);
            videos.Add(video3);

            // Iterate through videos and display details
            foreach (var video in videos)
            {
                Console.WriteLine($"Title: {video.Title}");
                Console.WriteLine($"Author: {video.Author}");
                Console.WriteLine($"Length: {video.Length} minutes");
                Console.WriteLine($"Number of Comments: {video.GetCommentCount()}");

                foreach (var comment in video.GetComments())
                {
                    Console.WriteLine($" - {comment.AuthorName}: {comment.Text}");
                }

                Console.WriteLine();
            }
        }
    }
}