# Bilbayt FullStackCodeTest-v21.07
Code Test

1. We would like you to create a web API project on .NET Core which will have these pages below;
    * Registration form: This form will have these fields
      * 1.1.1.1. username
      * 1.1.1.2. password
      * 1.1.1.3. full name
    * 1.1.2. It will create a user on the database
    * 1.1.3. After the user creation, it will send a Welcoming email via Sendgrid ( No need to create a unique code for verification.)
    * 1.2. Login form:
      * 1.2.1. This form will have a username and a password field.
      * 1.2.2. It will check the given credentials and log the user in using JWT
    * 1.3. Profile Page
      * 1.3.1. After successful login, the user will be redirected to the profile screen.
      * 1.3.2. The screen will get the logged-in user’s Full Name and displays it on the page via a protected API call
2. We need you to add a unit test for login API. 
3. The technical stack will be like below;
    * 3.1. DB: Cosmos DB preferred but Mongo DB can be used too.
    * 3.2. Front End: You are free to choose one of any framework like angular, react, or you can use jquery or even vanilla js.

**Dev Notes**:
* .Net Core 3.1, IDE VS2019
* Angular used for Front End.
* NUnit & FakeItEasy used for unit testing.
* Instead of Cosmos or MongoDB, I have used LiteDB which is an embedded serverless MongoDB-like database, so just need to run the application in VS2019 and DB store will work 
without any configuration changes. (https://www.litedb.org/)
* Welcome email not implemented: Reason - I was not able to create an account in SendGrid, tried with couple of email's but they flagged my account.
* User password not encrypted as this is a simple demo.

**APIs**
* Register User - Post http://localhost:24841/api/user/register
  * Payload - {"userName":"rob","password":"demo", "fullName": "Rob J", "email": "rob@demo.com"}
* Login User - Post http://localhost:24841/api/user/login
  * Payload - {"userName":"rob","password":"demo"}
* Get User - Get http://localhost:24841/api/user/{id}
  * This is a protected api and needs a Jwt Bearer token.
  * {id} - e.g. 62a8494e-38b7-4153-8000-faa7d398baf5
