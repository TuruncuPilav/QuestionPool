using Core.Data.Core;
using Core.Data.Entity;
using Core.Repositories.Classes;
using static Core.Data.Core.SoruHavuzuContext;

namespace YourNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            DataSeeding.Seed(new SoruHavuzuContext());

            MemberRepository x = new MemberRepository();
            // var members = x.Get();

            // foreach (var item in members)
            // {
            //     Console.WriteLine()
            // }
        }
    }
}
