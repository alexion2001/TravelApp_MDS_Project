### Componența Echipei
- Filip Constantin
- Talida Dobre
- Alexandra Ion
- Maria Pătulea

### Tema Aplicației
Tema aleasa pentru proiectul nostru este o aplicație de android care are ca utilitate planificarea unei vacante, în funcție de cerințele utilizatorului. Aceasta va permite găsirea unei vacanțe potrivite in funcție de bugetul, perioada și alte date introduse de user.

#### Tehnologii Folosite
```ASP.NET, Angular```

### User Stories
https://trello.com/b/KaT9r3rW/user-stories

![2022-06-13 (5)](https://user-images.githubusercontent.com/75331740/173365024-035bc4d6-7e39-405e-bb4a-e0004107e2eb.png)

### Backlogs
https://trello.com/b/gWEmhbgM/backlogs

![Screenshot (133)](https://user-images.githubusercontent.com/79529127/173921379-1ccce439-a37b-4be7-85e8-eae9ce4e7702.png)

### Diagrama UML

![DiagramaUML](https://user-images.githubusercontent.com/75331740/173363686-f3ec143f-a687-4111-88e5-35c891dfc4fb.png)

### Diagrama Conceptuală pentru baza de date a proiectului:

![2022-05-16 (2)](https://user-images.githubusercontent.com/75331740/168601981-871f48fb-1ec0-4716-94de-d89a642ec655.png)

### Bug Reporting
În procesul de realizare a aplicației au apărut o serie de bugs, atât în partea de frontend, cât și în cea de backend. Câteva exemple de astfel de erori cu care ne-am confruntat sunt:
- În cadrul paginii de Forum, în prima implementare se afișa doar cea mai recentă recenzie, dar am reușit, prin conectatea cu baza de date, să afișăm toate recenzile userilor.
- O serie de conflicte legate de manipularea DOM-ului care au necesitat o atenție sporită.
- Restrângerea filtrelor de căutare.

### Refactoring
Proiectul nostru a trecut printr-o serie de modificări (refactoring), cu scopul de a îmbunătății calitatea codului și păstrând funcționalitatea sa. Astfel, rezultatul final conține o arhitectura internă stabilă și performantă.

### Design Patterns
Scheletul intern al aplicatiei este construit folosind ONION architecture, divizand componentele si entitatile in layere ce nu comunica intre ele. Astfel, avem layer-ul de Domain unde sunt create structurile entitatilor ce urmeaza a fi integrate in baza de date, Application layer-ul care contine logica de business, viewmodels si interfete care sunt implementate in cele din urma in Infrastructure layer.
In plus, pentru a asigura structura modulara a aplicatiei, este folosit Mediator pattern care are la baza principiul numit "Separation of Concerns". Acesta se asigura ca sub nicio forma 2 componente nu comunica intre ele, astfel evitand leak-uri de informatie si crash-ul intregii aplicatii. Daca un serviciu este down, datorita pattern-urilor implementate, aplicatia va continua sa ruleze doar cu serviciile disponibile, iar utilizatorul poate in continuare sa fie in contact cu produsul final.
### DEMO

http://sc.com.ly/show/25ae7a5e-9224-41d8-ab32-812f78daa46c
