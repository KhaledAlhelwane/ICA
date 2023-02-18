using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace ICA.Models
{
    public class Member
    {
        public int Id  { get; set; }
        public string ?FullName { get; set; }
        public string ?Photo { get; set; }
        public string ?PostionName { get; set; }
        //if it was from the board member group or not!
        public bool Postion { get; set; }
        public Assosiation ?Assosiation { get; set; }
        public int projectsId { get; set; }
        public projects ?projects { get; set; }
        public  Center ?center { get; set; }
    }
}
