using System;
namespace EngSchool.Entities.Exception
{
    public abstract class NotFoundException : System.Exception
    {
        public NotFoundException(string message): base(message) { }
    }
}
