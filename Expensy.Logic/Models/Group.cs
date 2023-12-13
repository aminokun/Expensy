namespace Expensy.Logic.Models
{
    public class Group
    {
        public int Group_Id { get; set; }
        public string GroupName { get; set; }
        public List<User> Users { get; set; }
    }

}
