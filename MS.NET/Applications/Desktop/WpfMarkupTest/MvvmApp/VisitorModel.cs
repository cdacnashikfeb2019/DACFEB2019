using System;

namespace MvvmApp
{
    public class Visitor
    {
        public string Name { get; set; }

        public int Frequency { get; set; } = 1;

        public DateTime Recent { get; set; } = DateTime.Now;

        public void Revisit()
        {
            Frequency += 1;
            Recent = DateTime.Now;
        }
    }

    public class VisitorModel
    {
        private Document<Visitor> dataSource;

        public VisitorModel()
        {
            dataSource = Document.Open<Visitor>("mysite.xml");
        }

        public Visitor[] ReadVisitors()
        {
            return dataSource.ToArray();
        }

        public void WriteVisitor(string name)
        {
            Visitor visitor = dataSource.Find(e => e.Name == name);

            if (visitor == null)
                dataSource.Add(new Visitor { Name = name });
            else
                visitor.Revisit();

            dataSource.Save();
        }
    }
}
