using handball_IS.Gateways;
using handball_IS.Objects.Actors.super;

namespace handball_IS.Modules.Actors.super
{
    public class PersonModule
    {
        private readonly PersonTableGateway personTableGateway;
        public PersonModule(PersonTableGateway personTableGateway)
        {
            this.personTableGateway = personTableGateway;
        }

        public async Task<(bool success, string role, int? coachId)> Login(string username, string password)
        {
            // Najdi osobu podle uživatelského jména
            var person = await personTableGateway.GetPersonByUsername(username);

            if (person == null)
            {
                return (false, string.Empty, null); // Uživatel neexistuje
            }

            if (person.Password != password)
            {
                return (false, string.Empty, null); // Nesprávné heslo
            }

            var role = await personTableGateway.GetRoleByPersonId(person.Id);
            int? coachId = null;
            if (role == "Coach")
            {
                coachId = await personTableGateway.GetCoachIdByPersonId(person.Id);
            }

            if ( string.IsNullOrEmpty(role))
            {
                role = "User";
            }

            return (true, role, coachId);
        }

        public async Task AddPerson(Person person)
        {
            await personTableGateway.InsertPerson(person);
        }
    }
}
