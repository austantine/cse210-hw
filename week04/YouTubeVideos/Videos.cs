namespace YouTubeVideos
{
    public class Video
    {
        private string _title;
        private string _author;
        private double _length;
        private List<Comment> _comments = new List<Comment>();

        public Video(string title, string author, double length)
        {
            _title = title;
            _author = author;
            _length = length;
        }

        public string Title => _title;
        public string Author => _author;
        public double Length => _length;

        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
        }

        public int GetCommentCount()
        {
            return _comments.Count;
        }

        public List<Comment> GetComments()
        {
            return _comments;
        }
    }
}