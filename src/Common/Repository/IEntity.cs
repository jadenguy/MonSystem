//-- Based on https://medium.com/falafel-software/implement-step-by-step-generic-repository-pattern-in-c-3422b6da43fd

namespace Common.Repository
{
    public abstract class IEntity
    {
        public int Id;
        public virtual bool Validate() => true;
    }
}