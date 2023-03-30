# Basic C# ATM Program with List-Based Accounts
A simple ATM simulation program written in C# is included in this repository.
The program stores account information in a list rather than a database and offers basic functions such as creating an account with a card number, transferring money between two accounts, withdrawing money, and paying bills using a dictionary to check and pay. 

## Creating a User Account


Enter a valid 16-digit card number at the prompt to establish an account.
The account will be added to a list of accounts by the application.

## Transferring Funds


To transfer funds between two accounts, provide the card numbers for both accounts as well as the amount to be sent.
The money will be deducted from the sender's account and added to the receiver's account via the program.

## Withdrawing Funds


Enter the card number and the amount to withdraw to withdraw money.
The money will be deducted from the account balance by the program. 

## Payment of Bills

To pay a bill, enter the bill's name and the amount to be paid.
If the bill is valid, the application will verify a lexicon of bills and deduct the money from the account balance.

## Balance of Account

The application will display the account's remaining amount at the end of each transaction. 
