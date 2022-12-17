namespace SportNews
{
    public class Discipline
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public static List<Discipline> Disciplines = new List<Discipline>()
        {
            new Discipline
            {
                Id=1,
                Name = "Футбол"
            },
            new Discipline
            {
                Id = 2,
                Name = "Хоккей"
            },
            new Discipline
            {
                Id=3,
                Name = "Воллейбол"
            },
            new Discipline
            {
                Id=4,
                Name = "Баскетбол"
            },
            new Discipline
            {
                Id = 5,
                Name = "Бокс / MMA"
            },
            new Discipline
            {
                Id=6,
                Name="Плавание"
            }

        };
        public static Discipline GetById(int id)
        {
            return Disciplines.FirstOrDefault(x => x.Id == id);
        }
    }
}