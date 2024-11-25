namespace Parking_Lot.Trello
{
    public class Board : BoardComponent
    {
        public string id {  get; }
        public string name { get; }

        public string privacy { get; } = "PUBLIC";
        public string url { get; }
        public List<User> members { get; }
        public List<BoardComponent> list { get; }

        public Board(string id, string name, string privacy, string url, List<User> members, List<BoardComponent> list)
        {
            this.id = id;
            this.name = name;
            this.privacy = privacy;
            this.url = url;
            this.members = members;
            this.list = list;
        }

        public override void delete()
        {
            foreach(BoardComponent component in list)
            {
                component.delete();
            }
            list.Clear();
        }
        public void addMember(User user)
        {
            members.Add(user);
        }
        public void removeMember(User user)
        {
            members.Remove(user);
        }
    }
}
