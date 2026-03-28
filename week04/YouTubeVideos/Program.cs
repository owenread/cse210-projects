// Author: Owen Read
// YouTube Video Program

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("10 C# Tips You Didn't Know", "CodeWithMosh", 732);
        Video video2 = new Video("Object Oriented Programming Explained", "TechWithTim", 1245);
        Video video3 = new Video("Learn C# in 60 Minutes", "ProgrammingWithChris", 3600);

        video1.AddComment(new Comment("Alice", "This was super helpful, thanks!"));
        video1.AddComment(new Comment("Bob", "Tip #7 blew my mind."));
        video1.AddComment(new Comment("Carlos", "Finally someone explained this clearly."));

        video2.AddComment(new Comment("Diana", "Best OOP explanation I've seen."));
        video2.AddComment(new Comment("Evan", "The encapsulation part really clicked for me."));
        video2.AddComment(new Comment("Fiona", "Could you do a follow-up on inheritance?"));
        video2.AddComment(new Comment("George", "Sharing this with my whole class."));

        video3.AddComment(new Comment("Hannah", "I paused and coded along the whole way."));
        video3.AddComment(new Comment("Ivan", "Great pacing, not too fast."));
        video3.AddComment(new Comment("Julia", "This is exactly what I needed for my project."));

        List<Video> videos = new List<Video>();
        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title:    {video.GetTitle()}");
            Console.WriteLine($"Author:   {video.GetAuthor()}");
            Console.WriteLine($"Length:   {video.GetLength()} seconds");
            Console.WriteLine($"Comments: {video.GetNumComments()}");
            Console.WriteLine("--- Comments ---");

            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.GetCommenterName()}: {comment.GetCommentText()}");
            }

            Console.WriteLine();
        }
    }
}