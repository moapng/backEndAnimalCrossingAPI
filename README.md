# backEndAnimalCrossingAPI

This project consumes the restFUL API http://acnhapi.com/ and acts as backend for https://github.com/moapng/frontEndAnimalCrossingAPI

Each controller handles its own creature’s data by http web GET-requests. 

The context-class was used for an in memory DB for the favourites-controller, but it wasn’t working as intended and thus has been removed.

Each class has a single responsibility, in line with the S from the SOLID-principle. 
