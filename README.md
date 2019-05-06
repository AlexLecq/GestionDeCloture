# GestionDeCloture
## Contexte
Ce projet s'inscrit dans une situation professionnalle donné par ma formation de BTS SIO. Le but est de réaliser certaine mission afin de répondre aux besoins d'une entreprise fictive, dans notre cas l'entreprise fictive est GSB, une entreprise pharmaceutique. Cette entreprise veut mettre en place une solution de gestion et de saisi de fiche de frais pour les visiteurs, lors de déplacements. 

## Description
Cette solution consiste à mettre à jour la base de données des fiches de frais afin d'automatiser la cloture des saisis de fiche de frais par les visiteurs.
Pour répondre à ce besoin, nous avons utiliser un service windows.

## Technologies
Voici les technologies utilisés durant cette mission :
- Le framewrok .NET avec le langage C#

- Service Windows

- Hangfire, un outil de monitoring

  

  > La Documentation Technique se situe dans le dossier "HELP" 

  ## Productions

  Afin d’automatiser la mise à jour de l’état des fiches de frais, un service windows est mis en place à l’aide des technologies de Microsoft .NET et le langage C#. La solution est composée d’une Bibliothèque de classe réutilisable, ainsi que sa Bibliothèque de classe tests, comportant la classe d’accès à la base de données et d’une classe permettant la gestion des dates. Elle est aussi composé du service en lui même, lui comporte les différents Services et Contrôleurs utilisé pour le bon fonctionnement de l’application. Et enfin, le service Hangfire hébergé avec ASP .NET Core, qui permet de mettre un visuel sur les requêtes envoyées et de voir les éventuelles erreurs dans le but d’avoir un débogage optimal. La configuration de la chaîne de connexion, de la base de données, se fait grâce au fichier de configuration de la solution « App.config » pour le service, et du fichier « appsettings.json » pour Hangfire.
