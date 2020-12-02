using System;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries);

            Article article = new Article(input[0], input[1], input[2]);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] command = Console.ReadLine().Split(": ");
                string cmd = command[0];
                string change = command[1];

                switch (cmd)
                {
                    case "Edit":
                        article.Edit(change);
                        break;

                    case "ChangeAuthor":
                        article.ChangeAutor(change);
                        break;

                    case "Rename":
                        article.Rename(change);
                        break;
                   
                }
            }
            Console.WriteLine(article.ToString());
        }
    }

    class Article
    {
        public Article(string title, string content, string autor)
        {
            Title = title;
            Content = content;
            Autor = autor;

        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string Autor { get; set; }

        public void Edit(string content)
        {
            Content = content;
        }

        public void ChangeAutor(string autor)
        {
            Autor = autor;
        }

        public void Rename(string title)
        {
            Title = title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Autor}"; 
        }
    }
}
