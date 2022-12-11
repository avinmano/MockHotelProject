# MockHotelProject

## Descrizione del progetto:

Questo Progetto è una WebApi realizzata con .Net 6 utilizzando le seguenti metodologie e librerie:

- Minimal Api
- Entity Framework Core
- MediatR

Database utilizzato: SqlServer2022


## Struttura del progetto
La solution è suddivisa in 4 WebApi (ognuna dedicata ad una delle entità princiapli del progetto: Accomodations, RoomType, Price, Rules), un progetto contenente gli handler del pattern Mediator e un progetto dedicato al DataLayer.


## Esecuzione di una richiesta

Quando un client consuma una Api del prgetto, viene generata ed inviata una request che, tramite il mediator, viene intercettata dall'handler corrsipondente. 
Questo, a sua volta, elabora la request effettuando le necessarie chiamate ai repository, quindi restituisce all'entry point i dati richiesti.


## Informazioni aggiuntive
Ogni Accomdation puà definire le proprie RoomType e la loro posizione in una gerarchia piramidale.
Ogni accomdation può creare un vincolo sulla percentuale di differenza di prezzo tra una roomtype di livello superiore ed una roomtype di livello inferiore 
(che viene verificato sempre in caso di inserimento o aggiornamento dei prezzi). Tale percentuale è definita all'interno della tabella Rules.

