using TreeVariants;

Tree<int> tree = new Tree<int>();
tree.Root = new TreeNode<int>() { Data =100 };
tree.Root.Children = new List<TreeNode<int>>()
{
    new TreeNode<int>() { Data =50, Parent = tree.Root },
    new TreeNode<int>()  {Data= 1 , Parent= tree.Root},
    new TreeNode<int>() { Data = 150, Parent = tree.Root }
};

tree.Root.Children[2].Children = new List<TreeNode<int>>()
{
    new TreeNode<int>() {Data =30 , Parent = tree.Root.Children[2]}
};

static void main(string[] args)
{
    Tree<Person> company = new Tree<Person>();
    company.Root = new TreeNode<Person>()
    {
        Data = new Person(100, "안형진", "CEO"),
        Parent = null

    };
    company.Root.Children = new List<TreeNode<Person>>()
    {
        new TreeNode<Person>()
        {
            Data = new Person(1, "스티브 잡스","애플판매원"),
            Parent = company.Root
        },

        new TreeNode<Person>() 
        { 
            Data = new Person(51, "일론 머스크", "경비원"),
            Parent =  company.Root
        },
        new TreeNode<Person>() 
        {
            Data = new Person(150,"주커버그", "캐셔"),
            Parent = company.Root
        }
    };
    company.Root.Children[2].Children = new List<TreeNode<Person>>()
    {

    };
}