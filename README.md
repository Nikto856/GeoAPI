# GeoAPI

Has the following endpoints:
GET /api/{rexource}?q={query}
Searches REST Countries for countries matching the query and returns a list of countries.

GET /api/all
Returns all countries from REST Countries.

GET /api/favorites
Returns all favorite countries stored in database*.

POST /api/favorites
Saves a country as a favorite in database*.

DELETE /api/favorites/{id}
Delete a favorite from database* with ID.

*Only In-memory database at this point, just to show functionality.


Class Country
Contains a few attributes mapped from the JSON returned by REST Countries API. More can easily be added. Also contains a unique ID, which is the converted integer from the countries CCN3 country code.

Class Favorite
Contains an ID, a Country and then a serialized JSON version of the Country, that can be easily stored in a database. The complex Country object is not mapped itself to the database. ID is set from the Couintry's ID.
