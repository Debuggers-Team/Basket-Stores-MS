# Basket-Stores-MS

## Team members

- Mohammad Sarayrah (Team leader)
- Islam Alsawaftah
- Alaaldin alhanini
- Hanan Nathem Saadeh
- Yahia Khalil

## Introduction

This is an e-commerse website build for selling of any products online. In this project we have mainly considered to adding the products to the users cart and again let them decide the amount of item to buy. The users can increase or decrease the items amount in the cart. After that the user may pay and get the order successful. The Project also uses the mail facilities to the users.

## Wireframes

- Home Page

![Home Page](./img/HomePage.jpeg)

- Login Page

![Login Page](./img/Login.jpeg)

- SignUp Page

![SignUp Page](./img/SingUp.jpeg)

- Cart Page 

![Cart Page](./img/CartPage.jpeg)


## User Stories

1. As a new user, I want to register by creating a username and password so that the system can remember me and my data,
I should have a valid username and password to meet validation rules by the web application, and keep trying to fix register issues if occur until all validations take place.

Estimated Time : 1 Day

2. As a registered user, I want to be able to securely log in to the system so that my information can only be accessed by me.
the system can authenticate me and I can trust it.

Estimated Time : 1 Day

3. As a registered user, I want to be able to occasionally change my password so that I can keep it secure. and to be able to request a new password so that I don't permanently lose access to my data if I forget it.

Estimated Time : 1 Day

4. As a registered user, I need to search for products, so that I can find the ones I want to buy and pass them to my cart, and be able to add feedback.

Estimated Time : 1 Day

5. As an administrative user, I want to be able to show all users and their orders, so that I can know the status of each product

Estimated Time : 1 Day


## Domain Modeling

Basket ER digram 

![Basket ER digram](./img/ERD.png)

Product Table: 

- Have a primary key, and it has the fields of name, Price,InStock, description, and discount. Relationship is (many-to-one) with the  table Category, 

- Relationship:

- one to many with the table Cart

- one to many with the FeedBack table

Category Table: 

- Have a primary key, and it has the fields of name,

- Relationship:

-  is (one-to-many) with the table Product.

User Table :

- Have a Primary key , and it has filds of username,Email, Password,Phone number.

- Relationship :

- one to one relation with cart table.

- one to many relation with feedback table.

Payment Table: 

- Have a Primary key, and it has fields of payment type.

- Relationship : 

- a one to one relation with the cart table.

Cart Table :

- Have a primary key, and it has the fields of TotalCost,State and Totalquantity. 

- Relationship:

- one to one with users table.

- one to one with paymenttype table.

- many to many with products

Feeback table: 

- Join Table, have a Id as primary key , and it has the fields of UserId, ProductId, description,rating.

- Relationship:

- many-to-one with Users Table

- many-to-one with Products table

CartProduct table: 

- Join Table, have CartId an ProductId as forign keys, quantity. 

- Relationship:

- many-to-one with Products Table

- many-to-one with Cart table

FavouriteProduct table: 

- Join Table, have FavouriteId an ProductId as forign keys, quantity. 

- Relationship:

- many-to-one with Products Table

- many-to-one with Favourite table

Favourite: Have a primary Key, and it has the fields of User

- Relationship:

- many-to-one with FavouriteProduct table
