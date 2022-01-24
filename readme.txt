Hello reviewer!

To run the project, open the .sln file and run IIS express.
Alternatively you can execute: "dotnet run" in the Shopping Basket folder and then open the page in a browser.

Backend C# source code can be found in: ShoppingBasket\Src\
C# unit tests can be found in: ShoppingBasket.UnitTest\
React source code can be found in: \ShoppingBasket\ClientApp\src\
Sadly no unit tests, redux or typescript for the front end - its just something quick to make the backend easier to interact with!

Front end structure:
- React Shop.js component loads, makes a rest get request to '/product' to populate the Products.js component.
- User clicks to change number of products, shopState useState hook updates the number on the page.
- User clicks checkout, isBasketOpen hook updates, makes a rest get request to '/basket/<basketString>' calculate what to display in basket. Where <basketString> is a coded description of basket contents.

Back end structure:
- Startup.cs initialises the singleton services which can be injected into constructors.
- ProductController and BasketController use the services to calculate their results and return them.
- The DatabaseService doesn't actually connect to a database for demo purposes, but instead uses hardcoded private values.
- The BasketService first converts the <basketString> to a Dictionary, then uses the DatabaseService to calculate a subtotal, then uses DiscountService to determine what discounts should be in the basket and finally calculates the total.
- Unit Tests are found in the ShoppingBasket.Unit test folder. TestBasket uses mock data to remove dependencies on other services.


