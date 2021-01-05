// Banking simulator
// Add, manage, delete and view information for up to 10 bank accounts
// 1
// January 15, 2018
// Kelly Tan

//MAKE FORMATING LOOK NICE (SUMMARY OF ALL ACCOUNTS/TRANSFER SUMMARY OF ALL ACCOUNTS, TRANSACTIONS HISTORY)

#include "stdafx.h"
#include "windows.h"
#include "iostream" 
#include "cstdlib" 
#include "time.h" 
#include "math.h" 
#include "iomanip" 
#include "string" 

using namespace std;

void summary(string saccount[][10], int inum, double dbalance[][101], int itransactions[]); //summary of accounts (account number and names)
void transactionfull(double damount[][101], string sdescription[][101], double dbalance[][101], int imanage1, int itransactions[]); //checks if transaction is full, if it is it deletes the first one to make room
void deposit(double damount[][101], string sdescription[][101], double dbalance[][101], int imanage1, int itransactions[], int ddeposit); //inputs values into transactions arrays
void withdraw(double damount[][101], string sdescription[][101], double dbalance[][101], int imanage1, int itransactions[], int dwithdraw); //inputs values into transactions arrays
void transfersummary(string saccount[][10], int imanage1, int inum, double dbalance[][101], int itransactions[]); //summary of accounts (account number and names), excluding the one being managed
void transferin(double damount[][101], string sdescription[][101], double dbalance[][101], int imanage1, int itransfer2, double dtransfer, int itransactions[]); //inputs values into transactions arrays for both accounts
void transferout(double damount[][101], string sdescription[][101], double dbalance[][101], int imanage1, int itransfer2, double dtransfer, int itransactions[]); //inputs values into transactions arrays for both accounts
void deleteaccount(string saccount[][10], double damount[][101], string sdescription[][101], double dbalance[][101], int idelete, int itransactions[]); //delete account (account information and transactions arrays)
void accountinformation(string saccount[][10], int iinformation2); //displays full account information for selected account
void transactionhistory(double damount[][101], string sdescription[][101], double dbalance[][101], int iinformation2, int itransactions[]); //displays full transaction history for selected account

int main()
{
	//general variables
	int imenu = 0; //menu option
	int inum = 0; //number of accounts there are
	int imanage1 = 0; //which account they want to manage
	int imanage2 = 0; //what they would like to do
	double ddeposit = 0;
	double dwithdraw = 0;
	int itransfer1 = 0; //if they are transfering money to or from the account
	int itransfer2 = 0; //account they are transfering to or from
	double dtransfer = 0;
	int idelete = 0; //which account they want to delete
	int iinformation1 = 0; //view account information or account transactions
	int iinformation2 = 0; //which account
	//boolean variables
	bool bmanageaccount1 = 0;
	bool bmanageaccount2 = 0;
	bool bdeleteaccount = 0;
	bool baccountinformation = 0;
	//account arrays
	string saccount[10][10]; //account information (account number, first name, last name, street number, street name, city, province, country, postal code, phone number)
	double damount[10][101]; //transactions
	string sdescription[10][101]; //transactions
	double dbalance[10][101]; //transactions
	int itransactions[10]; //how many transactions in each account

	//initialize arrays
	for (int cnta = 0; cnta <= 9; cnta++)
	{
		for (int cntb = 0; cntb <= 9; cntb++)
		{
			saccount[cnta][cntb] = "?";
		}
		itransactions[cnta] = 0;
	}
	for (int cnta = 0; cnta <= 9; cnta++)
	{
		for (int cntb = 0; cntb <= 100; cntb++)
		{
			damount[cnta][cntb] = -1;
			sdescription[cnta][cntb] = "?";
			dbalance[cnta][cntb] = 0;
		}
	}

	//colour
	system("Color F8");

	//input, process, output
	do
	{
		cout << "\n1. Open New Account";
		cout << "\n2. Manage Existing Accounts";
		cout << "\n3. Delete Accounts";
		cout << "\n4. Account Information";
		cout << "\n5. Exit";
		cout << "\nWhat would you like to do?: ";
		cin >> imenu;
		if (imenu == 1)
		{
			cout << "\nAccount number: ";
			cin >> saccount[inum][0];
			cout << "\nFirst name: ";
			cin >> saccount[inum][1];
			cout << "\nLast name: ";
			cin >> saccount[inum][2];
			cout << "\nStreet number: ";
			cin >> saccount[inum][3];
			cout << "\nStreet name: ";
			cin >> saccount[inum][4];
			cout << "\nCity: ";
			cin >> saccount[inum][5];
			cout << "\nProvince: ";
			cin >> saccount[inum][6];
			cout << "\nCountry: ";
			cin >> saccount[inum][7];
			cout << "\nPostal code: ";
			cin >> saccount[inum][8];
			cout << "\nPhone number: ";
			cin >> saccount[inum][9];
			inum++;
		}
		else if (imenu == 2)
		{
			do
			{
				summary(saccount, inum, dbalance, itransactions); //summary of all accounts
				cout << "\n\nWhich account would you like to manage?: ";
				cin >> imanage1;
				do
				{
					cout << "\n\n1. Deposit money";
					cout << "\n2. Withdraw money";
					cout << "\n3. Transfer money to or from a different account";
					cout << "\nWhat would you like to do?: ";
					cin >> imanage2;
					if (imanage2 == 1)
					{
						cout << "\n\nHow much money would you like to deposit?: ";
						cin >> ddeposit;
						transactionfull(damount, sdescription, dbalance, imanage1, itransactions); //checks if transaction is full, if it is it deletes the first one to make room
						deposit(damount, sdescription, dbalance, imanage1, itransactions, ddeposit); //input values into transaction arrays
						itransactions[imanage1]++;
					}
					else if (imanage2 == 2)
					{
						cout << "\n\nHow much money would you like to withdraw?: ";
						cin >> dwithdraw;
						if (itransactions == 0)
						{
							cout << "\nYour bank account balance is currently at $0";
							continue;
						}
						else if (dwithdraw > (dbalance[imanage1][(itransactions[imanage1] - 1)])) //if not enough money in the last balance
						{
							cout << "\nYou do not have enough money in you bank account to withdraw " << dwithdraw;
							continue;
						}
						transactionfull(damount, sdescription, dbalance, imanage1, itransactions); //checks if transaction is full, if it is it deletes the first one to make room
						withdraw(damount, sdescription, dbalance, imanage1, itransactions, dwithdraw); //input values into transactions arrays
						itransactions[imanage1]++;
					}
					else if (imanage2 == 3)
					{
						if (inum == 1)
						{
							cout << "\n\nYou currently only have 1 account on the system";
							continue;
						}
						cout << "\n\nWould you like to transfer money to this account(1) or transfer money to another account(2)?: ";
						cin >> itransfer1;
						transfersummary(saccount, imanage1, inum, dbalance, itransactions); //summary of accounts except for the one currently managing
						if (itransfer1 == 1)
						{
							cout << "\nWhich account would you like to transfer money from?: ";
							cin >> itransfer2;
							cout << "\nHow much money would you like to transfer to this account?: ";
							cin >> dtransfer;
							if (dtransfer > (dbalance[itransfer2][(itransactions[itransfer2] - 1)])) //if not enough money in the other account's last balance
							{
								cout << "\nYou do not have enough money to transfer $" << dtransfer << " from account " << saccount[itransfer2][0];
								continue;
							}
							transactionfull(damount, sdescription, dbalance, imanage1, itransactions); //checks if transaction is full, if it is it deletes the first one to make room
							transferin(damount, sdescription, dbalance, imanage1, itransfer2, dtransfer, itransactions); //input values into both transactions arrays
						}
						else if (itransfer1 == 2)
						{
							cout << "\nWhich account would you like to transfer money to?: ";
							cin >> itransfer2;
							cout << "\nHow much money would you like to transfer to that account?: ";
							cin >> dtransfer;
							if (dtransfer > (dbalance[imanage1][(itransactions[imanage1] - 1)])) //if not enough money in account's last balance
							{
								cout << "\nYou do not have enough money to transfer $" << dtransfer << " to account " << saccount[itransfer2][0];
								continue;
							}
							transactionfull(damount, sdescription, dbalance, imanage1, itransactions); //checks if transaction is full, if it is it deletes the first one to make room
							transferout(damount, sdescription, dbalance, imanage1, itransfer2, dtransfer, itransactions); //input values into both transactions arrays
						}
						itransactions[imanage1]++;
						itransactions[itransfer2]++;
					}
					cout << "\n\nEnter 1 to keep managing this account, 0 if you are done: ";
					cin >> bmanageaccount1;
				} while (bmanageaccount1);
				cout << "\n\nEnter 1 to manage another account, 0 to return to the main menu: ";
				cin >> bmanageaccount2;
			} while (bmanageaccount2);
		}
		else if (imenu == 3)
		{
			do
			{
				summary(saccount, inum, dbalance, itransactions); //summary of all accounts
				cout << "\n\nWhich account would you like to delete?: ";
				cin >> idelete;
				deleteaccount(saccount, damount, sdescription, dbalance, idelete, itransactions); //function for deleting selected account's information and transactions
				inum--;
				cout << "\n\nEnter 1 to delete more accounts, 0 to retern to the main menu: ";
				cin >> bdeleteaccount;
			} while (bdeleteaccount);
		}
		else if (imenu == 4)
		{
			do
			{
				cout << "\n\nWould you like to view account information(1) or account transactions(2)?: ";
				cin >> iinformation1;
				summary(saccount, inum, dbalance, itransactions); //summary of all accounts
				if (iinformation1 == 1)
				{
					cout << "\n\nWhich account's information would you like to see?: ";
					cin >> iinformation2;
					accountinformation(saccount, iinformation2); //function for outputting account information
				}
				else if (iinformation1 == 2)
				{
					cout << "\n\nWhich account's transactions would you like to see?: ";
					cin >> iinformation2;
					transactionhistory(damount, sdescription, dbalance, iinformation2, itransactions); //function for outputting account transactions
				}
				cout << "\n\nEnter 1 to view the information of another account, 0 to return to the main menu: ";
				cin >> baccountinformation;
			} while (baccountinformation);
		}
		else if (imenu == 5)
		{
			return 0;
		}
	} while (true);
}

void summary(string saccount[][10], int inum, double dbalance[][101], int itransactions[])
{
	std::cout << std::setprecision(0) << std::fixed;
	cout << endl << "Number" << setw(28) << "Name" << setw(30) << "Account" << setw(30) << "Balance";
	for (int cnta = 0; cnta < inum; cnta++)
	{
		cout << endl << cnta << "." << setw(30) << saccount[cnta][1] << setw(30) << saccount[cnta][0];
		if ((itransactions[cnta]) == 0)
		{
			cout << setw(30) << dbalance[cnta][itransactions[cnta]];
		}
		else
		{
			cout << setw(30) << dbalance[cnta][((itransactions[cnta]) - 1)];
		}
	}
}

void transactionfull(double damount[][101], string sdescription[][101], double dbalance[][101], int imanage1, int itransactions[])
{
	if ((itransactions[imanage1]) == 101)
	{
		for (int cnta = 0; cnta < 100; cnta++)
		{
			damount[imanage1][cnta] = damount[imanage1][cnta + 1];
			sdescription[imanage1][cnta] = sdescription[imanage1][cnta + 1];
			dbalance[imanage1][cnta] = dbalance[imanage1][cnta + 1];
		}
		itransactions[imanage1]--;
	}
}

void deposit(double damount[][101], string sdescription[][101], double dbalance[][101], int imanage1, int itransactions[], int ddeposit)
{
	damount[imanage1][itransactions[imanage1]] = ddeposit;
	sdescription[imanage1][itransactions[imanage1]] = "Deposit";
	if ((itransactions[imanage1]) == 0)
	{
		dbalance[imanage1][itransactions[imanage1]] = ddeposit;
	}
	else
	{
		dbalance[imanage1][itransactions[imanage1]] = dbalance[imanage1][(itransactions[imanage1]) - 1] + ddeposit;
	}
}

void withdraw(double damount[][101], string sdescription[][101], double dbalance[][101], int imanage1, int itransactions[], int dwithdraw)
{
	damount[imanage1][itransactions[imanage1]] = -dwithdraw;
	sdescription[imanage1][itransactions[imanage1]] = "Withdrawal";
	dbalance[imanage1][itransactions[imanage1]] = dbalance[imanage1][(itransactions[imanage1]) - 1] - dwithdraw;
}

void transfersummary(string saccount[][10], int imanage1, int inum, double dbalance[][101], int itransactions[])
{
	std::cout << std::setprecision(0) << std::fixed;
	cout << endl << "Number" << setw(28) << "Name" << setw(30) << "Account" << setw(30) << "Balance";
	for (int cnta = 0; cnta < inum; cnta++)
	{
		if (cnta == imanage1)
		{
			continue;
		}
		cout << endl << cnta << "." << setw(30) << saccount[cnta][1] << setw(30) << saccount[cnta][0];
		if ((itransactions[cnta]) == 0)
		{
			cout << setw(30) << dbalance[cnta][itransactions[cnta]];
		}
		else
		{
			cout << setw(30) << dbalance[cnta][((itransactions[cnta]) - 1)];
		}
	}
}

void transferin(double damount[][101], string sdescription[][101], double dbalance[][101], int imanage1, int itransfer2, double dtransfer, int itransactions[])
{
	if ((itransactions[itransfer2]) == 101) //if account transfering money from already has 100 transactions, delete first one to make space
	{
		for (int cnta = 0; cnta < 100; cnta++)
		{
			damount[itransfer2][cnta] = damount[itransfer2][cnta + 1];
			sdescription[itransfer2][cnta] = sdescription[itransfer2][cnta + 1];
			dbalance[itransfer2][cnta] = dbalance[itransfer2][cnta + 1];
		}
		itransactions[imanage1]--;
	}
	//input info into transactions of both accounts
	damount[imanage1][itransactions[imanage1]] = dtransfer;
	sdescription[imanage1][itransactions[imanage1]] = "Transfer";
	dbalance[imanage1][itransactions[imanage1]] = dbalance[imanage1][(itransactions[imanage1]) - 1] + dtransfer;
	damount[itransfer2][itransactions[itransfer2]] = -dtransfer;
	sdescription[itransfer2][itransactions[itransfer2]] = "Transfer";
	dbalance[itransfer2][itransactions[itransfer2]] = dbalance[itransfer2][(itransactions[itransfer2]) - 1] - dtransfer;
}

void transferout(double damount[][101], string sdescription[][101], double dbalance[][101], int imanage1, int itransfer2, double dtransfer, int itransactions[])
{
	if ((itransactions[itransfer2]) == 101) //if account transfering money to already has 100 transactions, delete first one to make space
	{
		for (int cnta = 0; cnta < 100; cnta++)
		{
			damount[itransfer2][cnta] = damount[itransfer2][cnta + 1];
			sdescription[itransfer2][cnta] = sdescription[itransfer2][cnta + 1];
			dbalance[itransfer2][cnta] = dbalance[itransfer2][cnta + 1];
		}
		itransactions[imanage1]--;
	}
	//input info into transactions of both accounts
	damount[imanage1][itransactions[imanage1]] = -dtransfer;
	sdescription[imanage1][itransactions[imanage1]] = "Transfer";
	dbalance[imanage1][itransactions[imanage1]] = dbalance[imanage1][(itransactions[imanage1]) - 1] - dtransfer;
	damount[itransfer2][itransactions[itransfer2]] = dtransfer;
	sdescription[itransfer2][itransactions[itransfer2]] = "Transfer";
	dbalance[itransfer2][itransactions[itransfer2]] = dbalance[itransfer2][(itransactions[itransfer2]) - 1] + dtransfer;
}

void deleteaccount(string saccount[][10], double damount[][101], string sdescription[][101], double dbalance[][101], int idelete, int itransactions[])
{
	do
	{
		for (int cnta = 0; cnta <= 9; cnta++) //deleting account information
		{
			saccount[idelete][cnta] = saccount[idelete + 1][cnta];
		}
		for (int cnta = 0; cnta <= 100; cnta++) //deleting transaction history
		{
			damount[idelete][cnta] = damount[idelete + 1][cnta];
			sdescription[idelete][cnta] = sdescription[idelete + 1][cnta];
			dbalance[idelete][cnta] = damount[idelete + 1][cnta];
		}
		itransactions[idelete] = itransactions[idelete + 1]; //deleting number of transactions
		idelete++;
	} while (idelete < 9);
}

void accountinformation(string saccount[][10], int iinformation2)
{
	std::cout << std::setprecision(0) << std::fixed;
	cout << endl << endl << "Account number: " << saccount[iinformation2][0];
	cout << endl << "Name: " << saccount[iinformation2][1] << " " << saccount[iinformation2][2];
	cout << endl << "Address: " << saccount[iinformation2][3] << " " << saccount[iinformation2][4] << ", " << saccount[iinformation2][5] << ", " 
		<< saccount[iinformation2][6] << ", " << saccount[iinformation2][8] << ", " << saccount[iinformation2][7];
	cout << endl << "Phone number: " << saccount[iinformation2][9];
}

void transactionhistory(double damount[][101], string sdescription[][101], double dbalance[][101], int iinformation2, int itransactions[])
{
	std::cout << std::setprecision(0) << std::fixed;
	cout << endl << endl << "Description" << setw(30) << "Amount" << setw(30) << "Balance";
	for (int cnta = 0; cnta < (itransactions[iinformation2]); cnta++)
	{
		cout << endl << sdescription[iinformation2][cnta] << setw(30) << damount[iinformation2][cnta] << setw(30) << dbalance[iinformation2][cnta];
	}
}