using Bibliotheques.ApplicationCore.Entities;
using Bibliotheques.ApplicationCore.Interfaces;
using Bibliotheques.Infrastructure.Data;
namespace Bibliotheques.Infrastructure.Repositories;
public class LivreRepository(BibliothequeDbContext c) : Repository<Livre>(c), ILivreRepository { }
