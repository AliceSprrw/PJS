**Gautier Kasperek
Alice Sparrow**

# PJS : Techniques d'affichages en réalité virtuelle
### Encadré par Florent Berthaut

## Networking avec Photon

Nous utilisons Photon pour la partie Networking de notre projet. Le menu permet de se connecter à une scène selon si on est spectateur ou artiste.
Les avatars instanciés lors de l'entrée dans la scène sont dans le repertoire Prefabs/Resources.

- myPlayerPrefab_big = avatar humanoïde / grande échelle
- myPlayerPrefab_normal = avatar humanoïde / échelle moyenne

- PlayerPrefab_big = avatar steamVR basique (uniquement les controlleurs) / grande échelle
- PlayerPrefab = avatar steamVR basique (uniquement les controlleurs) / échelle moyenne

## Ajout dans l'environnement

Nous avons ajouté au projet une partie "boids" qui simule le comportement de poissons dans l'aquarium.
Les utilisateurs peuvent créer des arbres (génération procédurale) dans l'environnement via un pointeur laser + clic.
Nous aurions aimé ajouter d'autres interactions pour l'utilisateur, notamment la gestion de plantes procédurales (L-Systèmes).

## Rigging et animation de squelettes

Nous avons mis en place un système de rigging grâce au package Animation *Rigging v0.2.5* toujours en révision dans *Unity 2019.2.18f1*.  Nous l'avons complété avec le script *VRRig.cs*. Le package est relativement stable mais est capricieux en fonction des types de squelette utilisé. Par exemple dans le cas d'un squelette du type, L'animation fonctionne normalement .:
- Hanche
	- Épaule
		- Humérus
			- Avant-Bras


Dans le cas d'un squelette du type (celui extrait de MakeHuman). Le rigging ne fonctionne pas aussi bien :
- Colonne vertébrale
	- Clavicule
		-	Humérus
			-	Avant-bras
