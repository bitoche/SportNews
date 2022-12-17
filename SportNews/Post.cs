using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportNews
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public User Author { get; set; }
        public string? Image { get; set; }
        public Discipline? Discipline { get; set; }

        public Post(int id, string title, DateTime created, string description, User author, string image, Discipline discipline)
        {
            Id = id;
            Title = title;
            Created = created;
            Description = description;
            Author = author;
            Image = image;
            Discipline = discipline;
        }
        public Post() { }
    }
}
