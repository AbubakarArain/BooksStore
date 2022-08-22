## Project ReadMe File

### How to run the project

Click the run button in rider (used to create this project) or in visual studio and swagger should be launched with following url https://localhost:7130/swagger/index.html, displaying the 5 endpoints
1. GET/Books - Returns all books in the database and provides a option to search specific books by providing a search parameter 
2. POST/Books - Adds the book to database, no need to provide id as its auto generated
3. PUT/Books - Updates the book, you must provide the correct id of the book to update, along with the details to update
4. Get/Books - Gets a book by id
5. Delete/Books - Deletes a book by id

### How to run the tests

I have written tests for controller, service and database layer.

1. Controller - these mock the service layer and assert against mocked data
2. Service - these mock the database layer and assert against mocked data
3. Database - these test against the database data, so I only wrote 2 tests to test the get methods as testing create, update and delete would require altering the database and therefore be flaky

The reason the tests are setup the way described above is because I was exploring the best solution to use for my database, and in the process ended up having testable logic in the database layer and could not test in a meaningful way the controller and service layer because it contains little to no logic to against test. However, in production level, both controller and service layer would have meaningful logic that we can test against, such as mapping, filtering, validation etc.

### Assumption made

1. This project will be consumed internally and not by the end user, considering this I have exposed some information, such as Id that otherwise would not be visible to end users
2. Considering the time and my knowledge of swagger, I only setup swagger to include minimal information. In a production level, there will be much more swagger information e.g., status codes, contract examples etc.
