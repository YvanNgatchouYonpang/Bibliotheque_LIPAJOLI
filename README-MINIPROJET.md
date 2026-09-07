# Mini-projet LIPAJOLI

La solution part de l'application MVC LIPAJOLI fournie et ajoute :
- `Bibliotheques.ApplicationCore` : entités, interfaces et règles métier.
- `Bibliotheques.Infrastructure` : EF Core SQLite et repositories.
- `Bibliotheques.API` : API REST + Swagger.
- `LIPAJOLI/Interfaces` et `LIPAJOLI/Services` : appels HTTP vers l'API pour la gestion des emprunts.

## Base de données
La base SQLite commune est `lipajoli.db` à la racine de la solution.
Les deux applications utilisent `../lipajoli.db`.

## Configuration
L'API utilise :
`BorrowingSettings:BorrowingDays = 10`

Le MVC utilise :
`Api:BaseUrl = https://localhost:7001/`

## Exécution
1. Ouvrir `LIPAJOLI.sln` dans Visual Studio 2022.
2. Configurer le démarrage de la solution avec les projets `Bibliotheques.API` et `LIPAJOLI`.
3. Démarrer l'API : Swagger est disponible sur `/swagger`.
4. Démarrer ensuite l'application MVC.
5. La page **Emprunts** utilise exclusivement l'API pour créer, consulter, retourner et supprimer les emprunts.

## Règles métier
- maximum 3 emprunts en cours par usager;
- un seul exemplaire d'un même livre par usager;
- 0 exemplaire disponible => emprunt refusé;
- 3 défaillances ou plus => emprunt refusé;
- date limite = date d'emprunt + 10 jours;
- retour en retard => +1 défaillance;
- retour => quantité disponible +1;
- un emprunt retourné ne peut pas être supprimé.
