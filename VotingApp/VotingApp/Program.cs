using System;
using System.IO;
using VotingApp.Entities;
using VotingApp.Service.Abstract;
using VotingApp.Service.Concrete;

namespace VotingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            VoitingApp voitingApp = new VoitingApp(new UserService(), new CategoryServcie(), new UserCategoryService());
            voitingApp.Init();
            voitingApp.Voiting();
        }
    }
}
