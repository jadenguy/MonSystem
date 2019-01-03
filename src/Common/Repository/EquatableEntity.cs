using System;

namespace Common.Repository
{
    public class EquatableStringEntity : IEntity, IEquatable<EquatableStringEntity>
    {
        public string Data { get; set; }
        public EquatableStringEntity(int id) : base(id) { }

        public bool Equals(EquatableStringEntity other)
        {
            return this.Id == other.Id && this.Data == other.Data;
        }
        public override string ToString() => $"{Id}: {Data}";
    }
}