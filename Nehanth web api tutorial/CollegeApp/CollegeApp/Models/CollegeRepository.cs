namespace CollegeApp.Models
{
    public static class CollegeRepository
    {
        public static IList<Student> Students { get; } = new List<Student>()
            {
                new Student {
                    Id = 1,
                    StudentName = "Student name 1",
                    Email = "StudentEmail1@gmail.com",
                    Address = "Student 1 Address",
                },
                new Student {
                    Id = 2,
                    StudentName = "Student name 2",
                    Email = "StudentEmail2@gmail.com",
                    Address = "Student 2 Address",
                }
            };
    }
}
