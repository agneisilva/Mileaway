using DotNetCore.Domain;

namespace Architecture.Domain
{
    public class Usuario : Entity<long>
    {
        public Usuario
        (
            Nome name,
            Email email,
            Auth auth
        )
        {
            Name = name;
            Email = email;
            Auth = auth;
            Activate();
        }

        public Usuario(long id) : base(id) { }

        public Nome Name { get; private set; }

        public Email Email { get; private set; }

        public StatusUser Status { get; private set; }

        public Auth Auth { get; private set; }

        public void Activate()
        {
            Status = StatusUser.Active;
        }

        public void Inactivate()
        {
            Status = StatusUser.Inactive;
        }

        public void UpdateName(string firstName, string lastName)
        {
            Name = new Nome(firstName, lastName);
        }

        public void UpdateEmail(string email)
        {
            Email = new Email(email);
        }
    }
}
